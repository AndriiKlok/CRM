import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { AuthDataModel } from '../utils/models';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  url: string;

  constructor(private http: HttpClient,private router: Router, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  public isAuthenticated(): boolean {
    const giud = localStorage.getItem('GUID');
    return giud != null;
  }

  logIn(formData: AuthDataModel): Observable<any> {
    return this.http.post(this.url + 'api/Login/Login', formData);
  }

  isLogged(): Observable<any> {
    const giud = localStorage.getItem('GUID');
    return this.http.post(this.url + 'api/Login/Logged', { giud });
  }

  logOut() {
    const giud = localStorage.getItem('GUID');
    this.http.post(this.url + 'api/Login/Logout', { giud });
    
    localStorage.clear();

    // window.location.reload();
    this.router.navigate(['login']);
  }
}
