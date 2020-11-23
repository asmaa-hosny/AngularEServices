import { Directive, ElementRef, HostListener, Input, OnInit, AfterViewChecked, Host, ViewChild } from '@angular/core';
import { UtilityService } from 'app/core/services/utility.service';
import { NgModel } from '@angular/forms';
import { Calendar } from 'primeng/calendar';

@Directive({
  selector: '[editableIf]',
  providers: [NgModel],
})
export class SetEditableDirective implements OnInit, AfterViewChecked {
  inputElement: any;
  @Input() itemfields: any[];
  @Input() groupName = "";
  element: any;
 
  constructor(public el: ElementRef, public utilityService: UtilityService, public ngModel: NgModel) {
    this.inputElement = el.nativeElement;
    this.element = el;
  }

  ngAfterViewChecked() {
    let name = (this.element.nativeElement && this.element.nativeElement.name) ? this.element.nativeElement.name : this.element.nativeElement ? this.element.nativeElement.attributes.name.value : this.element.attributes.name.value;
  
   
    if (!this.inputElement) return;
    if (!this.itemfields) return;
    
   /*Related to recursive=false so it can not go through object properties ,
    and only take the object it self(ex: vendors) if its required and editable or no*/
    if (this.groupName)
      name = this.groupName;

    if (!this.utilityService.isEditableField(this.itemfields, name)) {
      if (!this.utilityService.isVisibleField(this.itemfields, name)) {
        if (this.inputElement.parent)
          this.inputElement.parent.hidden = true;
        else
          this.inputElement.hidden = true;
      }
      else {
        this.inputElement.disabled = true;
      }
    }
    else {
   
      this.inputElement.disabled = false;

    }
  }

  ngOnInit(): any {
    if (!this.utilityService.isEditableField(this.itemfields, name)) {
      this.inputElement.disabled = true;
    }
  }


}
