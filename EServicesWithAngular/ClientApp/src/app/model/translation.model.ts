import { BaseModel } from "./base-model";
import { environment } from "environments/environment";

export class TranslationViewModel extends BaseModel {

    noOfWords: any;
    enToAr: any; 
    selectedRequestType;
    notes:any;
    assignedTo:any;
    employeeEmail:any;
    uploadedFilesarr: any[] = [];
    translators ;
    instructionsAR;
    instructionsEN;
    showENToAR = false;
    requestTypes;
    statusList=[];
    showAssignedTo=false;
    showManagerNotes = false;
    allowedAttachmentExtensions: any = environment.file.AllowedTranslationAttachementExtensions;
    bindAssignedTo = false;
    attachmentisRequired = false;
    pendingRequests;
    PendingInstructionRequest;
    radioIsEditable = true;
    attachement: any[] = [];
    isAgreed = false;
}