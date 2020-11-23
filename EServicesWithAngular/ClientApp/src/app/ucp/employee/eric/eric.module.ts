import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EricsComponent } from './erics.component';
import { EricRoutingModule } from './eric-routing.module';



@NgModule({
  declarations: [EricsComponent],
  imports: [
    CommonModule,
    EricRoutingModule
  ]
})
export class EricModule { }
