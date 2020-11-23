import { NgModule } from "@angular/core";
import { SharedModule } from "app/shared/shared.module";
import { ITCareRoutingModule } from "./itcare-routing.module";


@NgModule({
    declarations: [ITCareRoutingModule.components],
    imports: [SharedModule, ITCareRoutingModule]
})

export class ITCareModule {


}