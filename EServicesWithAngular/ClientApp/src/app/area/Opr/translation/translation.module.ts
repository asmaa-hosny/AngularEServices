import { NgModule } from "@angular/core";
import { TranslationRoutingModule } from "./translation-routing.module";
import { SharedModule } from "app/shared/shared.module";


@NgModule({
    declarations: [TranslationRoutingModule.components],
    imports: [SharedModule, TranslationRoutingModule]
})

export class TranslationModule {

}

