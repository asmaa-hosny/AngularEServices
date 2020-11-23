import { UtilityService } from "app/core/services/utility.service";
import { EmployeeService } from "app/core/services/employee.service";

import { DataService } from "app/core/services/data.service";
import { Component, OnInit, ChangeDetectorRef, ViewChild } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { TranslateService } from "@ngx-translate/core";
import { ToastrService } from "ngx-toastr";
import { MissionViewModel } from "app/model/mission.model";
import { MissionService } from "app/core/services/mission.service";
import { LocalizationService } from "app/core/services/localization.service";
import { BaseService } from "app/core/services/base.service";
import { Calendar } from "primeng/calendar";
import { Table } from "primeng/table";
import { map } from "rxjs/operators";
import { FileUpload } from "primeng/fileupload";



@Component({
  selector: 'app-mission-completion',
  templateUrl: './mission-completion.component.html'

})
export class MissionCompletionComponent implements OnInit {
  viewModel: MissionViewModel = new MissionViewModel();
  @ViewChild('completionDate') completionDate: Calendar;
  @ViewChild('attachmentsTable') attachmentsTable: Table;
  @ViewChild('uploadAttachment') uploadAttachment: FileUpload;
  attachement: string = 'attachement';
  constructor(
    public utilityService: UtilityService,
    public employeeSevice: EmployeeService,
    public baseService: BaseService,
    public missionService: MissionService,
    public localizationService: LocalizationService,
    public changeDetectorRef: ChangeDetectorRef,
    public route: ActivatedRoute, public translate: TranslateService,
    private toastr: ToastrService,
    public communicationService: DataService) { }

