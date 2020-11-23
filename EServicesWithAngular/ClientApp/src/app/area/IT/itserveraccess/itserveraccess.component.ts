import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { BaseComponent } from 'app/core/componenet/base.component';
import { ITServerAccessViewModel } from 'app/model/itserveraccess.model';
import { ItServerAccessService } from 'app/core/services/itserveraccess.service';
import { Params } from '@angular/router';
import { EventType,WorkQueueEnum } from 'app/shared/helpers/enum';
import { ClipboardService } from 'ngx-clipboard';
import { identifierModuleUrl } from '@angular/compiler';
import { Table } from 'primeng/table';
import { Calendar } from 'primeng/calendar';

@Component({
  selector: 'app-itserveraccess',
  templateUrl: './itserveraccess.component.html',

})
export class ITserverAccessComponent extends BaseComponent implements OnInit {
  viewModel: ITServerAccessViewModel = new ITServerAccessViewModel();
  @ViewChild('startDate') startDate: Calendar;
  @ViewChild('endDate') endDate: Calendar;
  constructor(public injector: Injector,
    public itserveraccessService: ItServerAccessService,
  ) {
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
      this.itserveraccessService.getRequestFields(this.viewModel.nodeId).subscribe(response => {
        this.viewModel.fields = response;
        this.viewModel.item.requester = this.baseEmployee;
      })
      
      if ((this.viewModel.jobId && this.viewModel.reviewMode) || (this.viewModel.jobId && this.viewModel.nodeId > 0)) {
        this.viewModel.isNewMode = false;
        if(this.viewModel.nodeId!=461)
         { this.viewModel.editable=false;}
        this.loadRequestData();
      }
      if(this.viewModel.isNewMode){
        this.employeeSevice.getCurrentEmployee().subscribe(empdata => {
        this.viewModel.employee = empdata;
        if(this.viewModel.employee.email)
        this.viewModel.item.domainModel.username = "ENERGY\\\\" +this.viewModel.employee.email.replace("@energy.gov.sa", "");
       this.viewModel.employee =null;
        })}

    });
   
  
  }

  async loadRequestData() {
    this.viewModel.item = await this.itserveraccessService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc,this.viewModel.reviewMode).toPromise();
      this.baseEmployee=this.viewModel.item.requester;
      this.viewModel.item.jobID = this.viewModel.jobId;
      this.viewModel.item.nodeID = this.viewModel.nodeId;
      this.viewModel.startDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateFrom, false);
      this.viewModel.endDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateTo, false);
      this.viewModel.serverDetailsItems=this.viewModel.item.serverDetailsItems;
      this.viewModel.isNewMode = false;
      this.processRequest();
  }

  processRequest() {
    const subscribtion = this.dataService.getMessage(EventType.DecisionSelected,this.viewModel.item.jobID,this.viewModel.item.nodeID).subscribe(
      async response => {
        this.viewModel.item.managerDecision = {};
        this.viewModel.item.managerDecision.id = response.id;
        this.viewModel.item.managerDecision.comment = response.comment;
        this.viewModel.item.jobID = this.viewModel.jobId;
        this.viewModel.item.nodeID = this.viewModel.nodeId;
        this.viewModel.item.domainModel.requiredServersDetails=this.viewModel.serverDetailsItems;
        this.itserveraccessService.processRequest(this.viewModel.item).subscribe((response: any) => {
          this.translate.get('Message.DataSaved').subscribe((response: string) => {
            this.toastr.success(response);
          });
          this.router.navigate(['/employees/wq']);
        });
      }
    )
  }

  changeTab(number, frm) {
    if (frm && frm.invalid ) {
      this.viewModel.submitRequestForm = true;
      return;
    }
    if (number == 3 ) {
      
      this.viewModel.invalidstartDate = this.startDate.value && this.endDate.value && this.endDate.value <= this.startDate.value;
      if (this.viewModel.invalidstartDate) {
        this.viewModel.submitRequestForm = true;
        return;
      }
    }
    this.viewModel.tabnumber = number;
  }

  showDialogForAddNewServer(){
    this.viewModel.showServerDetailsDialog= true;
   
  }
  serverDetailExist()
 {
  if((this.viewModel.serverDetailItem.serverIP!=null&&this.viewModel.serverDetailItem.serverIP!="")&&(this.viewModel.serverDetailItem.serverName!=null&&this.viewModel.serverDetailItem.serverName!="")){
  if((this.viewModel.serverDetailsItems.findIndex(item=>item.serverName==this.viewModel.serverDetailItem.serverName))!==-1||(this.viewModel.serverDetailsItems.findIndex(item=>item.serverIP==this.viewModel.serverDetailItem.serverIP))!==-1){
    this.viewModel.serverDetailItemExist=true;
    this.viewModel.invalidserverDetail=false;
   return true;
  }
 }else {
   this.viewModel.invalidserverDetail=true;
   this.viewModel.serverDetailItemExist=false;
  return true;
}
    return false;
 }
  
  addNewServerDetails(form)
  {
    
    if(!this.serverDetailExist())
    {
        this.viewModel.serverDetailsItems.push(this.viewModel.serverDetailItem);
        this.viewModel.showServerDetailsDialog= false;
        this.viewModel.atLeastOne=false;
        this.clearServerDetailItem();
    }

  }

  deleteServerDetails(index){
    this.viewModel.serverDetailsItems.splice(index,1);
  }

  cancel(){
   
    this.clearServerDetailItem();
    this.viewModel.showServerDetailsDialog= false;

  }

  viewServerDetails(index){
    
    this.viewModel.serverDetailItem.serverName=this.viewModel.serverDetailsItems[index].serverName;
    this.viewModel.serverDetailItem.serverIP=this.viewModel.serverDetailsItems[index].serverIP;
    this.viewModel.serverDetailItem.isAdmin=this.viewModel.serverDetailsItems[index].isAdmin;
    this.viewModel.selectedServerID=index;
    if(this.viewModel.editable)
    this.viewModel.showUpdateServer=true;
    this.viewModel.showServerDetailsDialog= true;
    
  }
  updateServerDetails()
  {
    if(!this.serverDetailExist())
    {
    this.viewModel.serverDetailsItems.splice(this.viewModel.selectedServerID,1);
    this.viewModel.serverDetailsItems.push(this.viewModel.serverDetailItem);
    this.viewModel.showServerDetailsDialog= false;
    this.clearServerDetailItem();
    }
  }

  clearServerDetailItem(){
    this.viewModel.serverDetailItem={serverName:null,serverIP:null,isAdmin:false};
    this.viewModel.serverDetailItemExist=false;
    this.viewModel.invalidserverDetail=false;
    this.viewModel.showUpdateServer=false;

  }
  
  submit(form) {
    
    this.viewModel.invalidstartDate = this.startDate.value && this.endDate.value && this.endDate.value <= this.startDate.value;
    if(this.viewModel.serverDetailsItems.length<1){
      this.viewModel.atLeastOne=true;
      this.viewModel.tabnumber = 2;
      if(this.viewModel.serverDetailsItems.length>0)
      this.viewModel.atLeastOne=false;
      return;

    }
    if (form && form.invalid || this.viewModel.invalidstartDate) {
      this.viewModel.submitRequestForm = true;
      
      return;
    }
   

    this.viewModel.item.serverDetailsItems=this.viewModel.serverDetailsItems;
    this.viewModel.submitted = true;
    this.viewModel.submitRequestForm = true;
    this.viewModel.item.domainModel.dateFrom = this.utilityService.convertToApiDate(this.viewModel.startDateValue);
    this.viewModel.item.domainModel.dateTo = this.utilityService.convertToApiDate(this.viewModel.endDateValue);
    this.itserveraccessService.postRequest(this.viewModel.item).subscribe((resp: any) => {
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

}
