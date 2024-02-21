import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Usuario } from '../models/Usuario';


@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  urlServidor: string = "http://localhost:5091/api/Usuario/";
  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json','Access-Control-Allow-Origin':'*',})
  };

  constructor(private httpClient:HttpClient) { }

  async register(usuario:Usuario){
    try{
      let url = "http://localhost:5091/api/register/";
      this.httpClient.post<Usuario>(url, JSON.stringify(usuario), this.httpOptions).subscribe((data)=> {
        console.log(data);
      });
    }catch(erro){
      console.log(erro);
    }
  }

  async login(usuario:Usuario){
    try{
      let headers = new HttpHeaders({'Content-Type': 'application/json','Access-Control-Allow-Origin':'*',});
      let url = "http://localhost:5091/api/login/";
      return this.httpClient.post(url, JSON.stringify(usuario), {headers, responseType: 'text'})
    }catch(erro){
      console.log(erro);
    }
    return null;
  }
}
