import { environment } from "environments/environment";
export class BaseModel {

    isValidModel = true;
    empId;
    employee: any = {};
    nodeId = 0;
    jobId;
    isNewMode = true;
    epc;
    submitted = false;
    item: any = { domainModel: {} };
    calendarFormat = environment.dateFormat.calendarDate;
    allowedAttachmentExtensions: any = environment.file.AllowedAttachmentExtensions;
    allowedFileSize: any = environment.file.AllowedFileSize * 10000000;
    invalidAttachmentExtenstionSummary: any = "";
    InvalidAttachmentExtenstionDetail: any = "";
    emailPattern: string = environment.patterns.emailPattern;
    submitClicked = false;
    isSubmitting
    isNew = true;
    uploadedFilesarr: any[] = [];
    tabnumber = 2;
    submitRequestForm = false;
    decisions
    fields;
    isEnglish;
    attachementtypes
    attachementData;
    attachementListName;
    isRequiredAttachementIsValid = true;
    isValid = true;
    pageSize = environment.pager.pageSize;
    pageLinks: number = environment.pager.pageLinks;
    rowsPerPageOptions = environment.pager.rowsPerPageOptions;
    reviewMode=false;
}