import { Component, OnInit, Inject } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { AuthDataModel, UserModel, TaskModel } from '../utils/models';
import { Router } from '@angular/router';


@Component({
  selector: 'app-application',
  templateUrl: './application.component.html'
})
export class ApplicationComponent implements OnInit {
  url: string;
  Error: string;
  Applications: TaskModel[];

  constructor( private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.url = baseUrl;
  }

  ngOnInit() {
    
  }

}
