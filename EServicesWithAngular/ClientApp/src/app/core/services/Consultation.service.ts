import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { HttpClient } from "@angular/common/http";
import { environment } from "environments/environment";
import { BaseService } from "./base.service";
import { UtilityService } from "./utility.service";

@Injectable()
export class ConsultationService extends BaseService {

    constructor(public _http: HttpClient,public utilityService:UtilityService) {
        super(_http)
        this.serviceName = environment.services.ConsultationService;
    }

    getUniversitiesList(){
      
     return this._http.get(environment.serverPath + `/api/${this.serviceName}/GetUniversity`); 

    }

   //Update
    patchConsultationRequest(model) {
        //You should have name with PatchConsultationData in ConsultationController
    var patchAray = this.utilityService.getPatchArray(model);
        return this._http.put(environment.serverPath + `/api/${this.serviceName}/PatchConsultationData`,model); 
    }

    PostConsultationRequest(model) {
       //You should have name with PostConsultationData in ConsultationController
        return this._http.post(environment.serverPath + `/api/${this.serviceName}/PostConsultationData`,model); 
    }

    getFellowsList(selectedUniversity){
      
        return this._http.get(environment.serverPath + `/api/${this.serviceName}/${selectedUniversity}/GetFellow`); 
   
       }

       getAreasList(fellowEmail){
      
        return this._http.get(environment.serverPath + `/api/${this.serviceName}/${fellowEmail}/GetArea`); 
   
       }

       getConsultationRequestsHistory(employeeEmail){
        return this._http.get(environment.serverPath + `/api/${this.serviceName}/${employeeEmail}/GetConsultationRequestsHistory`); 

       }

       checkAvailabilty(consultantEmail , startDate, endDate , duration){
        return this._http.get(environment.serverPath + `/api/${this.serviceName}/${consultantEmail}/${startDate}/${endDate}/${duration}/CheckConsultantAvailabilty`); 

       }

       getRating(consultantEmail)
       {
        return this._http.get(environment.serverPath + `/api/${this.serviceName}/${consultantEmail}/GetConsultantRating`); 

       }
}