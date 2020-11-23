import { NgModule } from "@angular/core";
import { OPRRoutingModule } from "./opr-routing.module";
import { OPRComponent } from "./opr.component";
import { SharedModule } from "app/shared/shared.module";




@NgModule({
    imports: [OPRRoutingModule, SharedModule],
    declarations: [OPRComponent]
})

export class OPRModule {
}