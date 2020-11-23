import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { HttpClient } from "@angular/common/http";
import { environment } from "environments/environment";
import { BaseService } from "./base.service";

@Injectable()
export class ItResignationService extends BaseService {

    constructor(public _http: HttpClient) {
        super(_http)
        this.serviceName = environment.services.ItResignationService;
    }


    getResignedEmployee(email:string) {
        return this._http.get(environment.serverPath + `/api/${this.serviceName}/GetResignedEmployee/${email}`);
    }
}