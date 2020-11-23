import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllFellowComponent } from './all-fellow.component';
import { AllFellowRoutingModule, routedComponents } from './all-fellow-routing.module';



@NgModule({
  declarations: [routedComponents],
  imports: [
    CommonModule,
    AllFellowRoutingModule
  ]
})
export class AllFellowModule { }
