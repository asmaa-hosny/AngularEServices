import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FellowProfileComponent } from './fellow-profile.component';
import { FellowProfileRoutingModule, routedComponents } from './fellow-profile-routing.module';



@NgModule({
  declarations: [routedComponents],
  imports: [
    CommonModule,
    FellowProfileRoutingModule
  ]
})
export class FellowProfileModule { }
