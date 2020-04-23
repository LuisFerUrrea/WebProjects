import { Component, OnInit, ViewChild } from '@angular/core';
import { ClienteModel } from '../../models/cliente.model';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html'
})
export class ClientesComponent implements OnInit {

  cliente: ClienteModel;
  clientes: ClienteModel[] = [];
  dataSource = null;
  cargando = false;
  displayedColumns: string[] = ['id', 'nombre', 'correo', 'acciones'];

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;



  constructor(private clienteService: ClienteService) { }


  ngOnInit() {
    this.cargando = true;
    this.clienteService.GetClientes()
      .subscribe(resp => {
        console.log(resp);
        this.dataSource = new MatTableDataSource<ClienteModel>(resp);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        console.log(this.dataSource);
      });
  }

}
