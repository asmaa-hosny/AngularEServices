import { NgModule } from "@angular/core";
import { SharedModule } from "app/shared/shared.module";
import { ITResignationRoutingModule } from "./itresignation-routing.module";

@NgModule({
    declarations: [ITResignationRoutingModule.components],
    imports: [SharedModule, ITResignationRoutingModule]
})

export class ITResignationModule {


}