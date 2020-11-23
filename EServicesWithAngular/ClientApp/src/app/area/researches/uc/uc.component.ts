import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { BaseComponent } from 'app/core/componenet/base.component';
import{ConsultationService} from 'app/core/services/Consultation.service';
import { Params } from '@angular/router';
import { EventType, ServiceType, Universities, Consultants, WorkQueueEnum } from 'app/shared/helpers/enum';
import { UcViewModel } from 'app/model/uc.model';
import { Table } from 'primeng/table';
import { environment } from 'environments/environment';


@Component({
  selector: 'app-uc',
  templateUrl: './uc.component.html',
})

export class UcComponent extends BaseComponent implements OnInit {
 viewModel: UcViewModel = new UcViewModel();
 @ViewChild('attachmentsTable') attachmentsTable: Table;
 attachement: string = 'attachement';
 attachements = [];
 employeeEmail;
 startDate :Date;
 endDate : Date;
 

  constructor(public injector: Injector,
    public ConsultationService: ConsultationService) {
   super(injector);
  }


  ngOnInit() {
    super.ngOnInit();
    this.viewModel.jobId = 0;
    this.viewModel.isNewMode = true;
    this.viewModel.isEnglish = this.localizationService.isEnglish;
    this.viewModel.requestsTypes = this.utilityService.getEnumList(ServiceType);
   
    

    this.route.queryParamMap.subscribe((response: Params) => {
      if (response && response.keys && response.keys.length > 0) {
        this.viewModel.jobId = response.params.jobid;
        this.viewModel.nodeId = +response.params.nodeid;
        this.viewModel.epc = response.params.epc;
        this.viewModel.reviewMode = response.params.reviewMode;
      }
      
      this.ConsultationService.getRequestFields(this.viewModel.nodeId).subscribe(response => {
        
        this.viewModel.fields = response;
      
        this.viewModel.attachementtypes = this.viewModel.fields.filter(x => x.isAttachement && x.visible);

        console.log(this.viewModel.fields);
        this.viewModel.item.requester = this.baseEmployee;
      })
      
      this.getUniversities();
      
      this.loadData();
      
     
    });
    
  }
  async loadRequestData() {
   
    this.viewModel.item = await this.ConsultationService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc,this.viewModel.reviewMode).toPromise();
      this.viewModel.item.jobID = this.viewModel.jobId;
      this.viewModel.item.nodeID = this.viewModel.nodeId;
      this.baseEmployee = this.viewModel.item.requester;
      
