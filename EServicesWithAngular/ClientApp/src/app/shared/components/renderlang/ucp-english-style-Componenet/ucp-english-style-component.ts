import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({

  selector: 'ucp-english-Style',
  template: `
  <link rel="stylesheet" href = "/assets/scss/material-dashboard.scss" >
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
  <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500&display=swap" rel="stylesheet">
  <link href= "/assets/css/ucp.css" rel="stylesheet" type="text/css" />
  
  ` ,
  styleUrls: ['./ucp-english-style.componenet.css'],
})
export class UCPEnglishStyleComponent {

  cssUrl: string;

  constructor(public sanitizer: DomSanitizer) {

  }
  ngOnInit() {
    const body = document.getElementsByTagName('body')[0];
    body.classList.remove('rtl-active');
  }

}