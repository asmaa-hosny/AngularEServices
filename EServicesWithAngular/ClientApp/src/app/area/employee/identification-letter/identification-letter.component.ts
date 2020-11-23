import { Component, OnInit, ViewChild } from '@angular/core';
import { IdentificationType, SignatureTypeEnum } from 'app/shared/helpers/enum';
import { DropdownModule } from 'primeng/dropdown';
import { TypeofExpr } from '@angular/compiler';
import { UtilityService } from 'app/core/services/utility.service';
import { environment } from 'environments/environment';
import { IdentificationService } from 'app/core/services/identification.service';
import { FileUpload } from 'primeng/fileupload';
import { ToastrService } from 'ngx-toastr';
import { Table } from 'primeng/table';
import { EmployeeService } from 'app/core/services/employee.service';
import { IdentificationViewModel } from 'app/model/identification-letter.model';
import { ActivatedRoute, Params } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { map, mergeMap } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';
import { DecoratorService } from 'app/core/services/decorator.service';
import { DataService } from 'app/core/services/data.service';
@Component({
  selector: 'app-identification-letter',
  templateUrl: './identification-letter.component.html'

})
export class IdentificationLetterComponent implements OnInit {
  viewModel: IdentificationViewModel = new IdentificationViewModel();
  @ViewChild('uploadAttachment') uploadAttachment: FileUpload;
  @ViewChild('fileInput') fileInput: FileUpload;
  @ViewChild('attachmentsTable') attachmentsTable: Table;
  translateService = DecoratorService.getService();
 
  constructor(
    public utilityService: UtilityService, public employeeSevice: EmployeeService,
    public identificationService: IdentificationService, public route: ActivatedRoute,
    private spinnerService: NgxSpinnerService, public translate: TranslateService,
    private toastr: ToastrService,
    public commService: DataService) {}

  ngOnInit() {

    this.employeeSevice.getCurrentEmployee().subscribe(data => {
    
      this.viewModel.requestTypes = this.utilityService.getEnumList(IdentificationType);
      this.viewModel.signatureTypes = this.utilityService.getEnumList(SignatureTypeEnum);
      this.viewModel.employee = data;

      this.route.queryParamMap.subscribe((params: Params) => {
        if (params && params.keys.length > 0) {
          this.viewModel.jobId = params.params.JobID;
          this.viewModel.nodeId = +params.params.NodeID;
          this.viewModel.epc = params.params.EPC;
        }
        this.identificationService.getRequestFields(this.viewModel.nodeId).subscribe(res => {
          this.viewModel.fields = res;
          console.log(this.viewModel.fields);
        })

        if (this.viewModel.jobId && this.viewModel.nodeId > 0 && this.viewModel.epc) {
          this.viewModel.isNewMode = false;
          this.loadRequestData();
        }
      });
    });

  }


  private loadRequestData() {
    this.identificationService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc).subscribe((res: any) => {
      this.viewModel.item = res;
      this.viewModel.item.jobID=this.viewModel.jobId;
      this.viewModel.item.nodeID=this.viewModel.nodeId;
      this.viewModel.isNewMode = false;
      console.log(this.viewModel.jobId && !this.viewModel.isNewMode)
      this.viewModel.selectedRequestType = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.requestType, this.viewModel.requestTypes);
      this.viewModel.selectedsignatureType = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.signatureType, this.viewModel.signatureTypes);
      this.processRequest();
    });

  }

  processRequest() {
   
    this.commService.submitAction.subscribe((resp: any) => {
      this.viewModel.item.managerDecision = {};
      this.viewModel.item.managerDecision.id = resp.id;
      this.viewModel.item.managerDecision.comment = resp.comment; 
      this.viewModel.item.jobID=this.viewModel.jobId;
      this.viewModel.item.nodeID=this.viewModel.nodeId;
      this.identificationService.processRequest(this.viewModel.item).subscribe((resp: any) => {
        this.translate.get('Message.DataSaved').subscribe((res: string) => {
          this.toastr.success(res);
        });
      
      })

    })


  }

  changeTab(number, frm) {
    if (frm && frm.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }
    console.log(number);
    this.viewModel.tabnumber = number;
  }



  submit(form) {
    if (form && form.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }

    this.viewModel.item.domainModel = {};
    this.viewModel.submitted = true;
    this.viewModel.submitRequestForm = true;
    this.viewModel.item.domainModel.requestType = this.viewModel.selectedRequestType.value;
    this.viewModel.item.domainModel.signatureType = this.viewModel.selectedsignatureType.value;
    this.viewModel.item.domainModel.employeeID = this.viewModel.employee.employeeID

    this.identificationService.PostRequest(this.viewModel.item).subscribe((resp: any) => {
      this.viewModel.submitClicked = true;
      this.viewModel.jobId = resp.jobID;

      this.translate.get('Message.DataSaved').subscribe((res: string) => {
        this.toastr.success(res);
      });
      this.viewModel.isNewMode = false;

      this.viewModel.tabnumber = 2;
    });
  }









}
