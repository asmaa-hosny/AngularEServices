import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import {TranslationModule} from "./translation/translation.module";
import { TranslationRoutingModule } from "./translation/translation-routing.module";
import { OPRComponent } from "./opr.component";




const routes: Routes = [{

    path: '', component: OPRComponent,
    children: [
        { path: "translation", loadChildren: () => TranslationModule },
 
    ]
}]

@NgModule({
imports:[RouterModule.forChild(routes)],
exports:[RouterModule]

})

export class OPRRoutingModule {

}