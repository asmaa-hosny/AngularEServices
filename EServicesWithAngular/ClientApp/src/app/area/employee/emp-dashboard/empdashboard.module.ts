import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRoutingModule } from './emp-dashoard.routing.module';
import { SharedModule } from 'app/shared/shared.module';
import { TranslateModule } from '@ngx-translate/core';




@NgModule({
  imports: [
    CommonModule,SharedModule,
    DashboardRoutingModule  ,TranslateModule
  ],
  declarations: [ DashboardRoutingModule.components ]
})

export class DashboardModule { }