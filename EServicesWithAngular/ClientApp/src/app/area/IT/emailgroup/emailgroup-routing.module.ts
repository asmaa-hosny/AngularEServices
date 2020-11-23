import { EmailgroupComponent } from './emailgroup.component';
import { NgModule } from "@angular/core";
import { Routes, Router, RouterModule } from "@angular/router";


export const routes: Routes = [{
    path: '', component: EmailgroupComponent,
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class EmailGroupRoutingModule {

    static components = [EmailgroupComponent];
}
