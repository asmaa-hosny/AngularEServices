import { NgModule } from "@angular/core";
import { Routes, RouterModule, Router } from "@angular/router";
import { ITResignationComponent } from "./itresignation.component";


export const routes: Routes =
    [{
        path: '', component: ITResignationComponent,
        
    }]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

})

export class ITResignationRoutingModule {
    static components = [ITResignationComponent]

}
