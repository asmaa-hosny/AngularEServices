import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BaseService } from "./base.service";
import { environment } from "environments/environment";

@Injectable()
export class ITCareService extends BaseService{
    constructor(public _http: HttpClient) {
        super(_http)
        this.serviceName = environment.services.ITCareService;
    }
   
    getCategories() {
        return this._http.get<any>(environment.serverPath + `/api/${this.serviceName}/GetCategories`);
    }

    getSubCategories(categoryId) {
        return this._http.get<any>(environment.serverPath + `/api/${this.serviceName}/${categoryId}/GetSubCategories`);
    }

    getSubItems(subCategoryId) {
        return this._http.get<any>(environment.serverPath + `/api/${this.serviceName}/${subCategoryId}/GetCategorySubItems`);
    }

}