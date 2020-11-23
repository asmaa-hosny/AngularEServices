import { async } from '@angular/core/testing';
import { Component, OnInit, Injector } from '@angular/core';
import { SiteCreationViewModel } from 'app/model/sitecreation.model';
import { BaseComponent } from 'app/core/componenet/base.component';
import { Params } from '@angular/router';
import { EventType, Permissions, WorkQueueEnum, Types } from 'app/shared/helpers/enum';
import { SPSiteCreationService } from 'app/core/services/spsitecreation.service';


@Component({
  selector: 'app-sitecreation',
  templateUrl: './sitecreation.component.html',

})
export class SiteCreationComponent extends BaseComponent implements OnInit  {
  viewModel: SiteCreationViewModel = new SiteCreationViewModel();
  constructor(public injector: Injector,
      public sPSiteCreationService: SPSiteCreationService) {
        super(injector);}
       PermissionItem;
       ComponentItem;
       i=0;

  ngOnInit() {
    super.ngOnInit();
    this.viewModel.jobId = 0;
    this.viewModel.isNewMode = true;
    this.viewModel.isEnglish = this.localizationService.isEnglish;
    this.viewModel.permissions = this.utilityService.getEnumList(Permissions);
    this.viewModel.types = this.utilityService.getEnumList(Types);
    


    this.route.queryParamMap.subscribe((response: Params) => {
      if (response && response.keys && response.keys.length > 0) {
        this.viewModel.jobId = response.params.jobid;
        this.viewModel.nodeId = +response.params.nodeid;
        this.viewModel.epc = response.params.epc;
        this.viewModel.reviewMode = response.params.reviewMode;
      }
      this.sPSiteCreationService.getRequestFields(this.viewModel.nodeId).subscribe(response => {
        this.viewModel.fields = response;
        this.viewModel.item.requester = this.baseEmployee;
        //this.viewModel.memberEamilIsEditable = this.viewModel.fields.find(x => x.fieldName === "groupMembers" && x.editable);
        console.log("fildes", this.viewModel.fields);
     })

      if ((this.viewModel.jobId && this.viewModel.reviewMode) || (this.viewModel.jobId && this.viewModel.nodeId > 0)) {
        this.viewModel.isNewMode = false;
        this.loadRequestData();
      }
    });


}
  async loadRequestData() {
  this.viewModel.item = await this.sPSiteCreationService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc,this.viewModel.reviewMode).toPromise(); 
      
