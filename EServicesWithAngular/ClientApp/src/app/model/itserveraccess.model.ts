import { BaseModel } from "./base-model";
import { SyncAsync } from "@angular/compiler/src/util";
import { constructor } from "jquery";
import { environment } from "environments/environment";


export class ITServerAccessViewModel extends BaseModel {

startDateValue: any;
endDateValue: any; 
invalidstartDate= false;
serverDetailsItems:any[]=[];
serverDetailItem={serverName:null,serverIP:null,isAdmin:false};
selectedServerID:any;
showUpdateServer=false;
showServerDetailsDialog: any;
serverDetailItemExist=false;
invalidserverDetail=false;
atLeastOne=false;
editable=true;
englishOnly : string = environment.patterns.englishOnly;
}


