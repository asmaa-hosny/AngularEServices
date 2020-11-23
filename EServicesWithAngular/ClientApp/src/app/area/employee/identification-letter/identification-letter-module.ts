import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IdentificationRoutingModule, components } from './identification-routing-module';
import { SharedModule } from 'app/shared/shared.module';



@NgModule({
    imports: [ SharedModule, IdentificationRoutingModule ],
    declarations: [ components ]
})
export class IdentificationModule { }