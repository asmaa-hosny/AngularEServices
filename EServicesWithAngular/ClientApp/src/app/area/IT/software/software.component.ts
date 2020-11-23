 
import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from 'app/core/componenet/base.component';
import { environment } from 'environments/environment';
import { SoftwareViewModel } from 'app/model/software.model';
import { SoftwareService } from 'app/core/services/software.service';
import { Params } from '@angular/router';
import { EventType, ITStatusEnum,ITSolutionsStatus, SoftwareRequestType, WorkQueueEnum } from 'app/shared/helpers/enum';

@Component({
  selector: 'app-software',
  templateUrl: './software.component.html',

})
export class SoftwareComponent extends BaseComponent implements OnInit {
  viewModel: SoftwareViewModel = new SoftwareViewModel();
  flagtype: any;

  constructor(public injector: Injector, public softwareService: SoftwareService) {
    super(injector)
    {}
  }



  ngOnInit() {
    super.ngOnInit();
    this.viewModel.jobId = 0;
    this.viewModel.isNewMode = true;
    this.viewModel.isEnglish = this.localizationService.isEnglish;
    this.viewModel.tabnumber=3;

    //As New Mode
    this.viewModel.requestTypes = this.utilityService.getEnumList(SoftwareRequestType);
    
    this.route.queryParamMap.subscribe((response: Params) => {
      if (response && response.keys && response.keys.length > 0) {
        this.viewModel.jobId = response.params.jobid;
        this.viewModel.nodeId = +response.params.nodeid;
        this.viewModel.epc = response.params.epc;
        this.viewModel.reviewMode = response.params.reviewMode;
      }

      this.softwareService.getRequestFields(this.viewModel.nodeId).subscribe(response => {
        this.viewModel.fields = response;
        this.viewModel.item.requester = this.baseEmployee;
        if(this.viewModel.nodeId==351)
        this.viewModel.editable = true;
      })

      this.LoadSomeData(); 
    });


  }
  LoadSomeData() {
    //Retrive the Other Catogary equal "1"
    this.softwareService.getSoftwareAppsFromCategoryID(1).subscribe(response => {
      this.viewModel.softwareApps = response;
      this.softwareService.getRequestHistory().subscribe(response => {
        this.viewModel.employeeRequestsHistory = response;
        if ((this.viewModel.jobId && this.viewModel.reviewMode) || (this.viewModel.jobId && this.viewModel.nodeId > 0)) {
          this.viewModel.isNewMode = false;
          if(this.viewModel.nodeId==363)
          {
            this.viewModel.statusList = this.utilityService.getEnumList(ITStatusEnum,201,200);
          }
          else
          if(this.viewModel.nodeId==359)
          {
            this.viewModel.statusList = this.utilityService.getEnumList(ITSolutionsStatus);
          }else
          if(this.viewModel.nodeId==351)
          {
            this.viewModel.statusList = this.utilityService.getEnumList(ITStatusEnum,200,200);
          }
          else
          {this.viewModel.statusList = this.utilityService.getEnumList(ITStatusEnum,101,100);}
  
          this.loadRequestData();
        }
      
      });
    });
  }
  async loadRequestData() {

     this.viewModel.item = await this.softwareService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc, this.viewModel.reviewMode).toPromise();
      this.baseEmployee=this.viewModel.item.requester;
      this.viewModel.item.jobID = this.viewModel.jobId;
      this.viewModel.item.nodeID = this.viewModel.nodeId;
      this.viewModel.employeeRequestsHistory = this.viewModel.item.employeeRequestsHistory;
      this.viewModel.iTSoftwareRequestItems=this.viewModel.item.itSoftwareRequestItems;
      this.viewModel.isNewMode = false;
      this.viewModel.selectedRequestType = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.requestType, this.viewModel.requestTypes);
      if (this.viewModel.selectedRequestType.value == <number>SoftwareRequestType.SoftwareContractor) { 
        this.viewModel.contractor=this.viewModel.item.domainModel.itSoftwareContractor;
        this.viewModel.showContractor = true; }
      if (this.viewModel.selectedRequestType === undefined) { this.flagtype = true; }
      else { this.flagtype = false; }
      this.processRequest();
  }

  processRequest() {

    const subscribtion = this.dataService.getMessage(EventType.DecisionSelected, this.viewModel.item.jobID,this.viewModel.item.nodeID).subscribe(
      async response => {
        this.viewModel.iTSoftwareRequestItems.map(x => {
         if (x.status &&(x.status!='Rejected'&& x.status!='ForwardToITGov')) 
          {
            x.status = x.status.value;
          }
        });
        this.viewModel.item.managerDecision = {};
        this.viewModel.item.managerDecision.id = response.id;
        this.viewModel.item.managerDecision.comment = response.comment;
        this.viewModel.item.jobId = this.viewModel.jobId;
        this.viewModel.item.nodeID = this.viewModel.nodeId;
          this.softwareService.processRequest(this.viewModel.item).subscribe((response: any) => {
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
    
     if (form && form.invalid ||this.viewModel.iTSoftwareRequestItems.length<1) {
        this.viewModel.submitRequestForm = true;
        this.viewModel.atLeastOne=true;
        if(this.viewModel.iTSoftwareRequestItems.length>0)
        this.viewModel.atLeastOne=false;
      return;
      }

    if(this.viewModel.showContractor){this.viewModel.item.domainModel.itSoftwareContractor=this.viewModel.contractor;}
    this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
    this.viewModel.item.domainModel.requestType = this.viewModel.selectedRequestType.value;
    this.viewModel.item.itSoftwareRequestItems=this.viewModel.iTSoftwareRequestItems;
    this.softwareService.postRequest(this.viewModel.item).subscribe((resp: any) => {
      this.viewModel.submitClicked = true;
      this.translate.get('Message.DataSaved').subscribe((res: string) => {
        this.toastr.success(res);
      });
      this.viewModel.isNewMode = false;
      this.viewModel.tabnumber = 3;
    });
    this.router.navigate(['/employees/wq'], { queryParams: { tab: WorkQueueEnum.SubmitRequest } });

  }

  getRequestHistory(){

    this.softwareService.getRequestHistory().subscribe(response => {
      this.viewModel.employeeRequestsHistory = response;
    })

  }
  onChangeRequestType(event) {

    if (event.value.value == <number>SoftwareRequestType.SoftwareContractor) {
      this.viewModel.showContractor = true;
      this.flagtype = false;
    }
    else {
      this.viewModel.showContractor = false;
      this.flagtype = false;
    }
  }
  appChecker(event) {

    if (event.value.requiresLicense == 1) {
      this.viewModel.showNeedIsDoneOn = true;
      
    }
    else {
      this.viewModel.showNeedIsDoneOn = false;
      
    }
    if(event.value.appName == "Other"){

      this.viewModel.showOtherFileds = true;

    }
    else {
      this.viewModel.showOtherFileds = false;
      
    }
    this.viewModel.softwareItem.needIsDoneOn=null;
    this.viewModel.softwareItem.justification=null;
    this.viewModel.softwareItem.link=null;
    this.viewModel.otherappName=null;
    this.viewModel.invalidsoftwareItem=false;
    this.viewModel.softwareItemExist=false;
  }
  addSoftwareItem()
  {
     this.viewModel.softwareItem.appName=this.viewModel.application;
    if(!this.softwareItemExist())
    {   
        this.viewModel.softwareItem.needIsDoneOn=this.utilityService.convertToApiDate(this.viewModel.softwareItem.needIsDoneOn);
        this.viewModel.iTSoftwareRequestItems.push(this.viewModel.softwareItem);
        
         this.viewModel.iTSoftwareRequestItems.map(x => {

        if (x.appName && x.appName.appName) {
          x.appID= x.appName.id;
          x.appName = x.appName.appName;
          if(x.appName=="Other")
          x.appName=this.viewModel.otherappName;
        }
      });
      this.clearSoftwareItem();
    }
  }

  softwareItemExist()
 {
    if(this.viewModel.softwareItem.appName==null)
    {
      this.viewModel.invalidsoftwareItem=true;
      return true;
    }
    if(this.viewModel.showNeedIsDoneOn)
    {
    if(this.viewModel.softwareItem.needIsDoneOn==null)
      {    this.viewModel.reqiredNeedIsDoneOn=true;
        return true;
      }
    }
    if(this.viewModel.showOtherFileds){
      
      if(this.viewModel.softwareItem.justification==null||this.viewModel.softwareItem.link==null||this.viewModel.otherappName==null)
      {
        this.viewModel.reqiredOtherFileds=true;
        return true;
      }

    }
    if(this.viewModel.softwareItem.appName.appName!="Other")
    {
   
      if((this.viewModel.iTSoftwareRequestItems.findIndex(item=>item.appName==this.viewModel.softwareItem.appName.appName))!==-1)
      {
        this.viewModel.softwareItemExist=true;
      return true;
      }
      else {
        this.viewModel.softwareItemExist=false;
        return false;
     }


   }else{
    if((this.viewModel.iTSoftwareRequestItems.findIndex(item=>item.appName==this.viewModel.otherappName))!==-1)
    {
      this.viewModel.softwareItemExist=true;
    return true;
    }
    else {
      this.viewModel.softwareItemExist=false;
      return false;
   }
    
   }

 }

 clearSoftwareItem(){
  this.viewModel.softwareItem={appID:null,needIsDoneOn:null,appName:null,justification:null,link:null,categoryName_En:null};

  this.viewModel.softwareItemExist=false;
  this.viewModel.reqiredNeedIsDoneOn=false;
  this.viewModel.reqiredOtherFileds=false
  this.viewModel.showNeedIsDoneOn=false;
  this.viewModel.invalidsoftwareItem=false;
  this.viewModel.otherappName=null;

  }
  deleteSoftwareItem(index){
    this.viewModel.iTSoftwareRequestItems.splice(index,1);
  }

}


