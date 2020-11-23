import { Injectable, ViewChild } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "environments/environment";
import { FileUpload } from 'primeng/fileupload';

@Injectable( { providedIn: 'root'})
export class AttachementService {
 
  constructor(private _http: HttpClient) { }


  uploadAttachments(jobId, files) {

    let formData = new FormData();

    for (var i in files) {
      formData.append("files", files[i]);
    }

    return this._http.post(environment.serverPath + `/api/ Attachement/${jobId}/UploadAttachments`, formData);

  }


 


  UploadAttachmentWithMetadata(jobId,files,dto) {
    let formData = new FormData();
    for (var i in files) {
      formData.append("files", files[i]);
    }
    return this._http.post(environment.serverPath + `/api/ Attachement/${jobId}/UploadAttachmentWithMetadata`, formData,dto);

  }

  getAttachmentsWithMetadata(jobId,requestType) {
    return this._http.get(environment.serverPath + `/api/ Attachement/${jobId}/GetAttachmentWithMetadata?requestType=${requestType}`);

  }

}
