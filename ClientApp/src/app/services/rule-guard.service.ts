import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class RuleGuardService implements CanActivate {

  constructor(public auth: AuthService, public router: Router) { }

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const expectedType = route.data.expectedType

    if (!this.auth.isAuthenticated()) {
      this.router.navigate(['login']);
      return false;
    }
    
    return Number(localStorage.getItem('Type')) === expectedType;
  } 
}
