import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from 'app/shared/shared.module';
import { RequisitionRoutingModule, components } from './requisition-routing.module';
import { NgxPrintModule } from 'ngx-print';



@NgModule({
    imports: [ SharedModule,RequisitionRoutingModule ,NgxPrintModule ],
    declarations: [ components ]
})
export class RequisitionModule { }