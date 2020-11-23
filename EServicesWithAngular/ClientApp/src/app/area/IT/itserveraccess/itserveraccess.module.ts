import { NgModule } from "@angular/core";
import { ITserverAccessRoutingModule } from "./itserveraccess-routing.module";
import { SharedModule } from "app/shared/shared.module";


@NgModule({
    declarations: [ITserverAccessRoutingModule.components],
    imports: [SharedModule, ITserverAccessRoutingModule]
})

export class ITserverAccessModule {

}
