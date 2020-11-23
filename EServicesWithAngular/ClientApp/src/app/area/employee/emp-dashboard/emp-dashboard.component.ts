import { Component, OnInit } from '@angular/core';
import * as Chartist from 'chartist';
import { DashboardService } from 'app/core/services/dashboard.service';
import { Constants } from 'app/shared/helpers/constants';
import { NavbarService } from 'app/core/services/navbar.service';
import { Observable } from 'rxjs';
import { EmployeeService } from 'app/core/services/employee.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { TranslateService, TranslatePipe } from '@ngx-translate/core';
import { TranslateModule } from '@ngx-translate/core';
import { LocalizationService } from 'app/core/services/localization.service';
import { environment } from "environments/environment";
import { Title } from '@angular/platform-browser';
import { Display } from 'app/shared/helpers/display';
import { DecoratorService } from 'app/core/services/decorator.service';
import { DashBoardViewModel } from 'app/model/dashboard-model';
import { DataService } from 'app/core/services/data.service';
import { EventData } from 'app/model/emitEvent';
import { EventType } from 'app/shared/helpers/enum';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction';

@Component({
    selector: 'app-emp-dashboard',
    templateUrl: './emp-dashboard.component.html',
})

export class EmpDashboardComponent implements OnInit {
    environment
    viewModel: DashBoardViewModel = new DashBoardViewModel();

    constructor(public localizationService:
        LocalizationService,public inOutService:DataService,
        public translate: TranslateService,
        public dashboaradService: DashboardService,
        public nav: NavbarService,
        public empService: EmployeeService,
        private spinnerService: NgxSpinnerService) { }


    ngOnInit() {
        this.spinnerService.show();
        this.nav.show();
        this.empService.getCurrentEmployee().subscribe(response => {
            this.viewModel.employeeModel = response;
            this.viewModel.empId = this.viewModel.employeeModel.employeeID;
            this.inOutService.sendMessage(new EventData(EventType.EmployeeSelected,this.viewModel.employeeModel.employeeEmail ));
            this.viewModel.empCode = this.viewModel.employeeModel.empCode;
            this.getServerData();
        });
        this.nav.change.subscribe(empId => {
            this.viewModel.empId = empId;
            this.nav.empId = empId;
        });


        this.viewModel.tabcounts = Constants.tabListcount;
        this.viewModel.tabIconListEservices = Constants.tabIconListEservice;
        this.viewModel.tabIconListTasks = Constants.tabIconListTasks;
        this.viewModel.tabNameList = Constants.tabNameList;
        this.viewModel.tabColList = Constants.tabcolList;
        this.viewModel.tabcolEserviceList = Constants.tabcolEserviceList;
        this.viewModel.tabEserviceNameList = Constants.eserviceNameList;
        this.viewModel.teamColumns = Constants.teamColumns;
        this.viewModel.poInvoicesColumns = Constants.poInvoicesColumns;
        this.viewModel.poColumns = Constants.poColumns;
        this.viewModel.options = {
            plugins:[ dayGridPlugin, timeGridPlugin, interactionPlugin ],
            defaultDate: '2019-01-01',
            header: {
                left: 'prev,next',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },editable: true
        }

        //  this.getServerData();
        setInterval(() => {
            this.viewModel.followUpCount=0;
            this.getServerData();

        }, 500000);

        setInterval(() => {
            console.log("interval time")
            this.getLatestUpdate();

        }, 59000);

    }


