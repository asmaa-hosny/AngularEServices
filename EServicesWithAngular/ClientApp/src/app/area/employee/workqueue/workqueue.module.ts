import { NgModule } from "@angular/core";
import { SharedModule } from "app/shared/shared.module";
import { WorkQueueRoutingModule } from "./workqueue-routing.module";

@NgModule({
    imports:[SharedModule,WorkQueueRoutingModule],
    declarations:[WorkQueueRoutingModule.components]

})
export class WorkQueueModule{

}