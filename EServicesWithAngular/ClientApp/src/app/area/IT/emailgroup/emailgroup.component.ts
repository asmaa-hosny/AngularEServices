import { async } from '@angular/core/testing';
import { filter, map } from 'rxjs/operators';

import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from 'app/core/componenet/base.component';
import { Params } from '@angular/router';
import { EventType, WorkQueueEnum } from 'app/shared/helpers/enum';
import { ClipboardService } from 'ngx-clipboard';
import { EmailGroupViewModel } from 'app/model/emailgroup.model';
import { EmailGroupService } from 'app/core/services/emailgroup.service';



@Component({
    selector: 'app-emailgroup',
    templateUrl: './emailgroup.component.html',
})
export class EmailgroupComponent extends BaseComponent implements OnInit  {
    viewModel: EmailGroupViewModel = new EmailGroupViewModel();
    constructor(public injector: Injector,
        public emailgroupService: EmailGroupService,
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
      this.emailgroupService.getRequestFields(this.viewModel.nodeId).subscribe(response => {
        this.viewModel.fields = response;
        this.viewModel.item.requester = this.baseEmployee;
        this.viewModel.memberEamilIsEditable = this.viewModel.fields.find(x => x.fieldName === "groupMembers" && x.editable);
        console.log("fildes", this.viewModel.fields);
     })

      if ((this.viewModel.jobId && this.viewModel.reviewMode) || (this.viewModel.jobId && this.viewModel.nodeId > 0)) {
        this.viewModel.isNewMode = false;
        this.loadRequestData();
      }
    });


}
  async loadRequestData() {
  this.viewModel.item = await this.emailgroupService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc,this.viewModel.reviewMode).toPromise();
     
      this.baseEmployee=this.viewModel.item.requester;
      this.viewModel.item.jobID = this.viewModel.jobId;
      this.viewModel.item.nodeID = this.viewModel.nodeId;
      this.viewModel.groupMembersItems =this.viewModel.item.groupMember; 
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
        this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
        this.viewModel.item.requester.employeeName = this.baseEmployee.employeeNameAr;
       // this.viewModel.item.groupMember=this.viewModel.groupMembersItems;
         this.viewModel.item.domainModel.groupMembers=this.viewModel.groupMembersItems;
        this.viewModel.item.jobID = this.viewModel.jobId;
        this.viewModel.item.nodeID = this.viewModel.nodeId;
        this.emailgroupService.processRequest(this.viewModel.item).subscribe(response=>{
          this.translate.get('Message.DataSaved').subscribe((response: string) => {
            this.toastr.success(response);
            this.router.navigate(['/employees/wq']);
          });
         });

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
  showDialogForAddNewMember(){
    this.viewModel.showGroupMemberDialog= true;
  }
  addNewMember(requestForm){
    if(!this.MemberisExist() && !requestForm.invalid)
    {
    this.viewModel.groupMembersItems.push(this.viewModel.groupMembers);
    this.viewModel.showGroupMemberDialog= false;
    this.clearGroupMemberItem();}
  }
  cancel(){
   
    this.clearGroupMemberItem();
    this.viewModel.showGroupMemberDialog= false;
  }

  clearGroupMemberItem(){
    this.viewModel.groupMembers={memberEmail:null};
  
  }
  view(index){
    this.viewModel.groupMembers.memberEmail=this.viewModel.groupMembersItems[index].memberEmail;
    this.viewModel.selectedMemberID=index;
    this.viewModel.showUpdateMember=true;
    this.viewModel.showGroupMemberDialog= true;

  }
  delete(index){
    this.viewModel.groupMembersItems.splice(index,1);
  }
  update()
  {
    if(!this.MemberisExist())
    {
    this.viewModel.groupMembersItems.splice(this.viewModel.selectedMemberID,1);
    this.viewModel.groupMembersItems.push(this.viewModel.groupMembers);
    this.viewModel.showUpdateMember=false;
    this.viewModel.showGroupMemberDialog= false;
    this.clearGroupMemberItem();
    }
  }

  copy() {
    this.clipboardService.copyFromContent(this.viewModel.item.powerShellCodeForAddingGroupEmail);
    this.translate.get("Message.CopyToClibboard").subscribe((response: string) => {
      this.toastr.success(response);
    })
  }

  MemberisExist()
  {
   if((this.viewModel.groupMembers.memberEmail!=null&&this.viewModel.groupMembers.memberEmail!="")){
   if((this.viewModel.groupMembersItems.findIndex(item=>item.memberEmail==this.viewModel.groupMembers.memberEmail))!==-1){
     this.viewModel.memberEmailItemExist=true;
     this.viewModel.invalidMemberEmail=false;
    return true;
   }
  }else {
    this.viewModel.invalidMemberEmail=true;
    this.viewModel.memberEmailItemExist=false;
   return true;
 }
     return false;
  }

  
  submit(form) {
    if (form && form.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }

    this.viewModel.submitted = true;
    this.viewModel.submitRequestForm = true;
    this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
    this.viewModel.item.groupMember=this.viewModel.groupMembersItems;
    
    this.emailgroupService.postRequest(this.viewModel.item).subscribe((resp: any) => {
      this.translate.get('Message.DataSaved').subscribe((res: string) => {
        this.toastr.success(res);
        this.viewModel.isNewMode = false;
        this.viewModel.tabnumber = 2;
      });
     
    });
    this.router.navigate(['/employees/wq'], { queryParams: { tab: WorkQueueEnum.SubmitRequest } });

  }

}


