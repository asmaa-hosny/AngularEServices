import { UcComponent } from './uc.component';
import { NgModule } from "@angular/core";
import { Routes, Router, RouterModule } from "@angular/router";


export const routes: Routes = [{
    path: '', component: UcComponent,
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UcRoutingModule {

    static components = [UcComponent];
}


