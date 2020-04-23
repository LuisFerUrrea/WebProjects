import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClienteModel } from '../models/cliente.model';
import { MyResponseModel } from '../models/myresponse.model';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}

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

  public Add(cliente: ClienteModel): Observable<MyResponseModel> {
    return this.http.post<MyResponseModel>(this.baseUrl + "api/Cliente/Add", { 'nombre': cliente.nombre, 'correo': cliente.correo, 'tipoAlmacenamiento': cliente.tipoAlmacenamiento }, httpOptions);
    //subscribe(result => {
    // return result;
    //},
    //  error => console.error(error)
    //);
  }
  public Update(cliente: ClienteModel): Observable<MyResponseModel> {
    return this.http.post<MyResponseModel>(this.baseUrl + "api/Cliente/Edit", { 'id': cliente.id, 'nombre': cliente.nombre, 'correo': cliente.correo, 'tipoAlmacenamiento': cliente.tipoAlmacenamiento }, httpOptions);
    //subscribe(result => {
    // return result;
    //},
    //  error => console.error(error)
    //);
  }

  public delete(cliente: ClienteModel) {
    return this.http.post<MyResponseModel>(this.baseUrl + "api/Cliente/Delete", { 'id': cliente.id }, httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.error(error)
      );
  }

}
