import { components } from './../employee/requisition/requisition-routing.module';
import { UcCompletionModule } from './uc-completion/uc-completion.module';
import { ResearchesComponent } from './researches.component';
import { UcModule } from './uc/uc.module';
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { UcRoutingModule } from "./uc/uc-routing.module"





const routes: Routes = [{

    path: '', component: ResearchesComponent,
    children: [
        { path: "consultation", loadChildren: () => UcModule },
        {path: "consultationcompletion", loadChildren: () => UcCompletionModule },
 
    ]

}]

@NgModule({
imports:[RouterModule.forChild(routes)],
exports:[RouterModule]

})

export class ResearchesRoutingModule {

}