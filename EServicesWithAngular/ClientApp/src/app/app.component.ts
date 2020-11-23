import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { DecoratorService } from './core/services/decorator.service';
import { LocalizationService } from './core/services/localization.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isEnglish
  isUCP;
  public constructor(public locale: LocalizationService, decorator: DecoratorService, private router: Router) {

  }

  ngOnInit() {
    this.router.events.subscribe((e) => {
      if (e instanceof NavigationEnd)
        if (e.url.includes("/ucp")) this.isUCP = true;
    });

    if (this.locale.currentLang == "en-US") {

      this.isEnglish = true;
    }
    else {

      this.isEnglish = false;
    }
  }
}
