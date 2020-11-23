import { NgModule } from "@angular/core";
import { Routes, Router, RouterModule } from "@angular/router";
import { TranslationComponent } from "./translation.component";

export const routes: Routes = [{
    path: '', component: TranslationComponent,
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TranslationRoutingModule {

    static components = [TranslationComponent];
}


