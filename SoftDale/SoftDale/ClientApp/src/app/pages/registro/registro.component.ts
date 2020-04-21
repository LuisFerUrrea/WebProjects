import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { AccountService } from '../../services/account.service';
import { UsuarioModel } from '../../models/usuario.model';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html'
})

export class RegistroComponent implements OnInit {

  usuario: UsuarioModel = new UsuarioModel();
  recordame = false;
  constructor(private auth: AccountService, private router: Router) { }

  ngOnInit() {

  }

  onSubmit(form: NgForm) {
    if (form.invalid) {
      return;
    }

    Swal.fire({
      allowOutsideClick: false,
      icon: 'info',
      text: 'Espere por favor...'
    });
    Swal.showLoading();

    this.auth.create(this.usuario).subscribe(token => {
      Swal.close();
      if (this.recordame) {
        localStorage.setItem('email', this.usuario.email);
      }
      this.auth.recibirToken(token);
      this.router.navigateByUrl('/home');
    }, err => {
      Swal.fire({
        icon: 'error',
        title: 'Error al registrar usuario',
        text: err.error
      });
    });
  }

}

