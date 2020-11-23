import { TabNumber } from './../../../shared/helpers/enum';
import { filter, map } from 'rxjs/operators';
import { EventType, TranslationType, ITStatusEnum, WorkQueueEnum } from 'app/shared/helpers/enum';
import { Component, OnInit, Injector, ViewChild, Input } from '@angular/core';
import { TranslationViewModel } from 'app/model/translation.model';
import { TranslationService } from 'app/core/services/translation.service';
import { Params } from '@angular/router';
import { BaseComponent } from 'app/core/componenet/base.component';
import { SelectItem } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-translation',
  templateUrl: './translation.component.html'

})
export class TranslationComponent extends BaseComponent implements OnInit {
  viewModel: TranslationViewModel = new TranslationViewModel();
  @ViewChild('attachmentsTable') attachmentsTable: Table;
  flagtype: any;
  attachement: string = 'attachement';
  attachements = [];
  i = 0;
  conattachment;
  constructor(public injector: Injector,
    public translationService: TranslationService) {
    super(injector);

  }


  ngOnInit() {
    super.ngOnInit();
    this.viewModel.jobId = 0;
    console.log("requestTypes" + this.viewModel.requestTypes);
    this.viewModel.requestTypes = this.utilityService.getEnumList(TranslationType);
    this.viewModel.isNewMode = true;
    this.viewModel.isEnglish = this.localizationService.isEnglish;

    this.route.queryParamMap.subscribe((response: Params) => {
      if (response && response.keys && response.keys.length > 0) {
        this.viewModel.jobId = response.params.jobid;
        this.viewModel.nodeId = +response.params.nodeid;
        this.viewModel.epc = response.params.epc;
        this.viewModel.reviewMode = response.params.reviewMode;
      }
      this.translationService.getRequestFields(this.viewModel.nodeId).subscribe(response => {
        this.viewModel.fields = response;
        console.log(this.viewModel.fields);
        this.viewModel.item.requester = this.baseEmployee;
       // this.viewModel.showAssignedTo = this.viewModel.fields.find(x => x.fieldName == "assignedTo" && x.visible);
        this.viewModel.showManagerNotes = this.viewModel.fields.find(x => x.fieldName == "managerNotes" && x.visible);
        this.viewModel.attachmentisRequired = this.viewModel.fields.find(x => x.fieldName === "attachement" && x.required);
        this.viewModel.radioIsEditable = this.viewModel.fields.find(x => x.fieldName === "enToAr" && !x.editable);
        this.viewModel.attachementtypes = this.viewModel.fields.filter(x => x.isAttachement && x.visible);
      })
      this.LoadSomeData(); 
    });
  }
  loadRequestData() {
    this.viewModel.tabnumber = 3;
    this.translationService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc, this.viewModel.reviewMode).subscribe((res: any) => {
      this.viewModel.item = res;
      // this.viewModel.item.domainModel =  this.viewModel.item.domainModel;
      this.viewModel.item.jobID = this.viewModel.jobId;
      this.viewModel.item.nodeID = this.viewModel.nodeId;
      this.baseEmployee=this.viewModel.item.requester;
      this.viewModel.selectedRequestType = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.requestType, this.viewModel.requestTypes);
      if (this.viewModel.selectedRequestType.value == <number>TranslationType.Translation) { this.viewModel.showENToAR = true; }
      this.viewModel.isNewMode = false;
      if (this.viewModel.selectedRequestType === undefined) { this.flagtype = true; }
      else { this.flagtype = false; }
      console.log(this.viewModel.jobId && !this.viewModel.isNewMode)
      this.processRequest();
    });
  }

  processRequest() {

    const subscribtion = this.dataService.getMessage(EventType.DecisionSelected).subscribe(
      response => {
        
        if(response.id=='201')
        this.viewModel.attachmentisRequired=false;

        this.checkData()
        if (!this.viewModel.isRequiredAttachementIsValid) { return; }
        this.viewModel.item.managerDecision = {};
        this.viewModel.item.managerDecision.id = response.id;
        this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
        this.viewModel.item.requester.employeeName = this.baseEmployee.employeeNameAr;
       // if (this.viewModel.assignedTo)
         // this.viewModel.item.domainModel.assignedTo = this.viewModel.assignedTo.transEmail;
        this.viewModel.item.domainModel.RequestType = this.viewModel.selectedRequestType.value;
        this.viewModel.item.managerDecision.comment = response.comment;
        this.viewModel.item.jobID = this.viewModel.jobId;
        this.viewModel.item.nodeID = this.viewModel.nodeId;

        this.translationService.processRequestWithAttachement(this.viewModel, "translation").subscribe((response: any) => {
          this.translate.get('Message.DataSaved').subscribe((response: string) => {
            this.toastr.success(response);

          });

        })
        this.router.navigate(['/employees/wq']);

      }
    )


  }
  loadAttachmentsData(event) {

    if (this.attachmentsTable) this.attachmentsTable.loading = true;
    this.translationService.getAttachments(this.viewModel.jobId).subscribe((resp: any) => {
      this.viewModel.attachementData = resp;
      this.attachmentsTable.value = this.viewModel.attachementData;
      this.attachmentsTable.loading = false;
    });

  }


  onUpload(event): void {
    for(this.i ; this.i < event.files.length ; this.i++)
    {
    if(event.files[this.i].type == 'application/vnd.openxmlformats-officedocument.wordprocessingml.document')
      {
        this.viewModel[this.attachement] = null;
     // this.attachements = this.attachements.concat(Array.from(event.files));
        this.attachements = this.attachements.concat(event.files[this.i]);
        this.viewModel[this.attachement] = this.attachements;
      }
    }
    this.i = 0;
  }

  onRemove(event) {
    const index = this.viewModel[this.attachement].indexOf(event.file);
    this.viewModel[this.attachement].splice(index, 1);
  }

  clear() {
    this.viewModel[this.attachement] = [];
  }


  getTranslator() {
    this.translationService.getTranslators().subscribe(response => {
      this.viewModel.translators = response;
    })
  }

  LoadSomeData() {
    this.translationService.getPendingInstructionRequest().subscribe(response => {
      this.viewModel.PendingInstructionRequest = response;
      this.viewModel.pendingRequests =  this.viewModel.PendingInstructionRequest.pendingtasks;
      this.viewModel.instructionsEN = this.viewModel.PendingInstructionRequest.instruction.instructionsEN;
      this.viewModel.instructionsAR = this.viewModel.PendingInstructionRequest.instruction.instructionsAR; 
      if ((this.viewModel.jobId && this.viewModel.reviewMode) || (this.viewModel.jobId && this.viewModel.nodeId > 0)) {
        this.viewModel.isNewMode = false;
        this.loadRequestData();
      }
    })
  }

 

  changeTab(number, frm) {
   
    if (frm && frm.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }
    this.viewModel.tabnumber = number;
  }
  nextTab(number) {
    if (number == <number>TabNumber.RequestTab && !this.viewModel.isAgreed)
    { return;}
     this.viewModel.tabnumber = number;
   }

  onChangeRequestType(event) {

    if (event.value.value == <number>TranslationType.Translation) {
      this.viewModel.showENToAR = true;
      this.flagtype = false;
    }
    else {
      this.viewModel.showENToAR = false;
      this.flagtype = false;
    }
  }

  checkData() {
    if (this.viewModel.attachmentisRequired) {
      if (!this.viewModel[this.attachement] || this.viewModel[this.attachement].length <= 0)
        this.viewModel.isRequiredAttachementIsValid = false;
      else
        this.viewModel.isRequiredAttachementIsValid = true;
    }

    else if (!this.viewModel.attachmentisRequired)
      this.viewModel.isRequiredAttachementIsValid = true;

  }

  submit(form) {
    if (form && form.invalid ) {
      this.viewModel.submitRequestForm = true;
      return;
    }
    this.checkData()
    if (!this.viewModel.isRequiredAttachementIsValid) { return; }

    this.viewModel.submitted = true;
    this.viewModel.submitRequestForm = true;

    this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
    this.viewModel.item.domainModel.RequestType = this.viewModel.selectedRequestType.value;

    this.translationService.postRequestWithAttachement(this.viewModel, "translation").subscribe((resp: any) => {
      this.translate.get('Message.DataSaved').subscribe((res: string) => {
        this.toastr.success(res);
        this.viewModel.isNewMode = false;
        this.viewModel.tabnumber = 3;
      });
    });
    this.router.navigate(['/employees/wq'], { queryParams: { tab: WorkQueueEnum.SubmitRequest } });
  }

  private download(item) {
    this.baseService.download(item.fileAbsolutePath).subscribe(res => {
      console.log(res);
      var link = document.createElement('a');
      link.href = window.URL.createObjectURL(res);
      console.log(link.href);
      link.download = item.fileName;
      link.style.display = "none";
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);

    });
  }

}
