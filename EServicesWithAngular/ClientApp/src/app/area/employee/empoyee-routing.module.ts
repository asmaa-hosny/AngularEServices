import { EmployeeComponent } from "./employee.component";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { IdentificationLetterComponent } from "./identification-letter/identification-letter.component";
import { AreaComponent } from "../area.component";
import { IdentificationModule } from "./identification-letter/identification-letter-module";
import { RequisitionComponent } from "./requisition/requisition.component";
import { TranslationLoaderResolver } from "app/core/services/translation-loader.resolver";
import { RequisitionModule } from "./requisition/requisition.module";
import { MissionCompletionModule } from "./mission-completion/mission-completion.module";
import { WorkQueueComponent } from "./workqueue/workqueue.component";
import { WorkQueueModule } from "./workqueue/workqueue.module";



const routes: Routes = [
    { 
        path: '', 
        component: EmployeeComponent,
        children: [
            { path: 'identificationletter', loadChildren: ()=>IdentificationModule },
            { path: 'requisition', loadChildren: ()=>RequisitionModule },
            { path: 'missioncompletion', loadChildren: ()=>MissionCompletionModule },
            { path: 'wq', loadChildren: ()=>WorkQueueModule },
            
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
    providers: []
})
export class EmployeesRoutingModule { }

export const routedComponents = [EmployeeComponent];
