import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { BaseComponent } from 'app/core/componenet/base.component';
import { WorkQueueModel } from 'app/model/workqueue.model';
import { DashboardService } from 'app/core/services/dashboard.service';
import { Table } from 'primeng/table';
import { SortEvent } from 'primeng/api';
import { environment } from 'environments/environment';
import { RoutingName, WorkQueueEnum } from 'app/shared/helpers/enum';
import { Params } from '@angular/router';
import { timeout } from 'rxjs/operators';

@Component({
  selector: 'app-workqueue',
  templateUrl: './workqueue.component.html'

})
export class WorkQueueComponent extends BaseComponent implements OnInit {
  viewModel: WorkQueueModel = new WorkQueueModel();
  @ViewChild('dtMyRequests') dtMyRequests: Table;
  constructor(
    public injector: Injector,
    public dashboardService: DashboardService) { super(injector) }

  ;

  ngOnInit() {
    super.ngOnInit();
    this.viewModel.tabnumber = 2;
    console.log(WorkQueueEnum.ItCare);
    this.route.queryParamMap.subscribe((response: Params) => {
      if (response && response.keys && response.keys.length > 0) {
        if (response.params.tab == WorkQueueEnum.ItCare)
          this.changeTab(WorkQueueEnum.ItCare, null);
        else if (response.params.tab == WorkQueueEnum.SubmitRequest) {
          this.viewModel.loading = true;
          this.spinnerService.show();
          this.loadData(null);
        }
      }
    });
    this.spinnerService.show();
    this.dashboardService.GetEServices().subscribe(
      response => {
        this.viewModel.pendingList = response;

      });

    
  }

  MoreDetails(col){
    this.viewModel.showMoreDeatils = true;
    this.viewModel.selectedItCareCol = col;
  }
  close(){
    this.viewModel.showMoreDeatils = false;
  }


  changeTab(number, frm) {
    this.viewModel.tabnumber = number;
    if (number == 4 && !this.viewModel.itcareList) {
      this.dashboardService.GetItCareRequests().subscribe(response => {
        console.log(response);
        this.viewModel.itcareList = response;
      });
      
    }
    else if (number == 3){
      this.loadData(null);
    }
  }

  navigateTo(row, reviewMode: boolean = false) {
    let nodeId = 0;
    let epc = 0;
   var routingName = row.associatedFile;
   var processName = routingName;
    if(reviewMode){
    processName= this.viewModel.pocessNameArray.find(x => x.key == row.procesS_NAME).key;
    routingName= this.viewModel.pocessNameArray.find(x => x.key == row.procesS_NAME).value;}
   
    var jobId = row.jobId || row.joB_ID;
    if (!reviewMode) {
      nodeId = row.nodeId
      epc = row.epc
    }
    if (processName.toLowerCase() === environment.services.TranslationService.toLowerCase())
      var url = `/opr/${RoutingName.AdminTranslation}?jobid=${jobId}&nodeid=${nodeId}&epc=${epc}`;
      else if (processName.toLowerCase() === environment.services.ConsultationService.toLowerCase() || (processName.toLowerCase() === environment.services.ConsultationCompletionService.toLowerCase()))
      var url = `/researches/${routingName.toLowerCase()}?jobid=${jobId}&nodeid=${nodeId}&epc=${epc}`;
      else 
     var url = `/it/${routingName.toLowerCase()}?jobid=${jobId}&nodeid=${nodeId}&epc=${epc}`;

    console.log(`${url.split('?')[0]}`);

    if (reviewMode)
      this.router.navigate([`${url.split('?')[0]}`], { queryParams: { jobid: jobId, nodeid: nodeId, epc: epc, reviewMode: reviewMode } });
      
      else
      this.router.navigate([`${url.split('?')[0]}`], { queryParams: { jobid: jobId, nodeid: nodeId, epc: epc } });

  }

  loadData(event) {
    if(event == null){
      this.viewModel.searchCriteria = {};
      this.viewModel.searchCriteria.OrderBy = "Request_Date descending";
      this.viewModel.searchCriteria.PageNumber = 1;
      this.viewModel.searchCriteria.pageSize = 10;
    }
    else
   {
      if (!this.dtMyRequests)
      return;
    this.dtMyRequests.loading = true;
    var pageNumber = (event.first / event.rows) + 1;
    this.extractSearchCriteria(event, pageNumber);
   }
    if (this.viewModel.loading) {
      this.viewModel.timeout = 4000;
      this.viewModel.tabnumber = WorkQueueEnum.SubmitRequest;
    }
    else
      this.viewModel.timeout = 0;
    setTimeout(() => {

      this.dashboardService.GetMyRequests(this.viewModel.searchCriteria).subscribe((resp: any) => {
        let totalCount = 0;
        if (resp.headers.has("x-pagination")) {
          totalCount = JSON.parse(resp.headers.get("x-pagination")).totalpages;
        }
        this.dtMyRequests.value = resp.body;
        this.viewModel.myrequestsList = resp.body;
        console.log(resp.body);
        this.dtMyRequests.totalRecords = totalCount;
        this.spinnerService.hide();
        this.dtMyRequests.loading = false;
      },
        (error: any) => {
          this.dtMyRequests.loading = false;
        });

    }, this.viewModel.timeout);


  }

  private extractSearchCriteria(event, pageNumber) {

    this.viewModel.searchCriteria = {};
    this.viewModel.searchCriteria.PageNumber = pageNumber;
    this.viewModel.searchCriteria.pageSize = Number(event.rows);

    if (event.sortField && event.sortOrder == 1)
      this.viewModel.searchCriteria.OrderBy = event.sortField;
    else if (event.sortField)
      this.viewModel.searchCriteria.OrderBy = event.sortField + " descending";
    else
      this.viewModel.searchCriteria.OrderBy = "Request_Date descending";

    if (Object.keys(event.filters).length > 0) {
      for (var i in event.filters) {
        this.viewModel.searchCriteria[i] = event.filters[i].value;
      }
    }
  }


}
