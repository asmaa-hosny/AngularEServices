import { MissionCompletionComponent } from './mission-completion.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

const routes: Routes = [
    { path: '', component: MissionCompletionComponent }
];

@NgModule({
    imports: [ RouterModule.forChild(routes) ],
    exports: [ RouterModule ]
})
export class MissionCompletionRoutingModule {
  
}

export const components = [MissionCompletionComponent];