    private getServerData() {

        this.dashboaradService.GetTeamAvilability(this.viewModel.employeeModel.email).subscribe(response => {
            if (response){
                this.viewModel.teamSchedule = response;
            }
            console.log(response);
        });
        this.dashboaradService.GetPendingRequests(this.viewModel.employeeModel.employeeID).subscribe(response => {
            if (response){
                this.viewModel.pendingRequests = response;
                this.viewModel.tabSourceList[1] ={listName:response};
            }
            console.log(response);
        });

        this.dashboaradService.GetHistoryRequests(this.viewModel.employeeModel.employeeID).subscribe(response => {
            if (response){
                this.viewModel.historyRequests = response;
                this.viewModel.tabSourceList[2] ={listName:response};
            }
            console.log(response);
        });

        this.dashboaradService.GetAllRequests(this.viewModel.employeeModel.employeeID).subscribe(response => {
            if (response){
                this.viewModel.events = response;
            }
            console.log(response);
        });

        this.dashboaradService.GetUpcomingRequests(this.viewModel.employeeModel.employeeID).subscribe(response => {
            if (response){
                this.viewModel.upcomingRequests = response;
                this.viewModel.tabSourceList[0] ={listName:response};
            }
            console.log(response);
        });

        this.dashboaradService.GetPos(this.viewModel.employeeModel.employeeID).subscribe(response => {
            if (response){
                this.viewModel.pos = response;
            }
            console.log(this.viewModel.pos);
            console.log("pos : "+ this.viewModel.pos);
        });

        this.dashboaradService.GetPoInvoices(this.viewModel.employeeModel.employeeID).subscribe(response => {
            if (response){
                this.viewModel.poInvoices = response;
            }
            console.log("poInvoices : "+ this.viewModel.poInvoices);
        });

        this.dashboaradService.GetCheckinTime(this.viewModel.employeeModel.empCode).subscribe(response => {
            if (response)
                this.viewModel.checkInTime = response["shortTime"];
            console.log(response);
        });

        this.dashboaradService.GetHaderRequests(this.viewModel.employeeModel.empCode).subscribe(response => {
            if (response && response.length) {
                this.viewModel.haderServiceCount = response.length;
                this.viewModel.haderServices = response;
                this.viewModel.tabEserviceSourceList[2] = { listName: response };
            }
            else {
                this.viewModel.haderServiceCount = 0;
                this.viewModel.tabEserviceSourceList[2] = { listName: [] };
            }
           
            this.viewModel.followUpCount+=   +this.viewModel.haderServiceCount ;
            this.viewModel.sizeEserviceArray[2] = this.viewModel.haderServiceCount;
            console.log(response);
        });
        this.dashboaradService.GetAttendanceGap(this.viewModel.employeeModel.empCode).subscribe(response => {
            if (response)
                this.viewModel.attendanceGap = response["hrshortage"];
            else
                this.viewModel.attendanceGap = 0;
            console.log(response);
        });

        this.dashboaradService.GetEServices().subscribe(response => {
            this.viewModel.eservice = response;
            if (response && response.length) {
                this.viewModel.eserviceCount = response.length;
                this.viewModel.tabEserviceSourceList[0] = { listName: response };
            }
            else {
                this.viewModel.eserviceCount = 0;
                this.viewModel.tabEserviceSourceList[0] = { listName: [] };
            }
            this.viewModel.sizeEserviceArray[0] = this.viewModel.eserviceCount;
            this.viewModel.followUpCount+=  +this.viewModel.eserviceCount;
            console.log(response);
        });

        this.dashboaradService.getDashboardData(this.viewModel.empId).subscribe(res => {

            this.viewModel.refreshDate = res["requestTime"];
            this.getLatestUpdate();
            this.viewModel.ctsService = res["ctsServices"];
            this.viewModel.meetings = res["meetings"];
            //this.viewModel.events = res["meetings"];
            this.viewModel.tabEserviceSourceList[1] = { listName: res["ctsServices"] };
            this.viewModel.ctsServiceCount = res["ctsServices"].length;
            this.viewModel.sizeArray = [
                res["tasks"].length,
                res["tasks"].length,
                res["tasks"].length
            ];
            this.viewModel.sizeEserviceArray[1] = this.viewModel.ctsServiceCount;
            this.viewModel.pending = res["pendingRequests"];
            this.viewModel.timeRemaining = res["timeRemaining"];
            this.viewModel.leaveBalance = res["leaveBalance"];
            this.viewModel.nextPrayingTime = res["nextPrayingTime"];
            this.spinnerService.hide();
        });
    }

    private getLatestUpdate() {

        var updateTime = new Date(this.viewModel.refreshDate.toLocaleString());
        var diff = Math.floor(new Date().getTime() - updateTime.getTime());
        var sec = Math.floor(diff / 1000);
        this.viewModel.min = Math.floor(sec / 60);
        this.viewModel.param.min = this.viewModel.min;
        this.translate.get('Dashboard.UpdateInfo', { min: this.viewModel.min }).subscribe((res: string) => {
            this.viewModel.updateInfo = res;
        });
    }
}




