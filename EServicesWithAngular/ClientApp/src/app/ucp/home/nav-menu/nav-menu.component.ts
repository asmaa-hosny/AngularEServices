import { Component, OnInit, HostListener, ElementRef, ViewChild } from '@angular/core';




@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  @ViewChild('toggleBoxNotification', {}) toggleBoxNotification: ElementRef;
  @ViewChild('toggleBoxProfile', {}) toggleBoxProfile: ElementRef;
  isExpanded = false;
  useremail;
  fullname
  firstName;
  lastName;
  isFellowOnly;
  isEricAndFellow;
  isAdmin;
  isEricOnly;
  notificationNumber: number;

  isnotifyShow: boolean = false;
  isprofileShow: boolean = false;
  firstNameChar;

  constructor() {
  }
  @HostListener('document:click', ['$event'])

  clickout(event) {

  }
  
  ngOnInit(): void {




  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = true;
    this.isExpanded = !this.isExpanded;
  }
  closeMenu() {
    this.isExpanded = !this.isExpanded;

  }
  showAllNotifaction() {
    if (!this.isnotifyShow)
      this.isnotifyShow = true
    else
      this.isnotifyShow = false;
  }

  closedBox() {
    this.isnotifyShow = false;
  }

  logout() {

  }



}
