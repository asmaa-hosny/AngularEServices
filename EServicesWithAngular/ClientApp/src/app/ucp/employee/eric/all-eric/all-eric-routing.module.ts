import { NgModule } from "@angular/core";
import { Router, RouterModule, Routes } from "@angular/router";
import { AllEricComponent } from "./all-eric.component";



const routes: Routes = [
    {
        path: '', component: AllEricComponent
    }

]

@NgModule({
    providers: [],
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AllEricRoutingModule {

}

export const exportedCompoenent=[AllEricComponent]