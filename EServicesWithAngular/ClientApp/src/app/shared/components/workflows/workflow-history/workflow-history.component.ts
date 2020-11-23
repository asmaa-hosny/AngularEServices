import { Component, OnInit, Input } from '@angular/core';
import { BaseService } from 'app/core/services/base.service';

@Component({
  selector: 'app-workflow-history',
  templateUrl: './workflow-history.component.html',
  styleUrls: ['./workflow-history.component.scss']
})
export class WorkflowHistoryComponent implements OnInit {
  historyRecords:{}
  @Input() jobID: any;

  gridColName: any;
  @Input() requestType;

  

  constructor(public baseService: BaseService) { }

  ngOnInit() {
    this.baseService.getHistory(this.jobID).subscribe(res => {
      this.historyRecords = res;
    });
  }







}
