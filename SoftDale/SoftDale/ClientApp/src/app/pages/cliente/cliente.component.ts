import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClienteService } from '../../services/cliente.service';
import { ClienteModel } from '../../models/cliente.model';
import Swal from 'sweetalert2';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html'
})
export class ClienteComponent implements OnInit {

  cliente: ClienteModel = new ClienteModel();

  constructor(private clienteService: ClienteService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (id !== 'nuevo') {
      this.clienteService.GetCliente(id).subscribe((resp: ClienteModel) => {
        this.cliente = resp;
        this.cliente.id =parseInt(id);
      });
    }
  }

  guardar(form: NgForm) {
    if (form.invalid) {
      console.log("formulario no valido");
      return;
    }

    Swal.fire({
      title: 'Espere',
      allowOutsideClick: false,
      icon: 'info',
      text: 'Espere por favor...'
    });
    Swal.showLoading();

    let peticion: Observable<any>;

    if (this.cliente.id) {
      console.log('update');
      peticion = this.clienteService.Update(this.cliente);
    }
    else {
      console.log('add');
      peticion = this.clienteService.Add(this.cliente);
    }

    peticion.subscribe(resp => {
      Swal.fire({
        title: this.cliente.nombre,
        icon: 'success',
        text: 'Se actualizo correctamente'
      });
    });


  }

}
