import { BaseModel } from "./base-model";
import { environment } from "environments/environment";

export class UcViewModel extends BaseModel {
    employeeEmail;
    requestsTypes;
    selectedRequestType;
    universities;
    consultants;
    requestsHistory;
    areas;
    selectedUniversity;
    uniCost;
    selectedConsultant;
    selectedArea;
    consultantNotinvolvedChecked = false;
    startDateValue;
    endDateValue;
    dateExceeded = false;
    estimatedCost;
    attachement: any[] = [];
    uploadedFilesarr: any[] = [];
    durationlimit; 
    durationlimitExceeded = false;
    Difference_In_Time;
    consultantAvailabilty;
    isAvailable = true;
    remainingDays;
    remainingDaysExceeded  =false;
    profileURL ;
    invalidDate = false;
    invalidInterval = false;


    rating;
    returned;
    researchtypes : {key: number, value: string}[] = [
        {key: 1, value: 'One consultant'},
        {key: 2, value: 'Group of consultants'},
     
    ]



}