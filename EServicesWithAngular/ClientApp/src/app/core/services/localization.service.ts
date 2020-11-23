import { environment } from "environments/environment";
import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";

@Injectable(
  {providedIn: 'root'}
)
export class LocalizationService {

  private _currentLang: string;
  private _isEnglish: boolean;

  get currentLang(): string {

    if (!this._currentLang) {

      var lang = localStorage.getItem(environment.localization.localStorageLangKey);

      if (lang) {
        this._currentLang = lang;
      }

      else
        this._currentLang = environment.localization.defaultLang;

      //this.translateService.use(this.currentLang);

    }

    this._isEnglish = this.isEnglishLanguage();
    return this._currentLang;

  }

  set currentLang(lang: string) {
    this._currentLang = lang;
    this._isEnglish = this.isEnglishLanguage();
  }

  get isEnglish(): boolean {

    return this._isEnglish;

  }

  constructor() {

  }

  getcurrentLang(translateService: TranslateService) {

    if (!this.currentLang) {

      var lang = localStorage.getItem(environment.localization.localStorageLangKey);

      if (lang) {
        this.currentLang = lang;
      }

      else
        this.currentLang = environment.localization.defaultLang;

      translateService.use(this.currentLang);

    }

    this._isEnglish = this.isEnglishLanguage();
    return this.currentLang;
  }

  setLanguage(translateService: TranslateService , lang: string) {

    if (lang) {
      localStorage.setItem(environment.localization.localStorageLangKey, lang)
      this.currentLang = lang;
      translateService.use(lang);
      location.reload();
    }

  }

  private isEnglishLanguage() {

    if (this._currentLang === 'en-US')
      return true;

    return false;

  }

}
