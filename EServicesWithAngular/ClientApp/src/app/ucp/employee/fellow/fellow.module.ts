import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FellowComponent } from './fellow.component';
import { FellowRoutingModule } from './fellow-routing.module';



@NgModule({
  declarations: [FellowComponent],
  imports: [
    CommonModule,
    FellowRoutingModule
  ]
})
export class FellowModule { }
