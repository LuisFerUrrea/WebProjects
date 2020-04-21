import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private accountService: AccountService,
    private router: Router) { }


  canActivate(): boolean {
    if (this.accountService.estaLogueado()) {
      return true;
    } else {
      this.router.navigateByUrl('/login');
      return false;
    }
  }

}
