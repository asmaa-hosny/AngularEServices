import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, Injector } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';


import { AppRoutingModule } from './app.routing';


import { AppComponent } from './app.component';
import { TableListComponent } from './table-list/table-list.component';
import { TypographyComponent } from './typography/typography.component';
import { IconsComponent } from './icons/icons.component';
import { MapsComponent } from './maps/maps.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { UpgradeComponent } from './upgrade/upgrade.component';

import {
  AgmCoreModule
} from '@agm/core';

import { DashboardService } from './core/services/dashboard.service';
import { HttpClientModule } from '@angular/common/http';

import { CoreModule } from './core/core.module';
import { AdminModule } from './area/admin/admin.module';
//import { SidebarComponent } from './area/common/sidebar/sidebar.component';
import { AreaModule } from './area/area.module';
import { NgxSpinnerModule } from 'ngx-spinner';
import { HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { DecoratorService } from './core/services/decorator.service';
import { DropdownModule } from 'primeng/dropdown';
import { SharedModule } from './shared/shared.module';


import {NgxPrintModule} from 'ngx-print';
import { ToastrModule } from 'ngx-toastr';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MomentDateAdapter, MAT_MOMENT_DATE_FORMATS } from '@angular/material-moment-adapter';
import { LocalizationService } from './core/services/localization.service';
import { ServiceLocator } from './core/componenet/base.component';
import { ITCAREComponent } from './area/IT/itcare/itcare.component';
import { RatingModule } from 'primeng/rating';


export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http ,'../assets/i18n/', ".json");
}

@NgModule({
  imports: [
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    HttpModule,
    RouterModule,
    SharedModule,
    CoreModule,
    SharedModule,
    RatingModule,
    ToastrModule.forRoot({"closeButton":true}),
    AppRoutingModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: createTranslateLoader,
        deps: [HttpClient],
      }
    }),

    
    AgmCoreModule.forRoot({
      apiKey: 'YOUR_GOOGLE_MAPS_API_KEY'
    })
  ],
  declarations: [
    AppComponent,
    
 

  
  ],
  exports: [TranslateModule,SharedModule],
  providers: [DashboardService,DecoratorService,
    {provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE]},
    {provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS}, 
 
  ],
  bootstrap: [AppComponent]
})
export class AppModule {

  constructor(private adapter: DateAdapter<any>,public localizationService : LocalizationService) {
    
  }

 }
