import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { ToastrService } from "ngx-toastr";
import { NgxSpinnerService } from "ngx-spinner";

@Injectable( {providedIn: 'root'})
export class DecoratorService {
     private static translateservice: TranslateService | undefined = undefined;
     private static tostrService: ToastrService | undefined = undefined;
     private static spinnerService: NgxSpinnerService | undefined = undefined;

     public constructor(service: TranslateService,tostr: ToastrService,spinner:NgxSpinnerService) {
         
         DecoratorService.translateservice = service;
         DecoratorService.tostrService=tostr;
         DecoratorService.spinnerService=spinner;
     }
     public static getService(): TranslateService {
         if(!DecoratorService.translateservice) {
             throw new Error('Decorator Services not initialized');
         }
         return DecoratorService.translateservice;
     }

     public static getTostrService(): ToastrService {
        if(!DecoratorService.tostrService) {
            throw new Error('Decorator Services not initialized');
        }
        return DecoratorService.tostrService;
    }

    public static getSpinnerService(): NgxSpinnerService {
        if(!DecoratorService.spinnerService) {
            throw new Error('Decorator Services not initialized');
        }
        return DecoratorService.spinnerService;
    }
}