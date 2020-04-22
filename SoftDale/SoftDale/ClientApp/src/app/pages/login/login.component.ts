import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UsuarioModel } from '../../models/usuario.model';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  usuario: UsuarioModel = new UsuarioModel();
  recordame = false;

  constructor(private auth: AccountService, private router: Router) { }

  ngOnInit() {
    this.auth.logout();
    if (localStorage.getItem('email')) {
      this.usuario.email = localStorage.getItem('email');
      this.recordame = true;
    }
  }

  login(form: NgForm) {
    if (form.invalid) {
      return;
    }

    Swal.fire({
      allowOutsideClick: false,
      icon: 'info',
      text: 'Espere por favor...'
    });
    Swal.showLoading();


    this.auth.login(this.usuario).subscribe(token => {
      this.auth.recibirToken(token);
      Swal.close();

      if (this.recordame) {
        localStorage.setItem('email', this.usuario.email);
      }
      
      this.router.navigateByUrl('/home');
    }, (err) => {
      Swal.fire({
        icon: 'error',
        title: 'Error al autenticar',
        text: err.error["mensajeError"]
      });
    });


  }




}

