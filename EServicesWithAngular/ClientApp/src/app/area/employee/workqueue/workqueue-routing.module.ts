import { NgModule } from "@angular/core";
import { WorkQueueComponent } from "./workqueue.component";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
    { path: '', component: WorkQueueComponent }

];

@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})
export class WorkQueueRoutingModule {
    static components = [WorkQueueComponent];
}
