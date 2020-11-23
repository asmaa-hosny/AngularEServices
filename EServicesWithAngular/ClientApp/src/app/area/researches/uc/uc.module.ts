import { NgModule } from "@angular/core";

import { SharedModule } from "app/shared/shared.module";
import { UcRoutingModule } from "./uc-routing.module";


@NgModule({
    declarations: [UcRoutingModule.components],
    imports: [SharedModule, UcRoutingModule]
})

export class UcModule {

}

