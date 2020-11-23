// Angular Imports
import { NgModule } from '@angular/core';

// This Module's Components
import { EmailgroupComponent } from './emailgroup.component';
import { SharedModule } from "app/shared/shared.module";
import { EmailGroupRoutingModule } from './emailgroup-routing.module';

@NgModule({
    declarations: [EmailGroupRoutingModule.components],
    imports: [SharedModule, EmailGroupRoutingModule]
})
export class EmailgroupModule {

}
