import { ResearchesComponent } from './researches.component';
import { NgModule } from "@angular/core";
import { SharedModule } from "app/shared/shared.module";
import { ResearchesRoutingModule } from './researches-routing.module';



@NgModule({
    imports: [ResearchesRoutingModule, SharedModule],
    declarations: [ResearchesComponent]
})

export class ResearchesModule {
}