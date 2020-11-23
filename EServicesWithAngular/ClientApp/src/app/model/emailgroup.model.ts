import { BaseModel } from "./base-model";
import { environment } from "environments/environment";

export class EmailGroupViewModel extends BaseModel {

    groupMembersItems:any[]=[];
    groupMembers={memberEmail:null};
    showGroupMemberDialog = false;
    selectedMemberID;
    showUpdateMember = false;
    memberEmailItemExist = false;
    invalidMemberEmail=false;
    memberEamilIsEditable = false;


}