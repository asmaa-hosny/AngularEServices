import { Injectable, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class DashboardService {
 

  constructor(public _http: HttpClient) {
   
  }

  requestOptions: Object = {
    /* other options here */
    responseType: 'text'
  }

  public getTasks() {
    return this._http.get<any[]>(environment.serverPath + `/api/Dashboard/GetTasks`);
  }

  public getDashboardData(empId) {
    return this._http.get<any[]>(environment.serverPath + `/api/Dashboard/GetDashboardData/${empId}`,);
    
  }



  public getMeetings() {
    return this._http.get<any[]>(environment.serverPath + `/api/Dashboard/GetMeetings`);
  }

  public GetEServices() {
    return this._http.get<any[]>(environment.serverPath + `/api/Dashboard/GetEServices`);
  }

  public GetMyRequests(searchcriteria) {
    return this._http.post<any[]>(environment.serverPath + `/api/Dashboard/GetMyRequests/`,searchcriteria,{ observe: 'response' });
  }

  public GetItCareRequests() {
    return this._http.get<any[]>(environment.serverPath + `/api/Dashboard/GetITCareRequests/`);
  }

  public GetCTSServices() {
    return this._http.get<any[]>(environment.serverPath + `/api/Dashboard/GetCTSServices`);
  }


  public GetCheckinTime(empId) { 
    return this._http.get<any>(environment.serverPath + `/api/Dashboard/GetCheckinTime/${empId}`);
  }

  public GetHaderRequests(empId) {
    return this._http.get<any[]>(environment.serverPath + `/api/Dashboard/GetHaderRequests/${empId}`);
  }

  public GetAttendanceGap(empId) {
    return this._http.get<any>(environment.serverPath + `/api/Dashboard/GetAttendanceGap/${empId}`);
  }

  public GetTimeRemaining() {
    return this._http.get<any>(environment.serverPath + `/api/Dashboard/GetTimeRemaining`,this.requestOptions);
  }

  public GetLeaveBalance() {
    return this._http.get<any>(environment.serverPath + `/api/Dashboard/GetLeaveBalance`,this.requestOptions);
  }

 
  
  public GetNextPrayingTime() {
    return this._http.get<any[]>(environment.serverPath + `/api/Dashboard/GetNextPrayingTime`,this.requestOptions);
  }

  public FindSubordinates(email) {
    return this._http.get<any[]>(environment.serverPath + `/api/Dashboard/FindSubordinates?email=${email}`);
  }

  public GetTeamAvilability(email) {
    return this._http.get<any[]>(environment.serverPath + `/api/Dashboard/GetTeamAvilability?email=${email}`);
  }
  public GetUpcomingRequests(employeeId) {
    return this._http.get<any>(environment.serverPath + `/api/Dashboard/GetUpcomingRequests/${employeeId}`);
  }
  
  public GetHistoryRequests(employeeId) {
    return this._http.get<any>(environment.serverPath + `/api/Dashboard/GetHistoryRequests/${employeeId}`);
  }

  public GetAllRequests(employeeId) {
    return this._http.get<any>(environment.serverPath + `/api/Dashboard/GetAllSchedule/${employeeId}`);
  }

  public GetPendingRequests(employeeId) {
    return this._http.get<any>(environment.serverPath + `/api/Dashboard/GetPendingRequests/${employeeId}`);
  }

  public GetPoInvoices(employeeId) {
    return this._http.get<any>(environment.serverPath + `/api/Dashboard/GetPOInvoices/${employeeId}`);
  }

  public GetPos(employeeId) {
    return this._http.get<any>(environment.serverPath + `/api/Dashboard/GetPOs/${employeeId}`);
  }

}