  ngOnInit() {

    this.viewModel.jobId = 0;
    this.viewModel.isNewMode = true;
    this.viewModel.isEnglish = this.localizationService.isEnglish;
    this.employeeSevice.getCurrentEmployee().subscribe(empdata => {
      this.viewModel.employee = empdata;
      this.viewModel.item.domainModel.employeeID = this.viewModel.employee.employeeID;
      this.route.queryParamMap.subscribe((params: Params) => {
        if (params && params.keys.length > 0) {

          this.viewModel.jobId = params.params.JobID;
          this.viewModel.nodeId = +params.params.NodeID;
          this.viewModel.epc = params.params.EPC;
          this.viewModel.isNewMode = false;
        }
     
        this.missionService.getRequestFields(this.viewModel.nodeId).subscribe(res => {
          this.viewModel.fields = res;
          this.viewModel.isPayrollVisible = this.utilityService.isVisibleField(this.viewModel.fields, "foodDeductDays") 
          this.viewModel.attachementtypes = this.viewModel.fields.filter(function (item) { return item.isAttachement && item.visible });
        
          if (this.viewModel.jobId && this.viewModel.nodeId > 0 && this.viewModel.epc) {
            this.loadRequestData();
            if (this.attachmentsTable) this.attachmentsTable.reset();
            this.viewModel.isNewMode = false;
          }
          else if(!this.viewModel.jobId && this.viewModel.isNewMode == true)
          {
            this.missionService.getEmployeeMissions(this.viewModel.employee.employeeID).subscribe(empMissiondata => {
              this.viewModel.empMissions = empMissiondata;
              this.viewModel.item = empMissiondata[0];
              this.viewModel.startDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateFrom, false);
              this.viewModel.endDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateTo, false);
              this.viewModel.completionDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateTo, false);

            })
          }
          console.log(this.viewModel.fields);
        })


      });
    });

  }

  private loadRequestData() {
    this.missionService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc)
      .pipe(
        map(res => {
          this.viewModel.item = res;
          this.viewModel.item.jobID = this.viewModel.jobId;
          this.viewModel.item.nodeID = this.viewModel.nodeId;
          this.viewModel.displayEarlySection = this.viewModel.item.domainModel.earlyDays > 0
          this.viewModel.completionDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.completedDate, false);
          this.viewModel.selectedEmpMission = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.mission, this.viewModel.empMissions);
          this.viewModel.startDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateFrom, false);
          this.viewModel.endDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateTo, false);
          this.changeDetectorRef.detectChanges();
          this.processRequest();
        }))
      .subscribe(result => {
        console.log("Done");
      })

  }

  recalculate()
  {
    this.missionService.recalculateMission(this.viewModel).subscribe((res: any) => {
      this.viewModel.item = res;
    })

  }
  processRequest() {
    this.communicationService.submitAction.subscribe((resp: any) => {
      this.viewModel.item.managerDecision = {};
      this.viewModel.item.managerDecision.id = resp.id;
      this.viewModel.item.managerDecision.comment = resp.comment;
      this.missionService.processRequest(this.viewModel).subscribe((resp: any) => {
        this.translate.get('Message.DataSaved').subscribe((res: string) => {
          this.toastr.success(res);
        });
      })
    })
  }

  loadAttachmentsData(event) {
    this.changeDetectorRef.detectChanges();
    this.attachmentsTable.loading = true;
    this.missionService.getAttachments(this.viewModel.jobId).subscribe((resp: any) => {
      this.viewModel.attachementData = resp;
      this.attachmentsTable.value = this.viewModel.attachementData;
      this.attachmentsTable.loading = false;
    });

  }

  checkData() {
    if (this.viewModel.item.domainModel.isReportNeeded)
      this.viewModel.isRequiredAttachementIsValid = true;
    else
      if (!this.viewModel.item.domainModel.isReportNeeded) {
        if (!this.viewModel[this.attachement] || this.viewModel[this.attachement].length <= 0)
          this.viewModel.isRequiredAttachementIsValid = false;
        else
          this.viewModel.isRequiredAttachementIsValid = true;
      }
  }

  submit(form) {
    this.viewModel.submitted = true;
    this.viewModel.submitRequestForm = true;
    this.checkData()
    if (!this.viewModel.isRequiredAttachementIsValid) { return; }
    this.viewModel.item.domainModel.completedDate = this.utilityService.convertToApiDate(this.completionDate.value, false);
    this.viewModel.item.domainModel.EmployeeID = this.viewModel.employee.employeeID;
    this.missionService.PostRequest(this.viewModel).subscribe((resp: any) => {
      this.viewModel.submitClicked = true;
      this.viewModel.jobId = resp.jobID;
      this.viewModel.item = resp;
      this.viewModel.item[this.attachement] = []
      this.uploadAttachment.files=[];
      this.viewModel.isNewMode = false;
      this.viewModel.tabnumber = 2;
      this.translate.get('Message.DataSaved').subscribe((res: string) => {
        this.toastr.success(res);
      });
    })

  }


  onBasicUpload(event): void {
    var count = 0;
    var displayName = "";
    this.viewModel[this.attachement] = Array.from(event.files);
    console.log("onBasicUpload" + this.viewModel[name]);
  }

  onRemove(event) {
    const index = this.viewModel[this.attachement].indexOf(event.file);
    this.viewModel[this.attachement].splice(index, 1);
  }

  clear() {
    this.viewModel[this.attachement] = [];
  }

  changeTab(number, frm) {
    if (frm && frm.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }
    //for earlysection
    if (number == 3) {
      if (this.viewModel.displayEarlySection) {
        this.viewModel.tabnumber = number
      }
      else this.viewModel.tabnumber =  5;
    }
    else
      this.viewModel.tabnumber = number;
  }

  onSelectDate() {
    this.checkEarlyDisplaySection();
  }

  onInputDate($event) {
    this.checkEarlyDisplaySection();
  }

  checkEarlyDisplaySection() {
    var diff = this.utilityService.getDateDiffrenceDays(this.viewModel.endDateValue, this.completionDate.value)
    if (diff > 0) this.viewModel.displayEarlySection = true;
    else
      this.viewModel.displayEarlySection = false;;
    this.viewModel.item.domainModel.earlyDays = diff;
  }

  onChangeMissionId(event) {
    if (event.value)
      var result = this.viewModel.empMissions.find(x => x.domainModel.missionID == +event.value.domainModel.missionID)
    if (result) {
      this.viewModel.item = result;
      this.viewModel.startDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateFrom, false);
      this.viewModel.endDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateTo, false);
      this.viewModel.completionDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateTo, false);
    }
  }
}