import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "environments/environment";
import { BaseService } from "./base.service";

@Injectable()
export class SPSiteCreationService extends BaseService {

    constructor(public _http: HttpClient) {
        super(_http)
        this.serviceName = environment.services.SPSiteCreationService;
    }
}