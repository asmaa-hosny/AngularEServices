import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from 'app/core/componenet/base.component';
import { ITAcountViewModel } from 'app/model/itaccount.model';
import { ItAccountService } from 'app/core/services/itaccount.service';
import { Params } from '@angular/router';
import { EventType, WorkQueueEnum } from 'app/shared/helpers/enum';
import { ClipboardService } from 'ngx-clipboard';

@Component({
  selector: 'app-itaccount',
  templateUrl: './itaccount.component.html',
})

export class ITAccountComponent extends BaseComponent implements OnInit {
  viewModel: ITAcountViewModel = new ITAcountViewModel();
  constructor(public injector: Injector,
    public itaccountService: ItAccountService,
    public clipboardService: ClipboardService) {
    super(injector);
  }


  ngOnInit() {
    super.ngOnInit();
    this.viewModel.jobId = 0;
    this.viewModel.isNewMode = true;
    this.viewModel.isEnglish = this.localizationService.isEnglish;

    this.route.queryParamMap.subscribe((response: Params) => {
      if (response && response.keys && response.keys.length > 0) {
        this.viewModel.jobId = response.params.jobid;
        this.viewModel.nodeId = +response.params.nodeid;
        this.viewModel.epc = response.params.epc;
        this.viewModel.reviewMode = response.params.reviewMode;
      }
      this.itaccountService.getRequestFields(this.viewModel.nodeId).subscribe(response => {
        this.viewModel.fields = response;
        this.viewModel.item.requester = this.baseEmployee;
        this.viewModel.IsWithEmailIsnotEditable =  this.viewModel.fields.find(x => x.fieldName === "isWithEmail" && !x.editable);

        console.log(this.viewModel.fields);
      })

      if ((this.viewModel.jobId && this.viewModel.reviewMode) || (this.viewModel.jobId && this.viewModel.nodeId > 0)) {
        this.viewModel.isNewMode = false;
        this.loadRequestData();
      }
    });
  }

  async loadRequestData() {
    this.viewModel.item = await this.itaccountService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc,this.viewModel.reviewMode).toPromise();
      
      this.baseEmployee=this.viewModel.item.requester;
      this.viewModel.item.jobID = this.viewModel.jobId;
      this.viewModel.item.nodeID = this.viewModel.nodeId;
      this.viewModel.startDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateFrom, false);
      this.viewModel.endDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateTo, false);
      this.viewModel.isNewMode = false;
      console.log(this.viewModel.jobId && !this.viewModel.isNewMode)
      this.processRequest();
    
  }

  processRequest() {
    const subscribtion = this.dataService.getMessage(EventType.DecisionSelected , this.viewModel.item.jobID,this.viewModel.item.nodeID).subscribe(
      response => {
        this.viewModel.item.managerDecision = {};
        this.viewModel.item.managerDecision.id = response.id;
        this.viewModel.item.managerDecision.comment = response.comment;
        this.viewModel.item.requester.employeeName = this.baseEmployee.employeeNameAr;
        this.viewModel.item.domainModel.employeeID = this.baseEmployee.kacareId;
        this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
        this.viewModel.item.jobID = this.viewModel.jobId;
        this.viewModel.item.nodeID = this.viewModel.nodeId;
        this.itaccountService.processRequest(this.viewModel.item).subscribe((response: any) => {
          this.translate.get('Message.DataSaved').subscribe((response: string) => {
            this.toastr.success(response);
          });
        })
        this.router.navigate(['/employees/wq'], { queryParams: { tab: WorkQueueEnum.SubmitRequest } });
      }
    )
  }

  changeTab(number, frm) {
    if (frm && frm.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }
    console.log(number);
    this.viewModel.tabnumber = number;
  }

  copy() {
    this.clipboardService.copyFromContent(this.viewModel.item.powerShellCodeForAddingNewUser);
    this.translate.get("Message.CopyToClibboard").subscribe((response: string) => {
      this.toastr.success(response);
    })
  }

  submit(form) {
    if (form && form.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }

    this.viewModel.submitted = true;
    this.viewModel.submitRequestForm = true;
    this.viewModel.item.domainModel.employeeID = this.baseEmployee.employeeID;
    this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
    this.viewModel.item.domainModel.dateFrom = this.utilityService.convertToApiDate(this.viewModel.startDateValue);
    this.viewModel.item.domainModel.dateTo = this.utilityService.convertToApiDate(this.viewModel.endDateValue);
    this.itaccountService.postRequest(this.viewModel.item).subscribe((resp: any) => {
      this.viewModel.submitClicked = true;
      //this.viewModel.jobId = resp.jobID;

      this.translate.get('Message.DataSaved').subscribe((res: string) => {
        this.toastr.success(res);
      });
      this.viewModel.isNewMode = false;
      this.viewModel.tabnumber = 2;
    });
    this.router.navigate(['/employees/wq'], { queryParams: { tab: WorkQueueEnum.SubmitRequest } });
  }

}
