import { environment } from "environments/environment";
import { BaseModel } from "./base-model";

export class RequisitionViewModel  extends BaseModel{
   
    projectTypes;
    requisitionNatures ;
    requisitionTypes;
    accounts;
    selectedAccount: any = [];;
    selectedRequisitionType: any = [];
    selectedProjectType: any = [];
    selectedNature: any = [];
    isFinanceRole;
    isProcurementRole;
    invalidstartDate = false; 
    startDateValue: any;
    endDateValue: any; 
    attachementtypes; 
    clickAddVendor = false;
    isRequiredAttachementIsValid = false;  
    // attachementData;
    // attachementListName;
    canAddEditVendor=true;
    scopeOfWorkAR: any[] = [];
    quantitiesAndCostBrakedownTableAR: any[] = [];
    implementationAndPaymentTimetableAR: any[] = [];
    projectApprovalInTheBudgetForm: any[] = [];
    others: any[] = [];
    requisitionBudget;
    isValidDocumentPrice=true;
    isValidFinanceData=true;
    isValidNature=true;
    pattern
   
    

  }