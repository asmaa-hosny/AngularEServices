

import { SharedModule } from 'app/shared/shared.module';
import { MissionCompletionRoutingModule, components } from './mission-completion-routing.module';
import { NgModule } from '@angular/core';



@NgModule({
    imports: [ SharedModule, MissionCompletionRoutingModule ],
    declarations: [ components ]
})
export class MissionCompletionModule { }