import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { HttpClient } from "@angular/common/http";
import { environment } from "environments/environment";
import { BaseService } from "./base.service";

@Injectable()
export class ConsultationCompletionService extends BaseService {
    utilityService: any;

    constructor(public _http: HttpClient) {
        super(_http)
        this.serviceName = environment.services.ConsultationCompletionService;
    }
    
    patchConsultationRequest(model) {
        //You should have name with PatchConsultationData in ConsultationController
        this.utilityService.getPatchArray(model);
        return this._http.put(environment.serverPath + `/api/${this.serviceName}/PatchConsultationData`,model); 
    }

        getLists() {
        return this._http.get(environment.serverPath + `/api/${this.serviceName}/GetRequestLists`);

    }

    // getEvaluationItems() {
    //     return this._http.get(environment.serverPath + `/api/${this.serviceName}/GetEvaluationItem`);

   // }


}