import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './root/app/app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './root/header/header.component';
import { FooterComponent } from './root/footer/footer.component';
import { LoginComponent } from './login/login.component';
import { AuthGuardService } from './services/auth-guard.service';
import { RuleGuardService } from './services/rule-guard.service';
import { AuthComponent } from './root/auth/auth.component';
import { CORSInterceptor } from './services/xhr-interceptor.service';
import { ApplicationsComponent } from './applications/applications.component';
import { NewApplicationComponent } from './new-application/new-application.component';
import { ApplicationComponent } from './application/application.component';


@NgModule({
  declarations: [
    AppComponent, 
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    AuthComponent,
    ApplicationsComponent,
    NewApplicationComponent,
    ApplicationComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    
    RouterModule.forRoot([
      { 
        path: '', 
        component: HomeComponent, 
        canActivate:[AuthGuardService] 
      },
      { 
        path: 'login', 
        component: LoginComponent 
      },
      { 
        path: 'applications', 
        component: ApplicationsComponent,
        canActivate: [RuleGuardService],
        data:{
          expectedType: 102
        }
      },
      { 
        path: 'new-application', 
        component: NewApplicationComponent,
        canActivate: [RuleGuardService],
        data:{
          expectedType: 102
        }
      },
      { 
        path: 'application/:id', 
        component: ApplicationComponent,
        canActivate: [AuthGuardService]
      }
    ])
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: CORSInterceptor,
    multi: true
  }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
