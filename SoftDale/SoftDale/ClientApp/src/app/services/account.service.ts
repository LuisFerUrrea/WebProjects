import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsuarioModel } from '../models/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private apiURL = "https://localhost:44388/" + "api/account";

  userToken: string = "";

  // constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  constructor(private http: HttpClient) { }

  create(usuario: UsuarioModel): Observable<any> {
    return this.http.post<any>(this.apiURL + "/Create", usuario);
  }

  leerToken() {
    if (localStorage.getItem('token')) {
      this.userToken = localStorage.getItem('token');
    }
    else {
      this.userToken = "";
    }
    return this.userToken;
  }

  login(usuario: UsuarioModel): Observable<any> {
    return this.http.post<any>(this.apiURL + "/Login", usuario);
  }

  obtenerToken(): string {
    return localStorage.getItem("token");
  }

  obtenerExpiracionToken(): string {
    return localStorage.getItem("tokenExpiration");
  }

  logout() {
    localStorage.removeItem("token");
    localStorage.removeItem("tokenExpiration");
    this.visibleNavBar();
  }

  recibirToken(token: any) {
    localStorage.setItem('token', token.token);
    var getDate = new Date();
    var getDateNew = new Date(getDate.toString());
    getDateNew.setMinutes(getDate.getMinutes() + 180);
    localStorage.setItem('tokenExpiration', getDateNew.getTime().toString());
    //localStorage.setItem('tokenExpiration', token.expiration);
  }

  estaLogueado(): boolean {
    console.log('esta logueado');
    this.visibleNavBar();
    if (localStorage.getItem('token')) {
      if (localStorage.getItem('token').length < 2) {
        return false;
      }
      else {
        const expira = Number(localStorage.getItem('tokenExpiration'));
        const expiraDate = new Date();
        expiraDate.setTime(expira);
        console.log(expiraDate);
        if (expiraDate > new Date()) {
          return true;
        }
        else {
          this.logout();
          return false;
        }
      }
    }
    else
      return false;
  }

  visibleNavBar() {
    let visibleNavBar = document.getElementsByClassName('visibleNavBar') as HTMLCollectionOf<HTMLElement>;
    if (localStorage.getItem("token")) {     
      if (visibleNavBar.length != 0) {
        visibleNavBar[0].style.visibility = "visible";        
      }
    }
    else {
      if (visibleNavBar.length != 0) {
        visibleNavBar[0].style.visibility = "hidden";
       
      }
    }
  }

}
