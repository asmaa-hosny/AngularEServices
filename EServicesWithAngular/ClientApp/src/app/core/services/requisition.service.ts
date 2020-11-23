import { Injectable, ViewChild } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "environments/environment";
import { FileUpload } from 'primeng/fileupload';

@Injectable({ providedIn: 'root' })
export class RequisitionService {

    constructor(private _http: HttpClient) { }

    public getProjectTypes() {
        return this._http.get<any[]>(environment.serverPath + `/api/Requisition/GetProjectTypes`);
    }

    public getRequisitionTypes() {
        return this._http.get<any[]>(environment.serverPath + `/api/Requisition/GetRequisitionTypes?isArabic=true`);
    }

    public getAvailableBudget(accountID) {
        return this._http.get<any[]>(environment.serverPath + `/api/Requisition/${accountID}/GetAvailableBudget`);
    }

    public getAccounts() {
        return this._http.get<any[]>(environment.serverPath + `/api/Requisition/GetAccounts`);
    }


    public getRequisitionNature() {
        return this._http.get<any[]>(environment.serverPath + `/api/Requisition/GetRequisitionNature`);
    }


    getAttachments(jobId) {
        return this._http.get(environment.serverPath + `/api/Requisition/${jobId}/GetAttachment`);
    
      }
    public PostRequest(viewModel) {
        let formData = new FormData();
        viewModel.attachementtypes.forEach(type => {
            viewModel[type.fieldName].forEach(attachement => {
                formData.append(type.fieldName, attachement);
            });
        });
        formData.append("requisition", JSON.stringify(viewModel.item));
        return this._http.post<any[]>(environment.serverPath + `/api/Requisition/PostRequest`, formData);
    }
    
    getRequestFields(nodeId) {
        return this._http.get(environment.serverPath + `/api/Requisition/${nodeId}/GetJsonFields`);

    }


    processRequest(viewModel,attachementType) {
        let formData = new FormData();
        attachementType.forEach(type => {
            viewModel[type.fieldName].forEach(attachement => {
                formData.append(type.fieldName, attachement);
            });
        });
     

        formData.append("requisition", JSON.stringify(viewModel.item));

        return this._http.put(environment.serverPath + `/api/Requisition/ProcessRequest`, formData);

    }

    getRequest(jobId, nodeId, Epc) {
        // if(isReviewMode==true){
        //     return this._http.get(environment.serverPath + `/api/Requisition/ReviewRequest/${jobId}/?nodeId=${nodeId}&epc=${Epc}`);
        // }
        // else
        return this._http.get(environment.serverPath + `/api/Requisition/GetRequest/${jobId}/?nodeId=${nodeId}&epc=${Epc}`);

    }


}