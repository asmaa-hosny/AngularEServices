import { NgModule } from "@angular/core";
import { Router, RouterModule, Routes } from "@angular/router";
import { AllFellowModule } from "./all-fellow/all-fellow.module";
import { FellowProfileModule } from "./fellow-profile/fellow-profile.module";
import { FellowComponent } from "./fellow.component";


const routes: Routes = [
    {
        path: '', component: FellowComponent, children: 
        [
            { path: 'all-fellow', loadChildren: () => AllFellowModule },

            { path: 'fprofile', loadChildren: () => FellowProfileModule }
        ]
    }

]

@NgModule({
    providers: [],
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FellowRoutingModule {

}
