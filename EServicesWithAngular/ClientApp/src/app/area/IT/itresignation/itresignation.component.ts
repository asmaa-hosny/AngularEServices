import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from 'app/core/componenet/base.component';
import { environment } from 'environments/environment';
import { ITResignationViewModel } from 'app/model/resignation.model';
import { ItResignationService } from 'app/core/services/resignation.service';
import { Params } from '@angular/router';
import { ITStatusEnum, EventType, WorkQueueEnum } from 'app/shared/helpers/enum';

@Component({
  selector: 'app-itresignation',
  templateUrl: './itresignation.component.html',

})
export class ITResignationComponent extends BaseComponent implements OnInit {
  viewModel: ITResignationViewModel = new ITResignationViewModel();

  constructor(public injector: Injector, public resignedService: ItResignationService) {
    super(injector)
    { }
  }



  ngOnInit() {

    this.viewModel.jobId = 0;
    this.viewModel.isNewMode = true;
    this.viewModel.isEnglish = this.localizationService.isEnglish;
    this.viewModel.statusList = this.utilityService.getEnumList(ITStatusEnum, 201, 200);
    this.route.queryParamMap.subscribe((response: Params) => {
      if (response && response.keys && response.keys.length > 0) {
        this.viewModel.jobId = response.params.jobid;
        this.viewModel.nodeId = +response.params.nodeid;
        this.viewModel.epc = response.params.epc;
        this.viewModel.reviewMode = response.params.reviewMode;
      }

      this.resignedService.getRequestFields(this.viewModel.nodeId).subscribe(response => {
        this.viewModel.fields = response;
        this.viewModel.item.requester = this.baseEmployee;
      })

      if ((this.viewModel.jobId && this.viewModel.reviewMode) || (this.viewModel.jobId && this.viewModel.nodeId > 0)) {
        this.viewModel.isNewMode = false;
        this.loadRequestData();
      }

    });
  }

  async loadRequestData() {
    this.viewModel.item = await this.resignedService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc, this.viewModel.reviewMode).toPromise();
    this.baseEmployee = this.viewModel.item.requester;
    this.viewModel.item.jobID = this.viewModel.jobId;
    this.viewModel.item.nodeID = this.viewModel.nodeId;
    this.viewModel.itemStatus = this.viewModel.item.itemStatus;
    this.viewModel.isNewMode = false;
    this.processRequest();
  }

  processRequest() {
    const subscribtion = this.dataService.getMessage(EventType.DecisionSelected, this.viewModel.item.jobID,this.viewModel.item.nodeID).subscribe(
      async response => {
        this.viewModel.itemStatus.map(x => {
          if (x.status) {
            x.status = x.status.value
          }
        });
        this.viewModel.item.managerDecision = {};
        this.viewModel.item.managerDecision.id = response.id;
        this.viewModel.item.managerDecision.comment = response.comment;
        this.viewModel.item.jobId = this.viewModel.jobId;
        this.viewModel.item.nodeID = this.viewModel.nodeId;
        this.resignedService.processRequest(this.viewModel.item).subscribe(response=>{
        this.translate.get('Message.DataSaved').subscribe((response: string) => {
          this.toastr.success(response);
        });
        this.router.navigate(['/employees/wq']);
       });
      }
    )
  }
  changeTab(number, frm) {
    if (frm && frm.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }
    this.viewModel.tabnumber = number;
  }


  submit(form) {

    if (form && form.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }

    this.resignedService.postRequest(this.viewModel.item).subscribe((resp: any) => {
      this.viewModel.submitClicked = true;
      this.viewModel.jobId = resp.jobID;

        this.translate.get('Message.DataSaved').subscribe((res: string) => {
        this.toastr.success(res);
      });
      this.viewModel.isNewMode = false;
      this.viewModel.tabnumber = 2;
    });
    this.router.navigate(['/employees/wq'], { queryParams: { tab: WorkQueueEnum.SubmitRequest } });
  }

  getResignedEmployeeinfo() {

    this.resignedService.getResignedEmployee(this.viewModel.item.domainModel.employeeEmail).subscribe(response => {
      this.baseEmployee = response;
      this.baseEmployee.employeeNameAr = this.baseEmployee.employeeNameEn;
    })
  }

}
