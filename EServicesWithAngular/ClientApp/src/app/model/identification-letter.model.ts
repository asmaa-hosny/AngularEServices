import { BaseModel } from "./base-model";

export class IdentificationViewModel extends BaseModel {

  requestTypes;
  selectedRequestType
  signatureTypes;
  selectedsignatureType;
  types;
  type;
  attItem: any = [];
  selectedval = {};
  uploadedFilesarr: any[] = [];
}