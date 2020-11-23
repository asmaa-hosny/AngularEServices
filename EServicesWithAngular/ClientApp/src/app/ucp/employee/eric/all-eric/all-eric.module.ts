import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllEricComponent } from './all-eric.component';
import { AllEricRoutingModule, exportedCompoenent } from './all-eric-routing.module';



@NgModule({
  declarations: [exportedCompoenent],
  imports: [
    CommonModule,
    AllEricRoutingModule
  ]
})
export class AllEricModule { }
