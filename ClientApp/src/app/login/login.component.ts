import { Component, OnInit, Inject } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { AuthDataModel, UserModel } from '../utils/models';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  LoginData: AuthDataModel = {login: "admin", password: "P@ssw0rd!"};
  url: string;
  Error: string;

  constructor( private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private authService: AuthService, private router: Router) {
    this.url = baseUrl;
  }

  ngOnInit() {
    if(this.authService.isAuthenticated()){
      this.router.navigate(['']);
    }
  }

  async submit(){
    this.authService.logIn(this.LoginData).subscribe((res: UserModel)=>{
      if(res == null){
        this.Error = "Failed to connect to server";
        return;
      }

      if(res.error != null){
        this.Error = res.error;
        return;
      }

      localStorage.setItem('GUID', res.guid);
      localStorage.setItem('Type', String(res.type));
      localStorage.setItem('Id', String(res.id));
      localStorage.setItem('Login', res.login);
      localStorage.setItem('Name', res.name);
      localStorage.setItem('Mail', res.mail);
      
      window.location.reload();
    }),error=>{
      console.log(`${error.status} ${error.statusText} -  ${error.url}`);
    };
    
  }

  HideError(){
    this.Error = null;
  }

}
