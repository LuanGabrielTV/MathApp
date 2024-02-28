import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Usuario } from '../models/Usuario';
import { Licao } from '../models/Licao';


@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  urlServidor: string = "http://localhost:5091/api/Usuario/";
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*', })
  };

  constructor(private httpClient: HttpClient) { }

  decode(token: string) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace('-', '+').replace('_', '/');
    return JSON.parse(window.atob(base64));
  }

  async register(usuario: Usuario) {
    try {
      let url = "http://localhost:5091/api/register/";
      return this.httpClient.post<Usuario>(url, JSON.stringify(usuario), this.httpOptions);
    } catch (erro) {
      console.log(erro);
    }
    return null;
  }

  async login(usuario: Usuario) {
    try {
      let headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*', });
      let url = "http://localhost:5091/api/login/";
      return this.httpClient.post(url, JSON.stringify(usuario), { headers, responseType: 'text' })
    } catch (erro) {
      console.log(erro);
    }
    return null;
  }

  async matricular(token: string, licao: Licao) {
    const usuario = this.decode(token);
    console.log(usuario);
    console.log(licao);
    if(usuario.id!=null && licao.idLicao!=null){
      try {
        let url = this.urlServidor + "matricular/" + usuario.id + "/" + (licao.idLicao+1);
        this.httpClient.get(url, this.httpOptions).subscribe((data) => {
          return data;
        });
      } catch (error) {
        console.log(error);
      }
    }
    return null;
  }

  async progredir(token:string, licao:Licao){
    const usuario = this.decode(token);
    if(usuario.id!=null && licao.idLicao!=null){
      try {
        let url = this.urlServidor + "progredir";
        let obj  = {
          "idUsuario":usuario.id,
          "XP": licao.recompensa
        };
        const headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*', 'token': token });
        this.httpClient.post(url, JSON.stringify(obj), {headers}).subscribe((data) => {
          return data;
        });
      } catch (error) {
        console.log(error);
      }
    }
    return null;
  }
}
