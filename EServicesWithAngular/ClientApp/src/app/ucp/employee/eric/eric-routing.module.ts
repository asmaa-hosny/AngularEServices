import { NgModule } from "@angular/core";
import { Router, RouterModule, Routes } from "@angular/router";
import { AllEricModule } from "./all-eric/all-eric.module";
import { EricsComponent } from "./erics.component";

const routes: Routes = [
    {
        path: '', component: EricsComponent, children:
            [
                { path: 'all-eric', loadChildren: () => AllEricModule }

            ]
    }

]

@NgModule({
    providers: [],
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class EricRoutingModule {

}