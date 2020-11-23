import { Directive, Host, Optional, Self, Input, ChangeDetectorRef } from '@angular/core';
import { Calendar } from 'primeng/calendar';
import { UtilityService } from 'app/core/services/utility.service';
import { LocalizationService } from 'app/core/services/localization.service';
import { Dropdown } from 'primeng/dropdown';

@Directive({
    selector: 'p-dropdown'
})
export class DropDownDefaultsDirective {
    @Input() itemfields: any[];
    constructor(@Host() @Self() @Optional() public host: Dropdown, public utilityService: UtilityService,
        public localizationService: LocalizationService,public cd: ChangeDetectorRef) {
       
    }

    ngAfterViewChecked() {

        if (!this.itemfields)  return;
        if (!this.utilityService.isEditableField(this.itemfields, this.host.name)) {
            if (!this.utilityService.isVisibleField(this.itemfields, this.host.name)) {
                this.host.el.nativeElement.hidden = true;
            }
            else {
                this.host.disabled = true;
            }
        }
        else {

            this.host.disabled = false;
           
        }
        this.cd.detectChanges();
    }
}