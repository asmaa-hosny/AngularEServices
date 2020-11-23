export class DashBoardViewModel {
    meetings: any[] = [];
    teamSchedule: any[] = [];
    events: any[] = [];
    options: any;
    eservice: any[] = [];
    haderServices: any[] = [];
    pendingRequests:any[]=[];
    historyRequests:any[]=[];
    mySchedule:any[]=[];
    upcomingRequests:any[]=[];
    ctsService: any[] = [];
    refreshDate: Date;
    min;
    param: any = { min: '0' };
    poInvoices:any[]=[];
    pos
    empCode
    followUpCount:number=0;
    updateInfo;
    eserviceCount: any;
    employeeModel
    haderServiceCount: any;
    ctsServiceCount: any;
    pending: any;
    checkInTime: string;
    attendanceGap: any;
    leaveBalance: any;
    timeRemaining: any;
    nextPrayingTime: any;
    showDashboard = true;
    tabSourceList: Array<any> = [
        { listName: [] },
        { listName: [] },
        { listName: [] },

    ];

    tabcounts: number;
    tabIconListEservices
    tabIconListTasks
    tabNameList
    tabColList
    tabEserviceSourceList:any[] = [];
    tabcolEserviceList
    tabEserviceNameList
    sizeArray;
    sizeEserviceArray: any[] = [];
    teamColumns
    poInvoicesColumns
    poColumns
    employees
    empId = 0;
}