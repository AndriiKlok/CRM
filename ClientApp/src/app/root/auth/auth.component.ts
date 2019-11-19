import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserModel } from 'src/app/utils/models';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent{
  constructor(private authService: AuthService) { 
    const giud = localStorage.getItem('GUID');
    if(giud != null){
      this.authService.isLogged().subscribe((res: UserModel) =>{
        if(res == null){
          this.authService.logOut();
        }else if (res.error != null){
          this.authService.logOut();
        } else {
          console.log(res);
        }
      });
    }
  }
}
