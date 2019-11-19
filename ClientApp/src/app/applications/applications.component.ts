import { Component, OnInit, Inject } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { AuthDataModel, UserModel, TaskModel } from '../utils/models';
import { Router } from '@angular/router';


@Component({
  selector: 'app-applications',
  templateUrl: './applications.component.html'
})
export class ApplicationsComponent implements OnInit {
  url: string;
  Error: string;
  Applications: TaskModel[];

  constructor( private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.url = baseUrl;
  }

  ngOnInit() {
    this.getApplications().subscribe((res: TaskModel[])=>{
      if(res == null){
        this.Error = "Error get applications list";
        return;
      }

      if(res[0].error != null){
        this.Error = res[0].error;
        return;
      }

      this.Applications = res;
    });
  }

  openApplication(application: TaskModel){
    this.router.navigate(['application/' + application.nid]);
  }

  getApplications(): Observable<TaskModel[]> {
    return this.http.post<TaskModel[]>(this.url + 'api/Tasks/GetClientTasks', { });
  }

}
