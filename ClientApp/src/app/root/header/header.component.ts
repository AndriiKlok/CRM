import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  Type: number;

  constructor(public Auth: AuthService, private router: Router, private authService: AuthService) { }

  ngOnInit() {
    this.Type = Number(localStorage.getItem('Type'));
  }

  Home(){
    this.router.navigate(['']);
  }

  Application(){
    this.router.navigate(['applications']);
  }

  NewApplication(){
    this.router.navigate(['new-application']);
  }

  Logout(){
    this.authService.logOut();
  }

}
