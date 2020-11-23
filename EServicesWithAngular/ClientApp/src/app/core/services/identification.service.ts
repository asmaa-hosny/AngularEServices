import { Injectable, ViewChild } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "environments/environment";
import { FileUpload } from 'primeng/fileupload';

@Injectable({ providedIn: 'root' })
export class IdentificationService {
  @ViewChild('uploadAttachment') uploadAttachment: FileUpload;
  constructor(private _http: HttpClient) { }


  uploadAttachments(employeeId, files) {

    let formData = new FormData();

    for (var i in files) {
      formData.append("files", files[i]);
    }

    return this._http.post(environment.serverPath + `/api/IdentificationLetter/${employeeId}/UploadAttachments`, formData);

  }

  getRequestFields(nodeId) {
    return this._http.get(environment.serverPath + `/api/IdentificationLetter/${nodeId}/GetJsonFields`);

  }

  getAttachments(employeeId) {
    return this._http.get(environment.serverPath + `/api/IdentificationLetter/${employeeId}/GetAttachment`);

  }


  UploadAttachmentWithMetadata(employeeId, files, dto) {
    let formData = new FormData();
    for (var i in files) {
      formData.append("files", files[i]);
    }
    return this._http.post(environment.serverPath + `/api/IdentificationLetter/${employeeId}/UploadAttachmentWithMetadata`, formData, dto);

  }

  getAttachmentsWithMetadata(employeeId) {
    return this._http.get(environment.serverPath + `/api/IdentificationLetter/${employeeId}/GetAttachmentWithMetadata`);

  }

  getRequest(jobId, nodeId, Epc) {
    return this._http.get(environment.serverPath + `/api/IdentificationLetter/GetRequest/${jobId}/?nodeId=${nodeId}&epc=${Epc}`);

  }

  processRequest(viewModel) {
   

    return this._http.put(environment.serverPath + `/api/IdentificationLetter/ProcessRequest`, viewModel);

}

  public PostRequest(viewModel) {
  

    return this._http.post<any[]>(environment.serverPath + `/api/IdentificationLetter/PostRequest`, viewModel);
}

}
