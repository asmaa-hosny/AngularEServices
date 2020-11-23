import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';


import { TableListComponent } from './table-list/table-list.component';
import { AreaModule } from './area/area.module';
import { UCPModule } from './ucp/ucp.module';


@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot([

      { path: '', loadChildren: () => AreaModule },
      { path: 'ucp', loadChildren: () => UCPModule },
      { path: '**', redirectTo: '', pathMatch: 'full' },

    ])
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
