import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpResponse,
    HttpErrorResponse
} from '@angular/common/http';
import { retry, catchError, finalize, tap, } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { DecoratorService } from './decorator.service';
import { throwError } from 'rxjs/internal/observable/throwError';
import { Observable } from 'rxjs';
import { Injectable, Injector } from '@angular/core';

@Injectable({
    providedIn: 'root',
})

export class HttpErrorInterceptor implements HttpInterceptor {
    private spinnerService: NgxSpinnerService
    private totalRequests = 0;
    constructor(public injector: Injector) {
        if (!this.spinnerService)
            this.spinnerService = this.injector.get(NgxSpinnerService);

    }
    private decreaseRequests() {
        console.log("totalRequests" +this.totalRequests);
        if(this.totalRequests > 0)this.totalRequests--;
        if (this.totalRequests === 0) {
            this.spinnerService.hide();
        }
    }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.spinnerService.show();
        this.totalRequests++;
        return next.handle(request)
            .pipe(

                tap(response=>{
                   if (response instanceof HttpResponse)
                   {
                       this.decreaseRequests();
                   } 
                }),
                catchError((error: HttpErrorResponse) => {
                    let errorMessage = '';
                    if (error.error instanceof ErrorEvent) {
                        // client-side error
                        errorMessage = `Error: ${error.error.message}`;
                    } else {
                        // server-side error
                        errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
                    }
                    this.decreaseRequests();
                    DecoratorService.getTostrService().error(errorMessage, 'Error');
                   
                    return throwError(errorMessage);
                }),

                finalize(() => {
                   
                  //  this.spinnerService.hide();
                }),

            )

    }
}