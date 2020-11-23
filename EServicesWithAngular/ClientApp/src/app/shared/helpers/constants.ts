
export class Constants {
    public static get HOME_URL()
        : string { return "sample/url/"; };

    public static readonly tabListcount=3;

    public static readonly MY_PUBLIC_CONSTANT = 10;

    public static readonly tabIconListEservice: Array<any> = ['picture_in_picture', 'contact_mail', 'fingerprint'];

    public static readonly tabIconListTasks: Array<any> = ['add_comment', 'blur_on', 'archive'];

    public static readonly tabNameList: Array<any> = ['Dashboard.Upcomming', 'Dashboard.Pending', 'Dashboard.History'];

    public static readonly eserviceNameList: Array<any> = ['Dashboard.EServices', 'Dashboard.CTS', 'Dashboard.Hadir'];

    public static readonly teamColumns: Array<any> = [
        { name: 'documentno', label: 'ID' },
        { name: 'requesterName', label: 'Name' },
        { name: 'requestType', label: 'Type' },
        { name: 'from', label: 'From' },
        { name: 'to', label: 'To' }
    ];

    public static readonly poColumns: Array<any> = [
        { name: 'description', label: 'ProjectTitle' },
        { name: 'vendorName', label: 'Vendor' },
       // { name: 'docstatus', label: 'Status' },
        { name: 'purchaseOrderAmount', label: 'Amount' },
        { name: 'purchaseOrderRemainingAmount', label: 'RemainingAmount' },
        { name: 'purchaseOrderPaidPercent', label: 'PaidPercentage' }
      
    ];

    public static readonly poInvoicesColumns: Array<any> = [
        { name: 'projectTitle', label: 'ProjectTitle' },
        { name: 'vendorName', label: 'Vendor' },
        { name: 'docstatus', label: 'Status' },
        { name: 'orderId', label: 'PONumber' },
        { name: 'billTotal', label: 'Amount' }


      
    ];

    public static readonly eserviceColumns: Array<any> = [
        { name: 'reF_ID', label: 'REF_ID' },
        { name: 'processName', label: 'ProcessName' },
        { name: 'activityName', label: 'ActivityName' },
        { name: 'employeeName', label: 'EmployeeName' },
        { name: 'assignedTo', label: 'AssignedTo' },
     
        // { name: 'jobSLA', label: 'JobSLA' },
        // { name: 'activitySLA', label: 'ActivitySLA' },
    ];

        public static readonly myRequestsColumns: Array<any> = [
        { name: 'reF_ID', label: 'REF_ID' },
        { name: 'procesS_NAME', label: 'ProcessName' },
        { name: 'currentStage', label: 'Stage' },
        { name: 'joB_STATUS', label: 'Status' },
        { name: 'request_Date', label: 'Created' },

    ];


    public static readonly colItCare: Array<any> = [
        { name: 'reF_ID', label: 'REF_ID' },
        { name: 'processName', label: 'ProcessName' },
        { name: 'currentLocation', label: 'Stage' },
        { name: 'status', label: 'Status' },
        { name: 'created', label: 'Created' },
        // { name: 'short_description', label: 'Description' },

    ];

    public static readonly haderColumns: Array<any> = [
        { name: 'startDate', label: 'StartDate' },
        { name: 'endDate', label: 'EndDate' },
        { name: 'duration', label: 'Duration' },
      //  { name: 'employeeName', label: 'EmployeeName' },
       
    ];

    public static readonly ctsColumns: Array<any> = [
        { name: 'id', label: 'Id' },
        { name: 'requester', label: 'EndDate' },
        { name: 'brief', label: 'Duration' },
      //  { name: 'employeeName', label: 'EmployeeName' },
       
    ];

    public static readonly requests: Array<any> = [
        { name: 'documentno', label: 'ID' },
        { name: 'requestType', label: 'Type' },
        { name: 'from', label: 'From' },
        { name: 'to', label: 'to' },
    ];


    public static get tabcolList(): any {
        return [
            { colList: this.requests },
            { colList: this.requests },
            { colList: this.requests },

        ];
    }

    public static get tabcolEserviceList(): any {
        return [
            { colList: this.eserviceColumns },
            { colList: this.ctsColumns },
            { colList: this.haderColumns },

        ];
    }

   


}