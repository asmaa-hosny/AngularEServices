import { Component, OnInit, ViewChild, ChangeDetectorRef, ViewChildren, AfterViewInit } from '@angular/core';
import { DropdownModule, Dropdown } from 'primeng/dropdown';
import { TypeofExpr } from '@angular/compiler';
import { UtilityService } from 'app/core/services/utility.service';
import { LocalizationService } from 'app/core/services/localization.service';
import { environment } from 'environments/environment';
import { IdentificationService } from 'app/core/services/identification.service';
import { FileUpload } from 'primeng/fileupload';
import { ToastrService } from 'ngx-toastr';
import { Table } from 'primeng/table';
import { RequisitionService } from 'app/core/services/requisition.service';
import { Observable } from 'rxjs/Observable';
import { forkJoin, of, EMPTY } from 'rxjs';
import { map, filter, mergeMap, flatMap, catchError } from 'rxjs/operators';
import { Calendar } from 'primeng/calendar';
import { AttachementService } from 'app/core/services/attachement.service';
import { BaseService } from 'app/core/services/base.service';
import { DataService } from 'app/core/services/data.service';
import { NgForm } from '@angular/forms';
import { EmployeeService } from 'app/core/services/employee.service';
import { RequisitionViewModel } from 'app/model/requisition-model';
import { ActivatedRoute, Params } from '@angular/router';
import { DecoratorService } from 'app/core/services/decorator.service';
import { TranslateService } from '@ngx-translate/core';
import { RequisitionNatureEnum } from 'app/shared/helpers/enum';


@Component({
  selector: 'app-requisition',
  templateUrl: './requisition.component.html'

})
export class RequisitionComponent implements OnInit {

  viewModel: RequisitionViewModel = new RequisitionViewModel();
  get RequisitionNatureEnum() { return RequisitionNatureEnum; }
  @ViewChild('startDate') startDate: Calendar;
  @ViewChild('endDate') endDate: Calendar;
  @ViewChild('requestForm') form: NgForm;
  @ViewChild('accountList') list: any;
  @ViewChild('projectTypeList') projectTypeList: Dropdown;
  @ViewChild('formfinancial') formfinancial: NgForm;
  @ViewChild('formProcurement') formProcurement: NgForm;


  constructor(public utilityService: UtilityService,
    public requisitionService: RequisitionService,
    public localizationService: LocalizationService,
    public route: ActivatedRoute,
    public communicationService: DataService,
    private toastr: ToastrService,
    public attachementService: AttachementService,
    public employeeSevice: EmployeeService,
    public changeDetectorRef: ChangeDetectorRef,
    public translate: TranslateService) {
    this.viewModel.item.domainModel = {};
  }

  sources = [
    this.requisitionService.getProjectTypes(),
    this.requisitionService.getRequisitionNature(),
    this.employeeSevice.getCurrentEmployee(),
    this.requisitionService.getRequisitionTypes(),
  ];



  ngOnInit() {
    this.viewModel.isNewMode = true;
    this.viewModel.isEnglish = this.localizationService.isEnglish;
    this.route.queryParamMap.subscribe((params: Params) => {
      if (params) {
        this.viewModel.jobId = params.params.JobID;
        this.viewModel.nodeId = +params.params.NodeID;
        this.viewModel.epc = +params.params.epc;
      }
      this.requisitionService.getRequestFields(this.viewModel.nodeId).subscribe(res => {
        this.viewModel.fields = res;
        console.log(this.viewModel.fields);
        this.viewModel.attachementtypes = this.viewModel.fields.filter(function (item) { return item.isAttachement && item.visible });
        this.viewModel.canAddEditVendor = this.utilityService.isEditableField(this.viewModel.fields, "vendors")
        this.viewModel.isFinanceRole = this.utilityService.isEditableField(this.viewModel.fields, "accountID") || this.utilityService.isVisibleField(this.viewModel.fields, "accountID")
        this.viewModel.isProcurementRole = this.utilityService.isEditableField(this.viewModel.fields, "requisitionTypeID") || this.utilityService.isVisibleField(this.viewModel.fields, "requisitionTypeID")
        // if(this.viewModel.isProcurementRole)  this.sources.push(this.requisitionService.getRequisitionTypes());
        this.changeDetectorRef.detectChanges();

      })
    });

    forkJoin(this.sources).subscribe(data => {
      this.viewModel.projectTypes = data[0];
      this.viewModel.requisitionNatures = data[1];
      this.viewModel.employee = data[2];
      this.viewModel.requisitionTypes = data[3];

      if (this.viewModel.jobId) {
        this.viewModel.isNewMode = false;
        this.loadRequestData();
      }
    })

  }


