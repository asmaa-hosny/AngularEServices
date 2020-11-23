import { NgModule } from "@angular/core";
import { ITRoutingModule } from "./it.routing.module";
import { ITComponent } from "./it.component";
import { SharedModule } from "app/shared/shared.module";


@NgModule({
    imports: [ITRoutingModule, SharedModule],
    declarations: [ITComponent]
})

export class ITModule {
}