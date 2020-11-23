import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmpDashboardComponent } from './emp-dashboard.component';
import { SharedModule } from 'app/shared/shared.module';







const routes: Routes = [
    { path: '', component: EmpDashboardComponent },
   
];



@NgModule({
  imports: [ RouterModule.forChild(routes),SharedModule ],
  exports: [ RouterModule]
})
export class DashboardRoutingModule {
  static components = [ EmpDashboardComponent ];
}