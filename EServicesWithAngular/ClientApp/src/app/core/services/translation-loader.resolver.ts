import { TranslateService } from "@ngx-translate/core";
import { Injectable } from "@angular/core";
import { RouterStateSnapshot, ActivatedRouteSnapshot } from "@angular/router";
import { Observable, EMPTY, of } from "rxjs";
import { catchError, mergeMap } from "rxjs/operators";

@Injectable()
export class TranslationLoaderResolver {

    constructor(public translate: TranslateService) {
    }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> {
       // return this.translate.get("Text.WithSalary");
        return this.translate.get("Text.WithSalary").pipe(catchError(error => {
            return EMPTY
        }));
    }

}

