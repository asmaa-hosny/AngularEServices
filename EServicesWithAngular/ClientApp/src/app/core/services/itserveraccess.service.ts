import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { HttpClient } from "@angular/common/http";
import { environment } from "environments/environment";
import { BaseService } from "./base.service";

@Injectable()
export class ItServerAccessService extends BaseService {

    constructor(public _http: HttpClient) {
        super(_http)
        this.serviceName = environment.services.ItServerAccessService;
    }



}
