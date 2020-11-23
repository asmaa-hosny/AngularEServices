import { NgModule } from '@angular/core';

import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { InputSwitchModule } from 'primeng/inputswitch';
import { CheckboxModule } from 'primeng/checkbox';
import { CalendarModule } from 'primeng/calendar';
import { FileUploadModule } from 'primeng/fileupload';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { RadioButtonModule } from 'primeng/radiobutton';
import { ListboxModule } from 'primeng/listbox';
import { TooltipModule } from 'primeng/tooltip';
import { CarouselModule } from 'primeng/carousel';
import { AutoCompleteModule } from 'primeng/autocomplete';
import {FullCalendarModule} from 'primeng/fullcalendar';
import {InputTextareaModule} from 'primeng/inputtextarea';
import {FieldsetModule} from 'primeng/fieldset';
@NgModule({
  imports: [TableModule, ConfirmDialogModule, DialogModule, DropdownModule,FullCalendarModule, InputSwitchModule, CheckboxModule, CalendarModule, FileUploadModule, ToastModule, RadioButtonModule,
    ListboxModule, TooltipModule, CarouselModule, AutoCompleteModule,InputTextareaModule , FieldsetModule ],
  exports: [TableModule, ConfirmDialogModule, DialogModule, DropdownModule,FullCalendarModule, InputSwitchModule, CheckboxModule, CalendarModule, FileUploadModule, ToastModule, RadioButtonModule,
    ListboxModule, TooltipModule, CarouselModule, AutoCompleteModule,InputTextareaModule,FieldsetModule],
  declarations: [],
  providers: [ConfirmationService, MessageService]
})

export class PrimeNG {

}