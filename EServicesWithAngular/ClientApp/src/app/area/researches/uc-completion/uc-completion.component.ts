import { environment } from 'environments/environment';
import { EventType, Universities, EvaluationAnswers} from './../../../shared/helpers/enum';
import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from 'app/core/componenet/base.component';
import { UcCompletionViewModel } from 'app/model/uc-completion.model';
import { ItAccountService } from 'app/core/services/itaccount.service';
import { Params } from '@angular/router';
import { WorkQueueEnum } from 'app/shared/helpers/enum';
import {RatingModule} from 'primeng/rating';
import { ConsultationCompletionService } from 'app/core/services/ConsultationCompletion.service';

@Component({
   
    selector: 'app-uc-completion',
    templateUrl: 'uc-completion.component.html',
  
})
export class UcCompletionComponent extends BaseComponent implements OnInit {
    viewModel: UcCompletionViewModel = new UcCompletionViewModel();
     index;
     i;
     constructor(public injector: Injector,
       public consultationCompletionService: ConsultationCompletionService) {
      super(injector);
     }
   
   
     ngOnInit() {
      super.ngOnInit();
    
      this.viewModel.jobId = 0;
      this.viewModel.isNewMode = true;
      this.viewModel.isEnglish = this.localizationService.isEnglish;
      this.viewModel.answers = this.utilityService.getEnumList(EvaluationAnswers);
  
      this.route.queryParamMap.subscribe((response: Params) => {
        if (response && response.keys && response.keys.length > 0) {
          this.viewModel.jobId = response.params.jobid;
          this.viewModel.nodeId = +response.params.nodeid;
          this.viewModel.epc = response.params.epc;
          this.viewModel.reviewMode = response.params.reviewMode;
        }
        
        this.getRequestList();
        this.consultationCompletionService.getRequestFields(this.viewModel.nodeId).subscribe(response => {
          this.viewModel.fields = response;
          console.log(this.viewModel.fields);
          this.viewModel.item.requester = this.baseEmployee;
        })
        // this.getEvaluationItem();
        

     
      });
     
    }
    async loadRequestData() {
     
      this.viewModel.item = await this.consultationCompletionService.getRequest(this.viewModel.jobId, this.viewModel.nodeId, this.viewModel.epc,this.viewModel.reviewMode).toPromise();
        this.viewModel.item.jobID = this.viewModel.jobId;
        this.viewModel.item.nodeID = this.viewModel.nodeId;
        this.baseEmployee = this.viewModel.item.requester;
        this.viewModel.selectedRequest = this.utilityService.getItemByIndex(this.viewModel.item.domainModel.consultationRequestId, this.viewModel.consultationRequest);

        this.viewModel.actualCost = this.viewModel.item.domainModel.actualCost;
        this.viewModel.evaluationItems = this.viewModel.item.consultantEvaluationItems;
        this.viewModel.comments = this.viewModel.item.consultantEvaluation.comments;
        this.viewModel.rating = this.viewModel.item.consultantEvaluation.rating;
        if(this.viewModel.item.domainModel.status == "Terminated")
        this.viewModel.isTerminated = true;
  
        this.processRequest();
      
    }
    processRequest() {
  
      const subscribtion = this.dataService.getMessage(EventType.DecisionSelected,this.viewModel.item.jobID,this.viewModel.item.nodeID).subscribe(
        async response => {
          this.viewModel.item.managerDecision = {};
          this.viewModel.item.managerDecision.id = response.id;
          this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
          this.viewModel.item.domainModel.consultationRequestId = this.viewModel.selectedRequest.id;
           this.viewModel.item.domainModel.actualCost = this.viewModel.actualCost;
          this.viewModel.item.managerDecision.comment = response.comment;
          this.viewModel.item.jobID = this.viewModel.jobId;
          this.viewModel.item.nodeID = this.viewModel.nodeId;
          this.viewModel.item.consultationJobId = this.viewModel.selectedRequest.jobId;
  
          this.consultationCompletionService.processRequest(this.viewModel.item).subscribe((response: any) => {
            this.translate.get('Message.DataSaved').subscribe((response: string) => {
              this.toastr.success(response);
  
            });
  
          })
          this.router.navigate(['/employees/wq']);
  
        }
      )
  
  
    }
    changeTab(number, frm) {
      if (frm && frm.invalid) {
        this.viewModel.submitRequestForm = true;
        return;
      }
      console.log(number);
      this.viewModel.tabnumber = number;
    }
    
      onChangeDuration(searchValue: any): void {  
        console.log(searchValue);
        if (this.viewModel.selectedRequest.universityName == Universities.KFUPM)
        this.viewModel.actualCost = searchValue * environment.UniCosts.KFUPM;
        else if (this.viewModel.selectedRequest.universityName == Universities.KAU)
        this.viewModel.actualCost = searchValue * environment.UniCosts.KAU;
        else if (this.viewModel.selectedRequest.universityName == Universities.KSU)
        this.viewModel.actualCost = searchValue * environment.UniCosts.KSU;
      }

      getRequestList() {
        this.consultationCompletionService.getLists().subscribe(response => {
          
          this.viewModel.requestLists = response;
          this.viewModel.consultationRequest = this.viewModel.requestLists.consultationList;
          this.viewModel.evaluationItems = this.viewModel.requestLists.consultantEvaluationList;
          if ((this.viewModel.jobId && this.viewModel.reviewMode) || (this.viewModel.jobId && this.viewModel.nodeId > 0)) {
            this.viewModel.isNewMode = false;
            this.loadRequestData();
          }

         
        })
      }

  
      submit(form) {
        if (form && form.invalid ) {
          this.viewModel.submitRequestForm = true;
          return;
        }
       
          this.viewModel.evaluationItems.map(x => {
            if (x.answer) {
              x.answer = x.answer.value
            }});

    

          for(var item in this.viewModel.evaluationItems)
          {
            this.viewModel.evaluationItems[item].answerText = this.viewModel.answersArray.find(x => x.key == this.viewModel.evaluationItems[item].answer).value;
          }
        this.viewModel.item.comments= this.viewModel.comments;
        this.viewModel.item.rating = this.viewModel.rating;
        this.viewModel.item.isTerminated = this.viewModel.isTerminated;
        this.viewModel.item.consultantEvaluationItems = this.viewModel.evaluationItems;
        this.viewModel.item.consultantEmail = this.viewModel.selectedRequest.consultantEmail;
        this.viewModel.submitted = true;
        this.viewModel.submitRequestForm = true;
        this.viewModel.item.domainModel.employeeEmail = this.baseEmployee.email;
        this.viewModel.item.domainModel.consultationRequestId = this.viewModel.selectedRequest.id;
        this.viewModel.item.domainModel.actualCost = this.viewModel.actualCost;
        this.viewModel.item.consultationJobId = this.viewModel.selectedRequest.jobId;
        this.consultationCompletionService.postRequest(this.viewModel.item).subscribe((resp: any) => {
          this.translate.get('Message.DataSaved').subscribe((res: string) => {
            this.toastr.success(res);
            this.viewModel.isNewMode = false;
            this.viewModel.tabnumber = 3;
          });
        });
        this.router.navigate(['/employees/wq'], { queryParams: { tab: WorkQueueEnum.SubmitRequest } });
      }
     
     
   }
   