      this.viewModel.selectedRequestType = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.requestTypeId, this.viewModel.requestsTypes);
      this.viewModel.selectedUniversity = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.universityId, this.viewModel.universities);

      if(this.viewModel.item.domainModel.isInvolved){
      this.viewModel.consultantNotinvolvedChecked = false;
      this.getFellowsList(this.viewModel.selectedUniversity.id)
      }
      else
      this.viewModel.consultantNotinvolvedChecked = true;
      this.viewModel.startDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateFrom, false);
      this.viewModel.endDateValue = this.utilityService.convertToLocalDate(this.viewModel.item.domainModel.dateTo, false);
      this.viewModel.estimatedCost = this.viewModel.item.domainModel.estimatedCost;
      this.viewModel.requestsHistory = this.viewModel.item.consultationRequestsHistory;
      for(var item in this.viewModel.requestsHistory)
      {
        this.viewModel.requestsHistory[item].researchTypeText =  this.viewModel.researchtypes.find(x => x.key == this.viewModel.requestsHistory[item].researchType).value;
      }
      this.processRequest();
      
      
    
    
  }
  

  loadData(){
    if ((this.viewModel.jobId && this.viewModel.reviewMode) || (this.viewModel.jobId && this.viewModel.nodeId > 0)) {
      this.viewModel.isNewMode = false;
      this.loadRequestData();
    }
   
  }


  loadAttachmentsData(event) {

    if (this.attachmentsTable) this.attachmentsTable.loading = true;
    this.ConsultationService.getAttachments(this.viewModel.jobId).subscribe((resp: any) => {
      this.viewModel.attachementData = resp;
      this.attachmentsTable.value = this.viewModel.attachementData;
      this.attachmentsTable.loading = false;
    });

  }

  processRequest() {
    

    const subscribtion = this.dataService.getMessage(EventType.DecisionSelected,this.viewModel.item.jobID,this.viewModel.item.nodeID).subscribe(
      async response => {
        this.viewModel.item.managerDecision = {};
        this.viewModel.item.managerDecision.id = response.id;
        this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
        this.viewModel.item.domainModel.requestType = this.viewModel.selectedRequestType.text;
        this.viewModel.item.domainModel.universityId = this.viewModel.selectedUniversity.id;

        if(this.viewModel.item.domainModel.isInvolved){
          this.viewModel.item.domainModel.registeredConsultantId = this.viewModel.selectedConsultant.identityKey;
          this.viewModel.item.domainModel.researchAreasId = this.viewModel.selectedArea.id;
          }
        this.viewModel.item.domainModel.estimatedCost = this.viewModel.estimatedCost;
        this.viewModel.item.managerDecision.comment = response.comment;
        this.viewModel.item.jobID = this.viewModel.jobId;
        this.viewModel.item.nodeID = this.viewModel.nodeId;

        this.ConsultationService.processRequestWithAttachement(this.viewModel, "consultation").subscribe((response: any) => {
          this.translate.get('Message.DataSaved').subscribe((response: string) => {
            this.toastr.success(response);

          });

        })
        this.router.navigate(['/employees/wq']);

      }
    )


  }
  getUniversities(){
    this.ConsultationService.getUniversitiesList().subscribe(response => {
      this.viewModel.universities = response;
      

    })

  }

  getFellowsList(selectedUniversity){
    this.ConsultationService.getFellowsList(selectedUniversity).subscribe(response => {
      this.viewModel.consultants = response;
      if(!this.viewModel.isNewMode && response){
      this.viewModel.selectedConsultant = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.registeredConsultantId, this.viewModel.consultants, "identityKey") ;
      this.getAreasList(this.viewModel.selectedConsultant.email);

      }
    })

  }

  

  getAreasList(fellowEmail){
    this.ConsultationService.getAreasList(fellowEmail).subscribe(response => {
      this.viewModel.returned = response;
      this.viewModel.areas = this.viewModel.returned.areas;
      this.viewModel.rating = this.viewModel.returned.rating;
      if(!this.viewModel.isNewMode && response ){
        this.viewModel.selectedArea = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.researchAreasId, this.viewModel.areas);
  
        }
    })

  }

  getRequestsHistoryList(){
    this.ConsultationService.getConsultationRequestsHistory(this.viewModel.employeeEmail).subscribe(response => {
      this.viewModel.requestsHistory = response;
    })
  }

  changeTab(number, frm , formName) {
    if (formName == 'form1')
    {
      this.onChangeDateTo(null);
      if (frm &&  (frm.invalid || this.viewModel.dateExceeded ||  this.viewModel.invalidDate ||  this.viewModel.invalidInterval))
           {
             this.viewModel.submitRequestForm = true;
             return;
           }
    }
   else if (formName == 'form2')
   {
     if (frm &&  (frm.invalid ||  this.viewModel.durationlimitExceeded ||
         this.viewModel.remainingDaysExceeded || !this.viewModel.isAvailable))
           {
             this.viewModel.submitRequestForm = true;
             return;
            }
   }
    console.log(number);
    this.viewModel.tabnumber = number;
  }

  onUpload(event): void {
    console.log(event.files)
    this.viewModel[this.attachement] = null;
    this.attachements = this.attachements.concat(Array.from(event.files));
    this.viewModel[this.attachement] = this.attachements;
  

    console.log("onUpload" + this.viewModel[name]);
  }

  onRemove(event) {
    const index = this.viewModel[this.attachement].indexOf(event.file);
    this.viewModel[this.attachement].splice(index, 1);
  }

  clear() {
    this.viewModel[this.attachement] = [];
  }
  private download(item) {
    this.baseService.download(item.fileAbsolutePath).subscribe(res => {
      console.log(res);
      var link = document.createElement('a');
      link.href = window.URL.createObjectURL(res);
      console.log(link.href);
      link.download = item.fileName;
      link.style.display = "none";
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);

    });
  }
  onChangeDateTo(event){
    if(this.viewModel.startDateValue && (this.viewModel.startDateValue < this.viewModel.endDateValue))
    {
      this.viewModel.invalidDate = false;
      if (this.viewModel.startDateValue.getFullYear() == this.viewModel.endDateValue.getFullYear())
          { 
            this.viewModel.Difference_In_Time = this.viewModel.endDateValue.getTime() - this.viewModel.startDateValue.getTime();
            var  Difference_In_Days = this.viewModel.Difference_In_Time / (1000 * 3600 * 24);
            this.viewModel.invalidInterval = false;  
            // var Difference_In_Months = this.viewModel.endDateValue.getMonth() - this.viewModel.startDateValue.getMonth()  + 
            // (12 * (this.viewModel.endDateValue.getFullYear() - this.viewModel.startDateValue.getFullYear()))
 
              if(Difference_In_Days > environment.ConsultationDuration.MaxMonthPerYear)
                 {this.viewModel.dateExceeded = true}
             else
                  this.viewModel.dateExceeded = false;      

          }
          else
          {
            // the interval should be in the same year 
            this.viewModel.invalidInterval = true;
          }
    
    }
    else
    {
       // The start date must be a date before end date
       this.viewModel.invalidDate = true;
    }
    

  }

  onChangeConsultantInvolved(event){
    if (event == true)
    {this.viewModel.consultantNotinvolvedChecked = true
      this.viewModel.fields.find(x=> x.fieldName  === "consultantEmail" ).required = true;
      this.viewModel.fields.find(x=> x.fieldName  === "consultantNumber" ).required = true;
      this.viewModel.fields.find(x=> x.fieldName  === "consultantDetails" ).required = true;
      this.viewModel.fields.find(x=> x.fieldName  === "consultantName" ).required = true;
      
    }
    else
     {
      this.viewModel.consultantNotinvolvedChecked = false
      this.viewModel.fields.find(x=> x.fieldName  === "consultantEmail" ).required = false;
      this.viewModel.fields.find(x=> x.fieldName  === "consultantNumber" ).required = false;
      this.viewModel.fields.find(x=> x.fieldName  === "consultantDetails" ).required = false;
      this.viewModel.fields.find(x=> x.fieldName  === "consultantName" ).required = false;
        
     }
    console.log("isNotinvolved",event ,this.viewModel.consultantNotinvolvedChecked);
    }

    onChangeUnversity(event){
      if(!this.viewModel.consultantNotinvolvedChecked){
        this.getFellowsList(this.viewModel.selectedUniversity.id)
        
      }
     }
     onChangeFellow(event){
       if(!this.viewModel.consultantNotinvolvedChecked){
         this.getAreasList(this.viewModel.selectedConsultant.email)
         this.viewModel.profileURL = environment.navigation.profileFellow + this.viewModel.selectedConsultant.email;
         
       }
      }
      async getConsultantAvailabilty(consultantEmail , startDate , endDate , duration)
      {
        this.viewModel.consultantAvailabilty = await this.ConsultationService.checkAvailabilty(consultantEmail , startDate, endDate , duration).toPromise();
          
          this.viewModel.isAvailable = this.viewModel.consultantAvailabilty.isAvailable;
          this.viewModel.remainingDays = this.viewModel.consultantAvailabilty.remainingDays;
      }

    async onChangeDuration(searchValue: any): Promise<void> {  
    
      var startDate = this.utilityService.convertToLocalDate(this.viewModel.startDateValue , false , true);
      var endDate = this.utilityService.convertToLocalDate(this.viewModel.endDateValue , false ,true );
      this.viewModel.durationlimit = environment.ConsultationDuration.MaxDaysPerMonth;
      await this.getConsultantAvailabilty(this.viewModel.selectedConsultant.email , startDate , endDate , searchValue);
     
      if(this.viewModel.isAvailable == true)
      {
        if(searchValue > this.viewModel.durationlimit )
        {
         this.viewModel.durationlimitExceeded = true; 
        }
        else if ( searchValue > this.viewModel.remainingDays)
        {
          this.viewModel.remainingDaysExceeded= true; 
        }
      
        else
        {
         this.viewModel.durationlimitExceeded = false; 
         this.viewModel.uniCost = this.viewModel.selectedUniversity.universityCost;
         this.viewModel.estimatedCost = searchValue * (this.viewModel.uniCost);
        }
      }
    else {  this.viewModel.isAvailable= false; }
    }

    CallRating(consultantEmail: any)
    {
      this.ConsultationService.getRating(consultantEmail).subscribe(response => {
        this.viewModel.rating = response;
      })

    }

    submit(form) {
      if (form && ( form.invalid ||this.viewModel.dateExceeded ||  this.viewModel.invalidDate ||
          this.viewModel.invalidInterval ||  this.viewModel.durationlimitExceeded || 
           this.viewModel.remainingDaysExceeded || !this.viewModel.isAvailable)) {
        this.viewModel.submitRequestForm = true;
        return;
      }
      this.viewModel.submitted = true;
      this.viewModel.submitRequestForm = true;
      this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
      this.viewModel.item.domainModel.requestType = this.viewModel.selectedRequestType.text;
      this.viewModel.item.domainModel.requestTypeId = this.viewModel.selectedRequestType.value;
      this.viewModel.item.domainModel.universityId = this.viewModel.selectedUniversity.id;
      this.viewModel.item.domainModel.universityName = this.viewModel.selectedUniversity.nameEn;
      this.viewModel.item.domainModel.ericEmail = this.viewModel.selectedUniversity.universityEricEmail;
      
      if(!this.viewModel.consultantNotinvolvedChecked){
        this.viewModel.item.domainModel.registeredConsultantId = this.viewModel.selectedConsultant.identityKey;
        this.viewModel.item.domainModel.consultantName = this.viewModel.selectedConsultant.fullName;
        this.viewModel.item.domainModel.researchAreasId = this.viewModel.selectedArea.id;
        this.viewModel.item.domainModel.researchArea = this.viewModel.selectedArea.name;
        this.viewModel.item.domainModel.consultantEmail = this.viewModel.selectedConsultant.email;
      }
      else{this.viewModel.item.domainModel.researchAreasId = null;}
      this.viewModel.item.domainModel.dateFrom = this.utilityService.convertToApiDate(this.viewModel.startDateValue);
      this.viewModel.item.domainModel.dateTo = this.utilityService.convertToApiDate(this.viewModel.endDateValue);
      this.viewModel.item.domainModel.estimatedCost = this.viewModel.estimatedCost;
      this.viewModel.item.domainModel.isInvolved = !this.viewModel.consultantNotinvolvedChecked;

      

      this.ConsultationService.postRequestWithAttachement(this.viewModel, "consultation").subscribe((resp: any) => {
        this.translate.get('Message.DataSaved').subscribe((res: string) => {
          this.toastr.success(res);
          this.viewModel.isNewMode = false;
          this.viewModel.tabnumber = 3;
        });
      });
      this.router.navigate(['/employees/wq'], { queryParams: { tab: WorkQueueEnum.SubmitRequest } });
    }
  
}
