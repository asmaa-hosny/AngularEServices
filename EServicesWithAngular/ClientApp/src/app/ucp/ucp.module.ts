import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UcpComponent } from './ucp.component';
import { UCPRoutingModule } from './ucp-routing.module';
import { NavMenuComponent } from './home/nav-menu/nav-menu.component';
import { FooterComponent } from './home/app-footer/footer.component';
import { SharedModule } from 'app/shared/shared.module';
import { EricsComponent } from './employee/eric/erics.component';



@NgModule({
  declarations: [UcpComponent,NavMenuComponent,FooterComponent],
  imports: [
    CommonModule,
    UCPRoutingModule,
    SharedModule
  ]
})
export class UCPModule { }
