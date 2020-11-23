import { NgModule } from "@angular/core";
import { SharedModule } from "app/shared/shared.module";
import {UcCompletionRoutingModule} from "./uc-completion-routing.module"


@NgModule({
    declarations: [UcCompletionRoutingModule.components],
    imports: [SharedModule, UcCompletionRoutingModule]
})
export class UcCompletionModule {

}
