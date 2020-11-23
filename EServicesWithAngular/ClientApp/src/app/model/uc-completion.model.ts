import { BaseModel } from "./base-model";
import { environment } from "environments/environment";

export class UcCompletionViewModel extends BaseModel {

    requestLists;
    consultationRequests;
    consultationRequest;
    selectedRequest;
    actualCost;
    selectedUniversity;
    consultationRequest_ID :any;
    evaluationItems;
    answers;
    comments;
    isTerminated = false;
    rating = 3;
    answersArray: {key: number, value: string}[] = [
        {key: 0, value: 'NotAppli-cable'},
        {key: 1, value: 'Strongly Disagry'},
        {key: 2, value: 'Disagree'},
        {key: 3, value: 'Cannot Decide'},
        {key: 4, value: 'Agree'},
        {key: 5, value: 'Strongly Agree'},
    ]
    
    

}