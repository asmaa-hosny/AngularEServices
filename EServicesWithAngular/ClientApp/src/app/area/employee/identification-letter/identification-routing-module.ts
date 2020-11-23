import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IdentificationLetterComponent } from './identification-letter.component';
import { TranslationLoaderResolver } from 'app/core/services/translation-loader.resolver';



const routes: Routes = [
    { path: '', component: IdentificationLetterComponent }
];

@NgModule({
    imports: [ RouterModule.forChild(routes) ],
    exports: [ RouterModule ]
})
export class IdentificationRoutingModule {
  
}

export const components = [IdentificationLetterComponent];