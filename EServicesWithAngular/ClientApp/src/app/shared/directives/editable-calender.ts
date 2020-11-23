import { Directive, Host, Optional, Self, Input } from '@angular/core';
import { Calendar } from 'primeng/calendar';
import { UtilityService } from 'app/core/services/utility.service';
import { LocalizationService } from 'app/core/services/localization.service';

@Directive({
    selector: 'p-calendar'
})
export class CalendarDefaultsDirective {
    @Input() itemfields: any[];
    constructor(@Host() @Self() @Optional() public host: Calendar, public utilityService: UtilityService,
        public localizationService: LocalizationService) {
        host.locale = localizationService.isEnglish ? utilityService.calendarEnglishLocale : utilityService.calendarArabicLocale
    }

    ngAfterContentChecked  () {

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
    }
}