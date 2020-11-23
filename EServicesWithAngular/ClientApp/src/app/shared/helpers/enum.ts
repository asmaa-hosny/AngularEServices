

export enum SignatureTypeEnum {
    Manual = 1,
    Automatic = 2,
    
}

export enum IdentificationType {
    WithSalary = <number>1004923,
    WithoutSalary = <number>1004922

  }

  export enum EventType {
    DecisionSelected ,
    EmployeeSelected ,

  }
  export enum ServiceType {
    OneTime  = <number>1,
    Recurring = <number>2,
  }
  export enum Permissions {
    Read = <number>1,
    ReadWrite = <number>2,

  }
  export enum Types {
    Library = <number>1,
    List = <number>2,

  }


  export enum GridTypeEnum {
    Student = <number> 1,
    Eric = <number> 2,
    Fellow = <number> 3,
    Publication = <number> 4,
    Consultation = <number> 5,
}




  

  export enum TranslationType {
    Translation = <number>1,
    Review = <number>2,

  }

  export enum EvaluationAnswers {
    NotApplicable = <number>0,
    StronglyDisagree= <number>1,
    Disagree = <number>2,
    CannotDecide =<number> 3,
    Agree =<number> 4,
    StronglyAgree =<number> 5

  }
  

  export enum Universities {
    KFUPM = "King Fahd University of Petroleum & Minerals",
    KSU ="King Saud University",
    KAU = "King Abdulaziz University",

  }
  export enum Consultants {
    AbdullahAbusorrah = <number>1,
    EssamBanoqitah  = <number>2,
    MohammedAljohani = <number>3,

  }
  export enum TabNumber
     {
     RequestTab = <number>3
     }


  export enum ITStatusEnum {
    Approved =<number>100,
    Rejected =<number>101,
    Executed =<number>200,
    NotExecuted =<number>201,
  }


  export enum RequestType {
    Requisition = 1,
    IdentificationLetter = 2,
    
  }
  
export enum ITSolutionsStatus {
  Approved =<number>100,
  Rejected =<number>101,
  ReturnToEmp = <number>300,
  ForwardToITGov =<number>402,
}

export enum SoftwareRequestType {
  Requester = <number>1,
  SoftwareContractor = <number>2,
  
}
export enum RequisitionNatureEnum {
  OtherNature = 18,
}
 

export enum RoutingName {
  AdminTranslation = "translation",
  EmailGroup = "emailgroup"
}

export enum WorkQueueEnum {
  Pending=<number> 2,
  SubmitRequest=<number> 3,
  ItCare = <number> 4,
}

