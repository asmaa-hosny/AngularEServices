import { components } from './../area/employee/identification-letter/identification-routing-module';
import { BaseModel } from "./base-model";

export class SiteCreationViewModel extends BaseModel {

    membersItems:any[]=[];
    members={memberEmail:null , permission : null , isAdmin : false , permissionID : 0 };
    componentsItems : any[] =[];
    components = {name : null , type: null , typeID : 0};
    showMemberDialog = false;
    selectedMemberID;
    selectedComponentID;
    showUpdateMember = false;
    showAddButton = true;
    memberEmailItemExist = false;
    invalidMemberEmail=false;
    memberEamilIsEditable = false;
    permissions;
    types;
    selectedPermission;
    selectedType;
    showComponentDialog = false;
    isAdminSelected = false;
    isSPAdminNode = false;



}