import { EmailgroupModule } from './emailgroup/emailgroup.module';
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ITComponent } from "./it.component";
import { ITAccountModule } from "./itaccount/itaccount.module";
import { ITResignationModule } from "./itresignation/itresignation.module";
import { SiteCreationModule } from "./sitecreation/sitecreation.module";
import { ITCareModule } from "./itcare/itcare.module";
import { SoftwareModule } from "./software/software.module";
import { ITserverAccessModule } from "./itserveraccess/itserveraccess.module";


const routes: Routes = [{

    path: '', component: ITComponent,
    children: [
        { path: "itaccount", loadChildren: () => ITAccountModule },
        { path: "itresignation", loadChildren: () => ITResignationModule },
        { path: "spsitecreation", loadChildren: () => SiteCreationModule },
        { path: "itcare", loadChildren: () => ITCareModule },
        {path : "emailgroup" , loadChildren:() => EmailgroupModule},
        {path: "itserveraccess", loadChildren: () => ITserverAccessModule },
        {path : "software" , loadChildren:() => SoftwareModule}

    ]
}]

@NgModule({
imports:[RouterModule.forChild(routes)],
exports:[RouterModule]

})

export class ITRoutingModule {

}