import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { Injectable } from "@angular/core";
import { tap, catchError, retry } from 'rxjs/operators';

@Injectable()
export class CORSInterceptor implements HttpInterceptor {
  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const giud = localStorage.getItem('GUID');
      const reqClone = req.clone({
        body: { ...req.body, guid: giud }
      });

      return next
        .handle(reqClone)
        .pipe(
          tap(evt => {
            if (evt instanceof HttpResponse) {
              
            }
          }),catchError(this.handleError))
  }

    private handleError(error: any) {
      const errMsg = (error.message) ? error.message :
        error.status ? `${error.status} - ${error.statusText}` : 'Server error';
      console.error(errMsg);
      console.log('Server Error!');
      return Observable.throw(errMsg);
    }
}