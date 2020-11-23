import { NgModule } from "@angular/core";
import { Router, RouterModule, Routes } from "@angular/router";
import { FellowModule } from "../fellow.module";
import { AllFellowComponent } from "./all-fellow.component";
import { AllFellowModule } from "./all-fellow.module";


const routes: Routes = [
    {
        path: '', component: AllFellowComponent
    }

]

@NgModule({
    providers: [],
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AllFellowRoutingModule {

}

export const routedComponents = [AllFellowComponent];