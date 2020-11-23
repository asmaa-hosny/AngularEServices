import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';


@Injectable()
export class BaseService {

    protected serviceName: string = environment.services.BaseService;

    constructor(public _http: HttpClient) { }


    getRequest(jobId, nodeId, Epc, reviewMode: boolean = false) {
        if (reviewMode)
            return this.reviewRequest(jobId, nodeId, Epc);
        else
            return this._http.get(environment.serverPath + `/api/${this.serviceName}/GetRequest/${jobId}/?nodeId=${nodeId}&epc=${Epc}`);
    }

    reviewRequest(jobId, nodeId, Epc) {
        return this._http.get(environment.serverPath + `/api/${this.serviceName}/ReviewRequest/${jobId}/?nodeId=${nodeId}&epc=${Epc}`);
    }

    processRequest(viewModel) {
        return this._http.put(environment.serverPath + `/api/${this.serviceName}/ProcessRequest`, viewModel);
    }

    download(url) {
        return this._http.get(environment.serverPath + `/api/base/DownloadAttachment?url=${url}`,{ responseType: "blob"});
    }

    postRequest(viewModel) {
        return this._http.post<any[]>(environment.serverPath + `/api/${this.serviceName}/PostRequest`, viewModel);
    }

    getRequestFields(nodeId): Observable<any[]> {
        return this._http.get<any[]>(environment.serverPath + `/api/${this.serviceName}/${nodeId}/GetJsonFields`);

    }
    public getHistory(jobId) {
        return this._http.get<any[]>(environment.serverPath + `/api/Base/getWorkflowHistory/${jobId}`);
    }


    public cencelRequest(activity, jobId, nodeId) {
        return this._http.post<any[]>(environment.serverPath + `/api/Base/Cancel/${jobId}?${nodeId}`, activity);
    }

    getAttachments(jobId) {
        return this._http.get(environment.serverPath + `/api/${this.serviceName}/${jobId}/GetAttachment`);
    }

    public postRequestWithAttachement(viewModel, modelName) {
        let formData = new FormData();
        viewModel.attachementtypes.forEach(type => {
            if (viewModel[type.fieldName])
                viewModel[type.fieldName].forEach(attachement => {
                    formData.append(type.fieldName, attachement);
                });
        });
        //modelName is the name that you should get from the below line in the  backend
        //  [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "translation")]
        formData.append(modelName, JSON.stringify(viewModel.item));
        return this._http.post<any[]>(environment.serverPath + `/api/${this.serviceName}/PostRequest`, formData);
    }

    public processRequestWithAttachement(viewModel, modelName) {
        let formData = new FormData();

        viewModel.attachementtypes.forEach(type => {
            if (viewModel[type.fieldName])
                viewModel[type.fieldName].forEach(attachement => {
                    formData.append(type.fieldName, attachement);
                });
        });
        formData.append(modelName, JSON.stringify(viewModel.item));
        return this._http.put(environment.serverPath + `/api/${this.serviceName}/ProcessRequest`, formData);

    }







}