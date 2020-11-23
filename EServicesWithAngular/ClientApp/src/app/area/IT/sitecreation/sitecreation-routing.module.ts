import { SiteCreationComponent } from './sitecreation.component';
import { NgModule } from "@angular/core";
import { Routes, RouterModule, Router } from "@angular/router";


export const routes: Routes =
    [{
        path: '', component: SiteCreationComponent
    }]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

})

export class SiteCreationRoutingModule {
    static components = [SiteCreationComponent]

}
