import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html'
})
export class NavbarComponent implements OnInit {

  constructor(private authService: AccountService, private router: Router) {   
  }

  salir() {
    this.authService.logout();
    this.router.navigateByUrl('/login');
  }

  ngOnInit() {
    
  }

}
