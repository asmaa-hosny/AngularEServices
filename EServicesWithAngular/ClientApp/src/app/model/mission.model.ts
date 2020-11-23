import { environment } from "environments/environment";
import { BaseModel } from "./base-model";

export class MissionViewModel  extends BaseModel{

    empMissions ;
    selectedEmpMission={};
    startDateValue: any;
    endDateValue: any;
    completionDateValue ;
    isReportNeeded=false;
    displayEarlySection=false;
    isPayrollVisible=false;
}

