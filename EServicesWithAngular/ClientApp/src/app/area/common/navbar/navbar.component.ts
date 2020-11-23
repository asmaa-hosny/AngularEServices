import { Component, OnInit, ElementRef, Output, EventEmitter, HostListener, Input } from '@angular/core';
import { ROUTES } from '../sidebar/sidebar.component';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { Router } from '@angular/router';
import { NavbarService } from 'app/core/services/navbar.service';
import { EmployeeService } from 'app/core/services/employee.service';
import { empty } from 'rxjs';
import { DashboardService } from 'app/core/services/dashboard.service';
import { LocalizationService } from 'app/core/services/localization.service';
import { TranslateService } from '@ngx-translate/core';
import { DataService } from 'app/core/services/data.service';
import { EventType } from 'app/shared/helpers/enum';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {



    employeeEmail;
    private listTitles: any[];
    location: Location;
    mobile_menu_visible: any = 0;
    private toggleButton: any;
    private sidebarVisible: boolean;
    employees
    result
    empName = "My Dashboard"
    constructor(location: Location, private element: ElementRef, private router: Router,public translate: TranslateService,
        public nav: NavbarService, public dashboardService: DashboardService,
        public translateService: TranslateService,
         public localizationService: LocalizationService, 
         public dashService: DashboardService,
         public inOutService:DataService) {
        this.location = location;
        
        this.sidebarVisible = false;
    }

    ngOnInit() {
        this.inOutService.getMessage(EventType.EmployeeSelected).subscribe(response=>
            {
                //this.employeeEmail=response.text;
                this.dashboardService.FindSubordinates(this.employeeEmail).subscribe(res => this.employees = res);
            });
      
        this.listTitles = ROUTES.filter(listTitle => listTitle);
        const navbar: HTMLElement = this.element.nativeElement;
        this.toggleButton = navbar.getElementsByClassName('navbar-toggler')[0];
        this.router.events.subscribe((event) => {
            this.sidebarClose();
            var $layer: any = document.getElementsByClassName('close-layer')[0];
            if ($layer) {
                $layer.remove();
                this.mobile_menu_visible = 0;
            }
        });
    }

    switchLanguage() {

        var isEnglish = this.localizationService.isEnglish;

        if (isEnglish) {
            this.localizationService.setLanguage(this.translateService, "ar-SA");
        }


        else {
            this.localizationService.setLanguage(this.translateService, "en-US");
        }

    }

  

    sidebarOpen() {
        const toggleButton = this.toggleButton;
        const body = document.getElementsByTagName('body')[0];
        setTimeout(function () {
            toggleButton.classList.add('toggled');
        }, 500);

        body.classList.add('nav-open');

        this.sidebarVisible = true;
    };
    sidebarClose() {
        const body = document.getElementsByTagName('body')[0];
       
        if( this.toggleButton){
            this.toggleButton.classList.remove('toggled');
            this.sidebarVisible = false;
            body.classList.remove('nav-open');
           
        }
       
    };
    sidebarToggle() {
        // const toggleButton = this.toggleButton;
        // const body = document.getElementsByTagName('body')[0];
        var $toggle = document.getElementsByClassName('navbar-toggler')[0];

        if (this.sidebarVisible === false) {
            this.sidebarOpen();
        } else {
            this.sidebarClose();
        }
        const body = document.getElementsByTagName('body')[0];

        if (this.mobile_menu_visible == 1) {
            // $('html').removeClass('nav-open');
            body.classList.remove('nav-open');
            if ($layer) {
                $layer.remove();
            }
            setTimeout(function () {
                $toggle.classList.remove('toggled');
            }, 400);

            this.mobile_menu_visible = 0;
        } else {
            setTimeout(function () {
                $toggle.classList.add('toggled');
            }, 430);

            var $layer = document.createElement('div');
            $layer.setAttribute('class', 'close-layer');


            if (body.querySelectorAll('.main-panel')) {
                document.getElementsByClassName('main-panel')[0].appendChild($layer);
            } else if (body.classList.contains('off-canvas-sidebar')) {
                document.getElementsByClassName('wrapper-full-page')[0].appendChild($layer);
            }

            setTimeout(function () {
                $layer.classList.add('visible');
            }, 100);

            $layer.onclick = function () { //asign a function
                body.classList.remove('nav-open');
                this.mobile_menu_visible = 0;
                $layer.classList.remove('visible');
                setTimeout(function () {
                    $layer.remove();
                    $toggle.classList.remove('toggled');
                }, 400);
            }.bind(this);

            body.classList.add('nav-open');
            this.mobile_menu_visible = 1;

        }
    };

    getTitle() {
        var titlee = this.location.prepareExternalUrl(this.location.path());
        if (titlee.charAt(0) === '#') {
            titlee = titlee.slice(2);
        }
        titlee = titlee.split('/').pop();

        for (var item = 0; item < this.listTitles.length; item++) {
            if (this.listTitles[item].path === titlee) {
                this.translate.get('Nav.'+ this.listTitles[item].title).subscribe((text:string) =>
                 {
                     this.result=text;
                     return text;
                 });
                 return this.result;
            }
        }
      
         this.translate.get('Nav.Dashboard').subscribe((text:string) => {

              this.result=text;
               return text;
            });
            return this.result;
    }

    changeEmployee(empId, empname) {
        this.empName = empname;
        this.nav.ChangeEmployee(empId);
    }


}
