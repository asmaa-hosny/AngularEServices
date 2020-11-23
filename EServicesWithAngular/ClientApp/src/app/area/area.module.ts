import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AreaComponent } from './area.component';

import { EmpDashboardComponent } from './employee/emp-dashboard/emp-dashboard.component';

import { AreaRoutingModule } from './area-routing.module';
import { FooterComponent } from './common/footer/footer.component';
import { NavbarComponent } from './common/navbar/navbar.component';
import { CoreModule } from 'app/core/core.module';
import { SidebarComponent } from './common/sidebar/sidebar.component';

import { SharedModule } from 'app/shared/shared.module';
import { AccessdeniedComponent } from './common/accessdenied/accessdenied.component';






@NgModule({
  declarations: [
    AreaComponent,
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    AccessdeniedComponent,

  ],

  imports: [
    AreaRoutingModule, 
    SharedModule
  ],
  exports: [FooterComponent, NavbarComponent, SidebarComponent],
  providers: []
})
export class AreaModule { }
