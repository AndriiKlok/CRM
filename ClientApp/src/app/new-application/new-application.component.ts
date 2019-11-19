import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { TaskModel } from '../utils/models';
import { Observable } from 'rxjs';

@Component({
  selector: 'new-application',
  templateUrl: './new-application.component.html',
})
export class NewApplicationComponent implements OnInit {
  url: string;
  Error: string;
  Communication: string;
  Application: TaskModel = {};

  constructor( private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.url = baseUrl;
  }

  ngOnInit() {
    
  }

  HideAlert(){
    this.Error = null;
    this.Communication = null;
  }

  submit(){
    this.AddApplication().subscribe((res: TaskModel)=>{
      if(res == null){
        this.Error = "Failed to connect to server";
        return;
      }

      if(res.error != null){
        this.Error = res.error;
        return;
      }

      this.Communication = "Application is registered in system with number " + res.sid;
    });
  }

  AddApplication(): Observable<TaskModel> {
    return this.http.post(this.url + 'api/Tasks/AddTask', this.Application);
  }
}
