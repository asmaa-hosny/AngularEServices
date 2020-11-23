import { NgModule } from '@angular/core';
import { SharedModule } from "app/shared/shared.module";
import { SiteCreationRoutingModule } from './sitecreation-routing.module';

@NgModule({
  declarations: [SiteCreationRoutingModule.components],
  imports: [SharedModule, SiteCreationRoutingModule]
})
export class SiteCreationModule { }

