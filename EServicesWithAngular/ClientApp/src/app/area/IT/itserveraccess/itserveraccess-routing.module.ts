import { NgModule } from "@angular/core";
import { Routes, Router, RouterModule } from "@angular/router";
import { ITserverAccessComponent } from "./itserveraccess.component";

export const routes: Routes = [{
    path: '', component: ITserverAccessComponent,
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ITserverAccessRoutingModule {

    static components = [ITserverAccessComponent];
}