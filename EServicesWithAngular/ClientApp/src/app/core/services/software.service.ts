import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { HttpClient } from "@angular/common/http";
import { environment } from "environments/environment";
import { BaseService } from "./base.service";

@Injectable()
export class SoftwareService extends BaseService {

    constructor(public _http: HttpClient) {
        super(_http)
        this.serviceName = environment.services.SoftwareService;
    }


    getSoftwareCategories(){
            return this._http.get(environment.serverPath + `/api/${this.serviceName}/GetSoftwareCategories`);
    }
    
    getSoftwareAppsFromCategoryID(SelectedCategoryId){
        return this._http.get(environment.serverPath + `/api/${this.serviceName}/GetSoftwareAppsFromCategoryID/${SelectedCategoryId}`);
    }

    getRequestHistory(){
        return this._http.get(environment.serverPath + `/api/${this.serviceName}/GetRequestHistory`);
    }

}