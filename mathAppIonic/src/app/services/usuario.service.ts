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

  async addUsuario(usuario:Usuario){
    try{
      let url = "http://localhost:5091/api/register/";
      console.log(JSON.stringify(usuario));
      this.httpClient.post<Usuario>(url, JSON.stringify(usuario), this.httpOptions).subscribe((data)=> {
        console.log(data);
      });
    }catch(erro){
      console.log(erro);
    }
  }
}
