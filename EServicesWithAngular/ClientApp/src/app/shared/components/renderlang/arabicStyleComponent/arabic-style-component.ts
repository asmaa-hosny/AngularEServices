import { Component } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

@Component({

  selector: 'arabic-Style',
  styles: [` .uploadDiv{
    text-align: center;
  }`],
  
  template: `
 
  <link href="https://demos.creative-tim.com/bs3/material-dashboard-pro/assets/css/bootstrap.min.css" rel="stylesheet" />
  <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-rtl/3.4.0/css/bootstrap-rtl.css" rel="stylesheet">
  <link href="https://demos.creative-tim.com/bs3/material-dashboard-pro/assets/css/material-dashboard.css?v=1.3.0" rel="stylesheet" />
    <link href= "/assets/css/demoar.css" rel="stylesheet"/>
 
 
   `,
  

}) 
export class ArabicStyleComponent {

  cssUrl: string;
 
  constructor() {

  }

  ngOnInit() {
    const body = document.getElementsByTagName('body')[0];
    body.classList.add('rtl-active');
  }

}
