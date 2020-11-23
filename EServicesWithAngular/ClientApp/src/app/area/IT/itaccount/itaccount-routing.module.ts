import { NgModule } from "@angular/core";
import { Routes, Router, RouterModule } from "@angular/router";
import { ITAccountComponent } from "./itaccount.component";

export const routes: Routes = [{
    path: '', component: ITAccountComponent,
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ITAccountRoutingModule {

    static components = [ITAccountComponent];
}


