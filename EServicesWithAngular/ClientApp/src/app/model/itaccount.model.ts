import { BaseModel } from "./base-model";
import { environment } from "environments/environment";

export class ITAcountViewModel extends BaseModel {

startDateValue: any;
endDateValue: any; 
invalidstartDate
IsWithEmailIsnotEditable = false;
englishOnly : string = environment.patterns.englishOnly;


}