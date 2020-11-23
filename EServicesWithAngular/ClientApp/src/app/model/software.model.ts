import { BaseModel } from "./base-model";
import { environment } from "environments/environment";

export class SoftwareViewModel extends BaseModel {

   selectedStatus={};

   statusList=[];
   softwareApps;
   softwareCategories;
   requestTypes;
   showContractor=false;
   selectedRequestType;
   employeeRequestsHistory;
   iTSoftwareRequestItems=[];
   reqiredNeedIsDoneOn=false;
   softwareItemExist=false;
   showNeedIsDoneOn=false;
   showOtherFileds=false;
   invalidsoftwareItem=false;
   atLeastOne=false;
   categoryName_En;
   application;
   otherappName;
   editable =false;
   reqiredOtherFileds=false;
   softwareItem={appID:null,needIsDoneOn:null,appName:null, justification:null,link:null,categoryName_En:null};
   contractor={contractorName:null,contractorEmail:null,contractorPhone:null,contractorCompany:null,contractorProject:null};
   
   
}