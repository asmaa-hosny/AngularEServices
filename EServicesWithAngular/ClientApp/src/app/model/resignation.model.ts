import { BaseModel } from "./base-model";
import { environment } from "environments/environment";

export class ITResignationViewModel extends BaseModel {

  
   statusList=[];
   itemStatus=[];
   itemStatusToSend:any[]=[];
   selectedStatus={};
}