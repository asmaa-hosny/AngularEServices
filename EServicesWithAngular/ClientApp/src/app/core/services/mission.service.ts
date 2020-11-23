import { Injectable, ViewChild } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "environments/environment";
import { FileUpload } from 'primeng/fileupload';

@Injectable({ providedIn: 'root' })
export class MissionService {

    constructor(private _http: HttpClient) {

    }

    getEmployeeMissions(employeeId) {
        return this._http.get(environment.serverPath + `/api/MissionCompletion/GetEmployeeMissions/${employeeId}`);

    }

    getRequestFields(nodeId) {
        return this._http.get(environment.serverPath + `/api/MissionCompletion/${nodeId}/GetJsonFields`);

    }

    getAttachments(jobId) {
        return this._http.get(environment.serverPath + `/api/MissionCompletion/${jobId}/GetAttachment`);
    
      }
    public PostRequest(viewModel) {
        let formData = new FormData();
        viewModel.attachementtypes.forEach(type => {
            if(viewModel[type.fieldName])
            viewModel[type.fieldName].forEach(attachement => {
                formData.append(type.fieldName, attachement);
            });
        });
        formData.append("mission", JSON.stringify(viewModel.item));
        return this._http.post<any[]>(environment.serverPath + `/api/MissionCompletion/PostRequest`, formData);
    }

    public getHistory(jobId) {
        return this._http.get<any[]>(environment.serverPath + `/api/MissionCompletion/getWorkflowHistory/${jobId}`);
    }

    processRequest(viewModel) {
        let formData = new FormData();
        viewModel.attachementtypes.forEach(type => {
            if(viewModel[type.fieldName])
            viewModel[type.fieldName].forEach(attachement => {
                formData.append(type.fieldName, attachement);
            });
        });
        //formData.append('attachement',  viewModel.item['attachement']);
        formData.append("mission", JSON.stringify(viewModel.item));

        return this._http.put(environment.serverPath + `/api/MissionCompletion/ProcessRequest`, formData);

    }

    recalculateMission(viewModel) {
        return this._http.put(environment.serverPath + `/api/MissionCompletion/RecalculateMission`, viewModel.item);

    }

    getRequest(jobId, nodeId, Epc) {
        return this._http.get(environment.serverPath + `/api/MissionCompletion/GetRequest/${jobId}/?nodeId=${nodeId}&epc=${Epc}`);
    }
}
