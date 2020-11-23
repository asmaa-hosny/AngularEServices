import { UcCompletionComponent } from './uc-completion.component';

import { NgModule } from "@angular/core";
import { Routes, Router, RouterModule } from "@angular/router";


export const routes: Routes = [{
    path: '', component: UcCompletionComponent,
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UcCompletionRoutingModule {

    static components = [UcCompletionComponent];
}


