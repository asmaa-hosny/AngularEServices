import { Component, OnInit, Injector, ChangeDetectorRef, Inject } from "@angular/core";
import { LocalizationService } from "../services/localization.service";
import { ActivatedRoute, Router } from "@angular/router";

import { ToastrService } from "ngx-toastr";
import { AttachementService } from "../services/attachement.service";
import { EmployeeService } from "../services/employee.service";
import { TranslateService } from "@ngx-translate/core";
import { BaseService } from "../services/base.service";
import { UtilityService } from "../services/utility.service";
import { CoreService } from "../services/core.service";
import { DataService } from "../services/data.service";
import { CloneService } from "../services/clone.service";
import { NgxSpinnerService } from "ngx-spinner";
import { Params } from '@angular/router';


export class ServiceLocator {
    static injector: Injector;
}
@Component({
    template: ``
})


export class BaseComponent implements OnInit {
    public localizationService: LocalizationService;
    public router:Router;
    public utilityService: UtilityService;
    public route: ActivatedRoute;
    public baseService: BaseService;
    public dataService: DataService;
    public toastr: ToastrService;
    public attachementService: AttachementService;
    public employeeSevice: EmployeeService;
    public changeDetectorRef: ChangeDetectorRef;
    public translate: TranslateService;
    public cloneService:CloneService;
    public  spinnerService: NgxSpinnerService
    public baseEmployee;
    public getfromAD:boolean =false;
    
    constructor(public injector:Injector) {
        
        if (!this.localizationService) this.localizationService =this.injector.get(LocalizationService);
        if (!this.route) this.route = injector.get(ActivatedRoute);
        if (!this.router) this.router = injector.get(Router);
        if (!this.dataService) this.dataService = injector.get(DataService);
        if (!this.toastr) this.toastr = injector.get(ToastrService);
        if (!this.attachementService) this.attachementService = injector.get(AttachementService);
        if (!this.employeeSevice) this.employeeSevice = injector.get(EmployeeService);
        if (!this.translate) this.translate = injector.get(TranslateService);
        if (!this.baseService) this.baseService = injector.get(BaseService);
        if (!this.utilityService) this.utilityService = injector.get(UtilityService);
        if(!this.cloneService)this.cloneService=injector.get(CloneService);
        if (!this.spinnerService) 
        this.spinnerService =this.injector.get(NgxSpinnerService);
      
    }

    ngOnInit(): void {
        
        this.route.queryParamMap.subscribe((response: Params) => {

            if ((response && response.keys && response.keys.length > 0 && response.params.jobid && response.params.nodeid >0)||(this.router.url==="/employees/wq")){
                this.getfromAD=true;
            }
            
            if(!this.baseEmployee){
                this.employeeSevice.getCurrentEmployee(this.getfromAD).subscribe(response => {
                    this.baseEmployee = response;
                    if(!this.baseEmployee.email)
                    this.router.navigate(['/accessdenied']);
                });
            }
        })
    }

}