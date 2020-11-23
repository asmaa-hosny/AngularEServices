import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { routedComponents, EmployeesRoutingModule } from './empoyee-routing.module';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule } from '@angular/forms';

import { SharedModule } from 'app/shared/shared.module';



@NgModule({
  declarations: [routedComponents],
  imports: [SharedModule,EmployeesRoutingModule]
})
export class EmployeeModule { }
