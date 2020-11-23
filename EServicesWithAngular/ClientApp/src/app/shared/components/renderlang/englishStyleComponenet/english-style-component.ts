import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({

  selector: 'english-Style',
  template: `
  <link rel="stylesheet" href = "/assets/scss/material-dashboard.scss" >
  <link href= "/assets/css/demo.css" rel="stylesheet" type="text/css" />
  
  ` ,
  styleUrls: ['./english-style.componenet.css'],
})
export class EnglishStyleComponent {

  cssUrl: string;

  constructor(public sanitizer: DomSanitizer) {

  }
  ngOnInit() {
    const body = document.getElementsByTagName('body')[0];
    body.classList.remove('rtl-active');
  }

}