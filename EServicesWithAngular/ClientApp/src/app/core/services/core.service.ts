import { UtilityService } from "./utility.service";
import { EmployeeService } from "./employee.service";
import { Injectable, ChangeDetectorRef } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { DataService } from "./data.service";
import { ToastrService } from "ngx-toastr";
import { AttachementService } from "./attachement.service";
import { TranslateService } from "@ngx-translate/core";
import { LocalizationService } from "./localization.service";
import { CloneService } from "./clone.service";

@Injectable()
export class CoreService {

    constructor(public employeeService: EmployeeService,
        public utilityService: UtilityService,
        public route: ActivatedRoute,
        public cloneService: CloneService,
        public dataService: DataService,
        public toastr: ToastrService,
        public attachementService: AttachementService,
        public localizationService: LocalizationService,
        public translate: TranslateService) {

    }

}