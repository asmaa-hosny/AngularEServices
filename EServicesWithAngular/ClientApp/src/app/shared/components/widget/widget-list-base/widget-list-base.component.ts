import { Component, OnInit } from '@angular/core';
import { WidgetBaseComponent } from '../widget-base/widget-base.component';
import { Route, Routes, ActivatedRouteSnapshot, Router } from '@angular/router';
import { environment } from 'environments/environment.prod';
import { TranslateService } from '@ngx-translate/core';
import { UtilityService } from 'app/core/services/utility.service';

@Component({
  selector: 'app-widgettablistbase',
  templateUrl: './widget-list-base.component.html',

})
export class WidgetListbaseComponent extends WidgetBaseComponent implements OnInit {

  constructor(public router: Router,public translate: TranslateService,public utilityService:UtilityService) {
    super();
  }

  ngOnInit() {

  }
  ngOnChanges() {

  }

  navigateTo(row) {
    var processName = row["associatedFile"].toLowerCase();
    console.log(processName);
    var jobId = row["jobId"]
    var nodeId = row["nodeId"]
    var ePC = row["epc"]
    var url = `/employees/${processName}?JobID=${jobId}&NodeID=${nodeId}&EPC=${ePC}`;
    console.log(`${url.split('?')[0]}`);
    //this.router.navigate([`employees/requisition`], { queryParams: { JobID: jobId , NodeID:nodeId,EPC:ePC} });
    this.router.navigate([`${url.split('?')[0]}`], { queryParams: { JobID: jobId , NodeID:nodeId,EPC:ePC} });
   
   
  }

}