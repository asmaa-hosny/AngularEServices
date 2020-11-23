import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PrimeNG } from './primeng.module';
import { RatingModule } from 'primeng/rating';


import { WidgetBaseComponent } from './components/widget/widget-base/widget-base.component';
import { WidgetCountComponent } from './components/widget/widget-count/widget-count.component';
import { WidgetListbaseComponent } from './components/widget/widget-list-base/widget-list-base.component';
import { TaskTabListComponent } from './components/widget/task-tab-list/task-tab-list.component';
import { TranslateModule } from '@ngx-translate/core';
import { MatMomentDateModule, MomentDateAdapter } from "@angular/material-moment-adapter";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { NgxSpinnerModule } from 'ngx-spinner';
import { WorkflowHistoryComponent } from './components/workflows/workflow-history/workflow-history.component';
import { OnlyNumberDirective } from './directives/only-number.directive';
import { ReadOnlyDirective } from './directives/read-only-directive';
import { WorkflowDecisionsComponent } from './components/workflows/workflow-decisions/workflow-decisions.component';
import { SetEditableDirective } from './directives/editable-directive';
import { CustomRequiredValidator } from './directives/required-directive';
import { CalendarDefaultsDirective } from './directives/editable-calender';
import { DropDownDefaultsDirective } from './directives/editable-dropdown';
import { ArrayFilterPipe } from './pipes/array-filter.pipe';
import { AttachementComponent } from './components/attachement/attachement.component';
import { RequesterDataComponent } from './components/requests/requester-data/requester-data.component';
import { Constants } from './helpers/constants';
import { CustomMinDirective } from './directives/custom-min-validator.directive.ts';
import { CustomMaxDirective } from './directives/custom-max-validator.directive';
import { RouterModule } from '@angular/router';
import { ArabicStyleComponent } from './components/renderlang/arabicStyleComponent/arabic-style-component';

import { CheckboxDefaultsDirective } from './directives/checkbox-directive';
import { ClipboardModule } from 'ngx-clipboard';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction';
import { UCPEnglishStyleComponent } from './components/renderlang/ucp-english-style-Componenet/ucp-english-style-component';
import { EnglishStyleComponent } from './components/renderlang/englishStyleComponenet/english-style-component';

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        PrimeNG, 
        CommonModule,
        RatingModule, 
        ClipboardModule,FormsModule,NgxSpinnerModule,
        TranslateModule],
    declarations: [
        WidgetBaseComponent,
        WidgetCountComponent,
        ArabicStyleComponent,
        EnglishStyleComponent,
        UCPEnglishStyleComponent,
        WidgetListbaseComponent,
        TaskTabListComponent,
        WorkflowHistoryComponent,
        OnlyNumberDirective,
        ReadOnlyDirective, 
        SetEditableDirective,
        CustomMinDirective,
        CustomMaxDirective,
        CustomRequiredValidator,
        CalendarDefaultsDirective,
        ArrayFilterPipe,
        DropDownDefaultsDirective,
        CheckboxDefaultsDirective,
        WorkflowDecisionsComponent,
        AttachementComponent,
        RequesterDataComponent],
    exports: [
        ClipboardModule,
        MatDatepickerModule,
        CommonModule,
        TranslateModule,
        FormsModule,
        PrimeNG,
        FormsModule,
        WidgetBaseComponent,
        WidgetCountComponent,
        WidgetListbaseComponent,
        NgxSpinnerModule,
        TaskTabListComponent,
        WorkflowHistoryComponent,
        WorkflowDecisionsComponent,
        ArabicStyleComponent,
        EnglishStyleComponent,
        UCPEnglishStyleComponent,
        OnlyNumberDirective,
        ReadOnlyDirective,
        CalendarDefaultsDirective,
        CustomMinDirective,
        CustomMaxDirective,
        DropDownDefaultsDirective,
        CheckboxDefaultsDirective,
        CustomRequiredValidator,
        SetEditableDirective,
        ArrayFilterPipe,
        AttachementComponent,
        RequesterDataComponent,
        RatingModule
    ]
})
export class SharedModule { }