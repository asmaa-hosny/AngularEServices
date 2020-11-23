import { SoftwareComponent } from './software.component';
import { NgModule } from "@angular/core";
import { Routes, RouterModule, Router } from "@angular/router";


export const routes: Routes =
    [{
        path: '', component: SoftwareComponent
    }]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

})

export class SoftwareRoutingModule {
    static components = [SoftwareComponent]

}