  private loadRequestData() {
    this.requisitionService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc)
      .pipe(

        map(res => {
          this.viewModel.item = res;
          this.viewModel.item.jobID = this.viewModel.jobId;
          this.viewModel.item.nodeID = this.viewModel.nodeId;
          this.viewModel.selectedProjectType = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.projectTypeID, this.viewModel.projectTypes);
          this.viewModel.selectedNature = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.requisitionNatureID, this.viewModel.requisitionNatures);
          this.viewModel.startDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.startDate, false);
          this.viewModel.endDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.endDate, false);
          if (this.viewModel.isProcurementRole && this.viewModel.item.domainModel.requisitionTypeID)
            this.viewModel.selectedRequisitionType = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.requisitionTypeID, this.viewModel.requisitionTypes);
          this.changeDetectorRef.detectChanges();
          this.processRequest();
        }),
        flatMap(() => this.requisitionService.getAttachments(this.viewModel.jobId)),
        map(resp => { this.viewModel.attachementData = resp; }),
        filter(res => this.viewModel.isFinanceRole == true),
        flatMap(res => this.requisitionService.getAccounts()),
        map(resp => {
          this.viewModel.accounts = resp;
          if (this.viewModel.accounts && this.viewModel.item.domainModel.accountID) {
            this.viewModel.isValidFinanceData = true;
            this.viewModel.selectedAccount = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.accountID, this.viewModel.accounts);
          }
        }),
        flatMap(res => this.requisitionService.getAvailableBudget(this.viewModel.selectedAccount.value)))
      .subscribe(result => {
        this.viewModel.item.requisitionBudget = result;
      })

  }

  loadAttachmentsData() {
    this.requisitionService.getAttachments(this.viewModel.jobId).subscribe((resp: any) => {
      this.viewModel.attachementData = resp;
    });

  }

  checkData() {
    this.viewModel.isRequiredAttachementIsValid = true;
    this.viewModel.invalidstartDate = this.startDate.value && this.endDate.value && this.endDate.value <= this.startDate.value;
    if (this.viewModel.attachementtypes) {
      this.viewModel.attachementtypes.forEach(element => {
        if (element.required) {
          if (!this.viewModel[element.fieldName] || this.viewModel[element.fieldName].length <= 0) {
            this.viewModel.isRequiredAttachementIsValid = false;
            return;
          }
        }
      });
    }

  }

  changeTab(number, frm) {
    if (frm && frm.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }
    if (number == 3) {
      this.viewModel.invalidstartDate = this.startDate.value && this.endDate.value && this.endDate.value <= this.startDate.value;
      if (this.viewModel.invalidstartDate) {
        this.viewModel.submitRequestForm = true;
        return;
      }
    }
    this.viewModel.tabnumber = number;
  }

  submit(form) {

    this.viewModel.submitted = true;
    this.viewModel.submitRequestForm = true;

    this.checkData()

    if (!this.viewModel.isRequiredAttachementIsValid) { return; }
    if (form.invalid || this.viewModel.invalidstartDate || !this.viewModel.isRequiredAttachementIsValid) { return; }
    this.viewModel.item.domainModel.projectTypeID = this.viewModel.selectedProjectType.value;
    if (this.viewModel.selectedAccount && this.viewModel.selectedAccount.value) this.viewModel.item.domainModel.accountID = this.viewModel.selectedAccount.value;
    this.viewModel.item.domainModel.requisitionNatureID = this.viewModel.selectedNature.value;
    this.viewModel.item.domainModel.startDate = this.utilityService.convertToApiDate(this.startDate.value, false);
    this.viewModel.item.domainModel.endDate = this.utilityService.convertToApiDate(this.endDate.value, false);
    this.viewModel.item.domainModel.employeeMail = this.viewModel.employee.employeeEmail;
    this.requisitionService.PostRequest(this.viewModel).subscribe((resp: any) => {
      this.viewModel.submitClicked = true;
      this.viewModel.jobId = resp.jobID;
      this.viewModel.item = resp;
      this.viewModel.isValidNature=true;
      this.viewModel.attachementtypes.forEach(element => {
        this.viewModel[element.fieldName] = [];
        this.viewModel[element.fieldName].displayName = "";
      });
      this.viewModel.isNewMode = false;
      this.loadAttachmentsData();
      this.viewModel.tabnumber = 2;
      this.translate.get('Message.DataSaved').subscribe((res: string) => {
        this.toastr.success(res);
      });
    })

  }

  processRequest() {
    this.checkProcessData();
    this.communicationService.submitAction.subscribe((resp: any) => {
      this.viewModel.item.managerDecision = {};
      this.viewModel.item.managerDecision.id = resp.id;
      this.viewModel.item.managerDecision.comment = resp.comment;
      this.viewModel.item.domainModel.accountID = this.viewModel.selectedAccount.value;
      this.viewModel.item.domainModel.requisitionTypeID = this.viewModel.selectedRequisitionType.value;
      this.requisitionService.processRequest(this.viewModel, this.viewModel.attachementtypes).subscribe((resp: any) => {
        this.translate.get('Message.DataSaved').subscribe((res: string) => {
          this.toastr.success(res);
        });

      })

    })

  }

  checkProcessData() {


    if (this.formfinancial) {
      this.viewModel.isValidFinanceData = this.formfinancial.valid;
      this.formfinancial.form.valueChanges.subscribe(x => {
        this.viewModel.isValidFinanceData = this.formfinancial.valid;
        this.viewModel.isValidModel = this.viewModel.isValidFinanceData && this.viewModel.isValidDocumentPrice

      })
    }
    if (this.formProcurement) {
      this.viewModel.isValidDocumentPrice = this.formProcurement.valid;
      this.formProcurement.form.valueChanges.subscribe(x => {
        this.viewModel.isValidDocumentPrice = this.formProcurement.valid;
        this.viewModel.isValidModel = this.viewModel.isValidFinanceData && this.viewModel.isValidDocumentPrice
      })
    }
    this.viewModel.isValidModel = this.viewModel.isValidFinanceData && this.viewModel.isValidDocumentPrice
  }

  addVendor(formvendor) {
    this.viewModel.clickAddVendor = true;
    if (formvendor.invalid)
      return;
    if (!this.viewModel.item.domainModel.vendors) this.viewModel.item.domainModel.vendors = [];

    this.viewModel.item.domainModel.vendors.push({ vendorName: this.viewModel.item.vendorName, phoneNo: this.viewModel.item.phoneNo, faxNo: this.viewModel.item.faxNo, eMail: this.viewModel.item.eMail });
    this.viewModel.clickAddVendor = false;
    formvendor.reset();
  }

  deleteVendor(index) {
    this.viewModel.item.domainModel.vendors.splice(index, 1)
  }



  onChangeAccountId(event, form) {
    if (event.value) this.viewModel.isValidFinanceData = true;
    this.requisitionService.getAvailableBudget(+event.value.value).subscribe(budget => {
      this.viewModel.item.requisitionBudget = budget;
      this.viewModel.item.requisitionBudget.nodeID = this.viewModel.nodeId;

    })
  }

  onChangeNature(event) {
   
      if (this.viewModel.selectedNature.value == RequisitionNatureEnum.OtherNature) {
        this.viewModel.isValidNature = false;
      }
      console.log("onChangeNature :"+  this.viewModel.isValidNature);
  }

  onChangerequisitionType(event) {
    this.viewModel.item.domainModel.documentsPrice = "";
    if (this.viewModel.isProcurementRole && this.viewModel.selectedRequisitionType && this.viewModel.selectedRequisitionType.value == "T" && !this.viewModel.item.domainModel.documentsPrice) {
      this.viewModel.isValidDocumentPrice = false;
    }

    else
      this.viewModel.isValidDocumentPrice = true;
  }




}



