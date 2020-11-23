import { NgModule } from "@angular/core";
import { Router, RouterModule, Routes } from "@angular/router";
import { FellowModule } from "../fellow.module";
import { FellowProfileComponent } from "./fellow-profile.component";



const routes: Routes = [
    {
        path: '', component: FellowProfileComponent, children:[]
    }

]

@NgModule({
    providers: [],
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FellowProfileRoutingModule {

}

export const routedComponents = [FellowProfileComponent];