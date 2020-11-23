import { ConsultationService } from './services/Consultation.service';
import { EmailGroupService } from './services/emailgroup.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { DashboardService } from './services/dashboard.service';
import { NavbarService } from './services/navbar.service';
import { EmployeeService } from './services/employee.service';
import { LocalizationService } from './services/localization.service';
import { SharedModule } from 'app/shared/shared.module';
import { UtilityService } from './services/utility.service';

import { RequisitionService } from './services/requisition.service';
import { AttachementService } from './services/attachement.service';
import { DataService } from './services/data.service';
import { TranslationLoaderResolver } from './services/translation-loader.resolver';
import { HttpErrorInterceptor } from './services/http-error.interceptor';
import { BaseService } from './services/base.service';
import { IdentificationService } from './services/identification.service';
import { MissionService } from './services/mission.service';
import { BaseComponent } from './componenet/base.component';
import { ItAccountService } from './services/itaccount.service';
import { CoreService } from './services/core.service';
import { CloneService } from './services/clone.service';
import { SPSiteCreationService } from './services/spsitecreation.service';
import { TranslationService } from './services/translation.service';
import { ItResignationService } from './services/resignation.service';
import { ITCareService } from './services/itcare.service';
import { ConsultationCompletionService } from './services/ConsultationCompletion.service';
import { ItServerAccessService } from './services/itserveraccess.service';

import { SoftwareService } from './services/software.service';

const modules = [CommonModule, FormsModule, RouterModule, HttpClientModule];
const components = [];
const services = [
  DashboardService,
  NavbarService,
  CoreService,
  EmployeeService,
  MissionService,
  ItAccountService,
  ConsultationService,
  ConsultationCompletionService ,
  SPSiteCreationService,
  ItResignationService,
  LocalizationService,
  UtilityService,
  IdentificationService,
  BaseService,
  RequisitionService,
  AttachementService,
  DataService,
  TranslationService,
  EmailGroupService,
  CloneService,
  ITCareService,
  SoftwareService,
  TranslationLoaderResolver,
  SPSiteCreationService,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: HttpErrorInterceptor,
    multi: true
  },
  ItServerAccessService
]

@NgModule({
  declarations: [BaseComponent],
  imports: [
    CommonModule,modules,SharedModule
  ],
  exports: [modules],
  providers: [services]
})
export class CoreModule { }
