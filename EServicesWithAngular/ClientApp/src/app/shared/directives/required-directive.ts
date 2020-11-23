import { Validator, AbstractControl, NG_VALIDATORS, NgModel, ValidationErrors, ValidatorFn } from "@angular/forms";
import { Directive, Input, ElementRef, AfterViewChecked, SimpleChanges, Host } from "@angular/core";
import { Calendar } from "primeng/calendar";
@Directive({
    selector: "[requiredIf]",
    providers: [{
        provide: NG_VALIDATORS,
        useExisting: CustomRequiredValidator,
        multi: true
    }, NgModel]
})
export class CustomRequiredValidator implements Validator {

    @Input() itemfields: any[];
    @Input() groupName = null;
    element: any;
    constructor(public el: ElementRef) {
        this.element = el;
    }

    validate(control: any): ValidationErrors | null {

        let name = (this.element.nativeElement && this.element.nativeElement.name) ? this.element.nativeElement.name : this.element.nativeElement ? this.element.nativeElement.attributes.name.value : this.element.attributes.name.value;

        /*Related to recursive=false so it can not go through object properties ,
           and only take the object it self(ex: vendors) if its required and editable or no*/
        if (this.groupName)
            name = this.groupName;

        let elements = this.el.nativeElement;
        if (this.itemfields) {

            var result = this.itemfields.filter(function (item) { return (item.fieldName == name); });
            if (result[0] && result[0].pattern && elements.pattern)
                elements.pattern = result[0].pattern;

            if (result[0] && result[0].required && (control.value == "" || control.value == null)) {
                elements.required = true;

                return { "required": true };
            }

            else { if (this.groupName == "others") elements.disabled = true; elements.required = null; return null }
        }
        elements.required = null;

    }

    registerOnValidatorChange(fn: () => void): void { this._onChange = fn; }
    private _onChange: () => void;

    ngOnChanges(changes: SimpleChanges): void {

        if ('itemfields' in changes) {

            if (this._onChange) this._onChange();
        }


    }
}
