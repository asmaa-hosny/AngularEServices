import { NgModule } from "@angular/core";
import { Routes, RouterModule, Router } from "@angular/router";
import { ITCAREComponent } from "./itcare.component";


export const routes: Routes =
    [{
        path: '', component: ITCAREComponent,
    }]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

})

export class ITCareRoutingModule {
    static components = [ITCAREComponent]

}
