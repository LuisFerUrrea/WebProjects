import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

  constructor(private authService: AccountService, private router: Router) { }

  ngOnInit() {
  }

  salir() {
    this.authService.logout();
    this.router.navigateByUrl('/login');
  }

}
