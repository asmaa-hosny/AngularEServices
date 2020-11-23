import { Component, OnInit } from '@angular/core';
import { LocalizationService } from 'app/core/services/localization.service';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/opr/translation', title: 'Translation',  icon: 'g_translate', class: '' },
    { path: '/it/itcare', title: 'ITCare',  icon:'devices', class: '' },
    { path: '/it/itaccount', title: 'IT Account',  icon:'account_box', class: '' },
    { path: '/it/emailgroup', title: 'Email Group',  icon:'email', class: '' },
    { path: '/it/spsitecreation', title: 'Site Creation',  icon:'web', class: '' },
    { path: '/it/software', title: 'Software',  icon:'get_app', class: '' },
    { path: '/it/itserveraccess', title: 'Server Access',  icon:'lock_open', class: '' },
    //{ path: '/it/itresignation', title: 'Resignation',  icon:'work_off', class: '' },
    // { path: '/user-profile', title: 'User Profile',  icon:'person', class: '' },
    { path: '/employees/wq', title: 'WorkQueue',  icon:'work_outline', class: '' },
    // { path: '/employees/requisition', title: 'Requisition',  icon:'content_paste', class: '' },
    // { path: '/employees/missioncompletion', title: 'Mission',  icon:'library_books', class: '' },
    // { path: '/typography', title: 'Typography',  icon:'library_books', class: '' },
    // { path: '/icons', title: 'Icons',  icon:'bubble_chart', class: '' },
    // { path: '/maps', title: 'Maps',  icon:'location_on', class: '' },
    // { path: '/notifications', title: 'Notifications',  icon:'notifications', class: '' },
    // { path: '/upgrade', title: 'Upgrade to PRO',  icon:'unarchive', class: 'active-pro' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor(public localLang: LocalizationService) { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
    
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
 public closeNav(){
  var menu=  document.getElementById('togglemenu'); 
  var DemoDiv=document.getElementById('wrapperID'); 
     if (menu && DemoDiv&&  this.localLang.isEnglish){
    menu.style.display='none'; 
    DemoDiv.style.marginLeft='-11%';
  }      
  else {
    menu.style.display='none'; 
   DemoDiv.style.marginRight='-11%'; 
  }
  
  

    
 }

}
