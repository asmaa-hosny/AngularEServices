
import { DataService } from 'app/core/services/data.service';
import { RequisitionService } from 'app/core/services/requisition.service';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit, Input, ViewChild, SimpleChanges, SimpleChange } from '@angular/core';
import { BaseService } from 'app/core/services/base.service';
import { LocalizationService } from 'app/core/services/localization.service';
import { TranslateService } from '@ngx-translate/core';
import { Route, Router } from '@angular/router';
import { EventData } from 'app/model/emitEvent';
import { EventType } from 'app/shared/helpers/enum';


@Component({
  selector: 'app-workflow-decisions',
  templateUrl: './workflow-decisions.component.html',
  styleUrls: ['./workflow-decisions.component.scss']
})
export class WorkflowDecisionsComponent implements OnInit {
  item: any = {};
  display;
  decisionId;
  required = true;
  submitDialog;


  private _viewModel: any;

  @Input() set viewModel(value: any) {
    this._viewModel = value;

  }

  get viewModel(): any {
    return this._viewModel;
  }

  @Input() decisions: any;
  @ViewChild('comment') comment: any;

  constructor(
    public dataService: DataService,
    public baseService: BaseService,
    public toastr: ToastrService,
    public translate: TranslateService,public router:Router,
    public locale: LocalizationService) { }


  ngOnInit() {

  }

  ngOnChanges(changes: SimpleChanges) {
    var model: SimpleChange = changes.viewModel;
    var changesdecisions: SimpleChange = changes.decisions;

    if (model)
      this.viewModel = model.currentValue;

    if (changesdecisions)
      this.viewModel.decisions = changesdecisions.currentValue;
  }


  getClassName(caseStr) {
    var classVal;
    switch (caseStr) {
      case 'Approve':
        classVal = "btn-success";
        break;
      case 'Reject':
        classVal = "btn-danger";
        break;
      case 'Done':
      case 'Work was done':

        classVal = "btn btn-info";
        break;
      case 'Not Done':
      case "Work wasn't done, Exception":
        classVal = "btn-warning";
        break;
      default:
        classVal = "btn-primary";

    }
    return classVal;
  }

  showDialog(item) {
   
    if (!this.viewModel.isValidModel) return;
    this.item.id = item.value;
    this.required = item.commentsAreMandatory;
    this.display = true;
  }
  
  submitAction() {
    this.submitDialog = true;
    if (!this.comment.errors) {
      console.log(this.comment.name);
      this.item.jobId = this.viewModel.jobId;
      this.item.nodeId = this.viewModel.nodeId;
      this.dataService.sendMessage(new EventData(EventType.DecisionSelected,this.item))
      this.display = false;
      this.item.comment = "";
    }
    else
      return false;

  }

  cancel() {
    this.baseService.cencelRequest(this.viewModel.item.activity, this.viewModel.jobId, this.viewModel.nodeId).subscribe(res => {
      this.translate.get('Message.CancelRequest').subscribe((res: string) => {
        this.toastr.success(res);
        this.router.navigate(["/employees/wq"]);
      });

    })
  }



}