      this.baseEmployee = this.viewModel.item.requester ;
      this.viewModel.item.jobID = this.viewModel.jobId;
      this.viewModel.item.nodeID = this.viewModel.nodeId;
      if(this.viewModel.item.nodeID == 226){
        this.viewModel.isSPAdminNode = true;}
      this.viewModel.membersItems =this.viewModel.item.membersList; 
     // this.viewModel.componentsItems =this.viewModel.item.listsAndLibraries; 
      this.viewModel.isNewMode = false;
      console.log(this.viewModel.jobId && !this.viewModel.isNewMode)
      this.processRequest();
    
  }
  processRequest() {
    const subscribtion = this.dataService.getMessage(EventType.DecisionSelected, this.viewModel.item.jobID,this.viewModel.item.nodeID).subscribe(
      async response => {
        this.viewModel.item.managerDecision = {};
        this.viewModel.item.managerDecision.id = response.id;
        this.viewModel.item.managerDecision.comment = response.comment;
        this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
        this.viewModel.item.requester.employeeName = this.baseEmployee.employeeNameAr;
        this.viewModel.item.domainModel.membersList=this.viewModel.membersItems;
        this.viewModel.item.listsAndLibraries=this.viewModel.componentsItems;

       // this.viewModel.item.domainModel.iTSPSiteListsAndLibraries=this.viewModel.componentsItems;
        this.viewModel.item.jobID = this.viewModel.jobId;
        this.viewModel.item.nodeID = this.viewModel.nodeId;
        this.sPSiteCreationService.processRequest(this.viewModel.item).subscribe(response=>{
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
    this.viewModel.showMemberDialog= true;
  }
  showDialogForAddNewComponent(){
    this.viewModel.showComponentDialog= true;
  }
  addNewMember(requestForm){
    if(!this.MemberisExist() && !requestForm.invalid)
    {
    this.viewModel.members.permission = this.viewModel.selectedPermission.text;
    this.viewModel.members.permissionID = this.viewModel.selectedPermission.value;
    this.viewModel.membersItems.push(this.viewModel.members);
    this.viewModel.showMemberDialog= false;
    this.clearMemberItem();}
  }
  addNewComponent(requestForm){
    
    this.viewModel.components.type = this.viewModel.selectedType.text;
    this.viewModel.components.typeID = this.viewModel.selectedType.value;
    this.viewModel.componentsItems.push(this.viewModel.components);
    this.viewModel.showComponentDialog= false;
    this.clearComponentItem();
  }

  cancel(dialogName){
    
    if(dialogName == "Member"){
    this.clearMemberItem();
    this.viewModel.showMemberDialog= false;
    this.viewModel.showAddButton=true;}
    else if (dialogName == "Component"){
    this.clearComponentItem();
    this.viewModel.showComponentDialog= false;
    this.viewModel.showAddButton=true;

    }
  }

  clearMemberItem(){
    this.viewModel.members={memberEmail:null , permission : null , isAdmin : false , permissionID : 0};
  
  }

  clearComponentItem(){
    this.viewModel.components={name:null , type : null , typeID : 0};
  
  }
  view(index){
    if(!this.viewModel.isNewMode)
    {
    this.viewModel.selectedPermission = this.utilityService.getItemByIndex(this.viewModel.membersItems[index].permissionID, this.viewModel.permissions);
    }
    else{ this.viewModel.members.permission=this.viewModel.membersItems[index].permission;}
    this.viewModel.members.memberEmail=this.viewModel.membersItems[index].memberEmail;
    this.viewModel.members.isAdmin=this.viewModel.membersItems[index].isAdmin;
    this.viewModel.selectedMemberID=index;
    this.viewModel.showAddButton=false;
    this.viewModel.showMemberDialog= true;

  }
  viewComponent(index){
    if(!this.viewModel.isNewMode)
    {    this.viewModel.selectedType=this.utilityService.getItemByIndex(this.viewModel.componentsItems[index].typeID, this.viewModel.types);
    }
    else
    {    this.viewModel.components.type=this.viewModel.componentsItems[index].type;
    }
    this.viewModel.components.name=this.viewModel.componentsItems[index].name;
    this.viewModel.components.type=this.viewModel.componentsItems[index].type;
    this.viewModel.selectedComponentID=index;
    this.viewModel.showAddButton=false;
    this.viewModel.showComponentDialog= true;

  }
  delete(index , dialogName){
    if(dialogName == "Member"){
    if(this.viewModel.membersItems[index].isAdmin == true){
    this.viewModel.isAdminSelected = false;
    }
    this.viewModel.membersItems.splice(index,1);
    }
    else if (dialogName == "Component")
    {
      this.viewModel.componentsItems.splice(index,1);
    }
  }
  update()
  {
    if(!this.MemberisExist())
    {
    this.viewModel.membersItems.splice(this.viewModel.selectedMemberID,1);
    this.viewModel.membersItems.push(this.viewModel.membersItems);
    this.viewModel.showUpdateMember=false;
    this.viewModel.showMemberDialog= false;
    this.clearMemberItem();
    }
  }

  

  MemberisExist()
  {
   if((this.viewModel.members.memberEmail!=null&&this.viewModel.members.memberEmail!="")){
   if((this.viewModel.membersItems.findIndex(item=>item.memberEmail==this.viewModel.members.memberEmail))!==-1){
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

  onChangeIsAdmin(event){
    if (event == true){
      this.viewModel.isAdminSelected = true;
    }
    else{this.viewModel.isAdminSelected = false;}
  }

  
  submit(form) {
    if (form && form.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }

    this.viewModel.submitted = true;
    this.viewModel.submitRequestForm = true;
    this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
    
    this.viewModel.item.membersList=this.viewModel.membersItems;
   // this.viewModel.item.listsAndLibraries=this.viewModel.componentsItems;

    
    this.sPSiteCreationService.postRequest(this.viewModel.item).subscribe((resp: any) => {
      this.translate.get('Message.DataSaved').subscribe((res: string) => {
        this.toastr.success(res);
        this.viewModel.isNewMode = false;
        this.viewModel.tabnumber = 2;
      });
     
    });
    this.router.navigate(['/employees/wq'], { queryParams: { tab: WorkQueueEnum.SubmitRequest } });

  }

}
