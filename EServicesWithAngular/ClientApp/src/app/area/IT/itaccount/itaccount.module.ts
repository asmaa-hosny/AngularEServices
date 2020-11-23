import { NgModule } from "@angular/core";
import { ITAccountRoutingModule } from "./itaccount-routing.module";
import { SharedModule } from "app/shared/shared.module";


@NgModule({
    declarations: [ITAccountRoutingModule.components],
    imports: [SharedModule, ITAccountRoutingModule]
})

export class ITAccountModule {

}

