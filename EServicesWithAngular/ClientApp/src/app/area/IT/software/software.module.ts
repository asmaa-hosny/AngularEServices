import { NgModule } from '@angular/core';
import { SharedModule } from "app/shared/shared.module";
import { SoftwareRoutingModule } from './software-routing.module';

@NgModule({
  declarations: [SoftwareRoutingModule.components],
  imports: [SharedModule, SoftwareRoutingModule]
})
export class SoftwareModule { }

