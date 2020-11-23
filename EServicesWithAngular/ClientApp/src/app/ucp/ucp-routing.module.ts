import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { EricModule } from "./employee/eric/eric.module";
import { FellowModule } from "./employee/fellow/fellow.module";
import { UcpComponent } from "./ucp.component";

const routes: Routes = [
    {
        path: '', component: UcpComponent, 
        children: [

            { path: 'eric', loadChildren: () => EricModule },
            { path: 'fellow', loadChildren: () => FellowModule },

        ]
    }

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
    providers: []
})
export class UCPRoutingModule {

}