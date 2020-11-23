import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';


@Injectable()
export class EmployeeService {


    constructor(public _http: HttpClient) { }

    public getEmployees() {
        return this._http.get<any[]>(environment.serverPath + `/api/Dashboard/GetEmployees`);
    }
    
    public getCurrentEmployee(getAD:boolean=false) {
        return this._http.get<any[]>(environment.serverPath + `/api/Employee/getCurrentEmployee?getAD=${getAD}`);
    }

   


}