import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClienteModel } from '../models/cliente.model';


@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  public baseUrl: string;

  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public GetClientes(): Observable<ClienteModel[]> {
    return this.http.get<ClienteModel[]>(this.baseUrl + "api/Cliente/ListCliente");
  }

  public GetCliente(id): Observable<ClienteModel> {
    return this.http.get<ClienteModel>(this.baseUrl + "api/Cliente/GetCliente?id=" + id);
  }

}
