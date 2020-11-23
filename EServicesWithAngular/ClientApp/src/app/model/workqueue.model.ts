import { BaseModel } from "./base-model";
import { Constants } from "app/shared/helpers/constants";

export class WorkQueueModel extends BaseModel {
    pendingList: any[];
    colPendingList = Constants.eserviceColumns;
    myrequestsList: any[];
    colName = Constants.eserviceColumns.map(x => x.name);

    colNameMyrequests = Constants.myRequestsColumns.map(x => x.name);
    colRequestsName = Constants.myRequestsColumns;
    
    colItCare = Constants.colItCare;
    colItCareName = Constants.colItCare.map(x => x.name);
    itcareList:any[];
    showMoreDeatils = false;
    selectedItCareCol;
    searchCriteria;
    loading=false;
    timeout=0;

    pocessNameArray: {key: string, value: string}[] = [
        {key: 'SP Site Creation', value: 'spsitecreation'},
        {key: 'Email Group', value: 'emailgroup'},
        {key: 'Account Request', value: 'itaccount'},
        {key: 'AdminTranslation', value: 'translation'},
        {key: 'IT Software Request', value: 'software'},
        {key: 'Server Access', value: 'itserveraccess'},
        {key: 'Consultation', value: 'consultation'},
        {key: 'ConsultationCompletion', value: 'consultationcompletion'},
        {key: 'ITResignation', value: 'itresignation'},

    ]
    
}