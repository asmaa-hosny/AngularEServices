import { ResearchesModule } from './researches/researches.module';
import { OPRModule } from './Opr/opr.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AreaComponent } from './area.component';
import { EmpDashboardComponent } from './employee/emp-dashboard/emp-dashboard.component';
import { EmployeeModule } from './employee/employee.module';
import { DashboardModule } from './employee/emp-dashboard/empdashboard.module';
import { ITModule } from './IT/it.module';
import { AccessdeniedComponent } from './common/accessdenied/accessdenied.component';



const routes: Routes = [
  {
    path: '',
    component: AreaComponent,
    canActivate: [],
    children: [

      { path: '', loadChildren: () => DashboardModule, data: { breadcrumb: 'Dashboard' }, canActivate: [] },
      { path: 'it', loadChildren: () => ITModule },
      { path: 'opr', loadChildren: () => OPRModule },
      { path: 'researches', loadChildren: () => ResearchesModule },
      { path: 'admin', loadChildren: 'app/area/admin/admin.module#AdminModule', data: { breadcrumb: 'Administration' }, canActivate: [] },

      { path: 'employees', loadChildren: () => EmployeeModule, data: { breadcrumb: 'Employees' }, canActivate: [] },
      { path: 'managers', loadChildren: 'app/area/manager/manager.module#ManagerModule', data: { breadcrumb: 'Managers' }, canActivate: [] },
      { path: 'accessdenied',component: AccessdeniedComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class AreaRoutingModule { }

export const routedComponents = [AreaComponent,AccessdeniedComponent];

