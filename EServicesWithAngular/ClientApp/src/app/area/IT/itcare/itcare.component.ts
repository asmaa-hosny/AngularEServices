import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent } from 'app/core/componenet/base.component';
import { ITCareService } from 'app/core/services/itcare.service';
import { ITCareViewModel } from 'app/model/itcare.model';
import { Observable, forkJoin } from 'rxjs';
import { WorkQueueEnum } from 'app/shared/helpers/enum';
import { Params } from '@angular/router';

@Component({
  selector: 'app-itcare',
  templateUrl: './itcare.component.html'

})
export class ITCAREComponent extends BaseComponent implements OnInit {
  viewModel: ITCareViewModel = new ITCareViewModel();
  attachement: string = 'attachement';
  constructor(public injector: Injector, public itcareService: ITCareService) {
    super(injector);
  }


  ngOnInit() {
    this.viewModel.item.domainModel.udf_fields = {};
    this.viewModel.isNewMode = true;
    this.viewModel.isEnglish = this.localizationService.isEnglish;
    this.route.queryParamMap.subscribe((response: Params) => {
      if (response && response.keys && response.keys.length > 0) {
        this.viewModel.isERP = response.params.isERP;
      }});
    this.getData().subscribe(response => {
      this.viewModel.categories = response[0].operation.details;
      if(this.viewModel.isERP === "true"){
      this.viewModel.selectedCategory = this.viewModel.categories.find(x => x.name === 'ERP system Support - دعم نظام تخطيط الموارد المؤسسي');
      this.selectCategory(this.viewModel.selectedCategory);
      }
      else{this.viewModel.categories.splice(3,1);
    }

      this.viewModel.fields = response[1];
      this.viewModel.item.requester = this.baseEmployee = response[2];
      if (this.baseEmployee && this.baseEmployee.officeLocation)
     
        this.viewModel.item.domainModel.udf_fields.udf_sline_906 = this.baseEmployee.officeLocation;
        
        
      this.viewModel.attachementtypes = this.viewModel.fields.filter(x => x.isAttachement && x.visible);
      console.log(this.viewModel.attachementtypes);
    })
  }

  getData(): Observable<any> {
    const categories = this.itcareService.getCategories();
    const fields = this.itcareService.getRequestFields(this.viewModel.nodeId);
    const employee = this.employeeSevice.getCurrentEmployee(true);
    return forkJoin([categories, fields, employee]);
  }

  onUpload(event): void {
    console.log(event.files)
    this.viewModel[this.attachement] = Array.from(event.files);
    console.log("onUpload" + this.viewModel[name]);
  }

  onRemove(event) {
    const index = this.viewModel[this.attachement].indexOf(event.file);
    this.viewModel[this.attachement].splice(index, 1);
  }

  clear() {
    this.viewModel[this.attachement] = [];
  }

  changeTab(number, frm) {
    if (frm && frm.invalid) {
      this.viewModel.submitRequestForm = true;
      return;
    }
    console.log(number);
    this.viewModel.tabnumber = number;
  }

  selectCategory(value) {
    this.itcareService.getSubCategories(this.viewModel.selectedCategory.id).subscribe(
      response => { this.viewModel.subcategories = response.operation.details });
  }

  selectSubCategory(value) {
    this.itcareService.getSubItems(this.viewModel.selectedSubCategory.id).subscribe(
      response => { this.viewModel.items = response.operation.details });
  }

  submit(form) {
    if (form && form.invalid && !this.viewModel.isValidModel) {
      this.viewModel.submitRequestForm = true;
      return;
    }
    this.viewModel.submitted = true;
    this.viewModel.submitRequestForm = true;
    if(this.baseEmployee.officeLocation == null)
    this.viewModel.item.domainModel.udf_fields.udf_sline_906 = "Empty";
    this.viewModel.item.domainModel.category = this.viewModel.selectedCategory;
    this.viewModel.item.domainModel.subcategory = this.viewModel.selectedSubCategory;
    this.viewModel.item.domainModel.item = this.viewModel.selectedItem;
    if(this.viewModel.item.domainModel.category) delete this.viewModel.item.domainModel.category.name;
    if(this.viewModel.item.domainModel.subcategory) delete this.viewModel.item.domainModel.subcategory.name;
    if(this.viewModel.item.domainModel.item) delete this.viewModel.item.domainModel.item.name;
    this.itcareService.postRequestWithAttachement(this.viewModel, "itcare").subscribe((resp: any) => {
      this.translate.get('Message.DataSaved').subscribe((res: string) => {
        this.toastr.success(res);
        this.router.navigate(['/employees/wq'], { queryParams: { tab: WorkQueueEnum.ItCare  } });
      });
    });
  }

}
