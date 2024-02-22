import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { jwtDecode } from "jwt-decode";
import { Usuario } from '../models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class LicaoService {

  urlServidor: string = "http://localhost:5091/api/Licao/";
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*', })
  };

  constructor(private httpClient: HttpClient) { }

  async getFrontPageLicoes(token: string) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace('-', '+').replace('_', '/');
    const usuario = JSON.parse(window.atob(base64));

    let url = this.urlServidor + "Inicio/" + usuario.id;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*', 'token': token });
    try {
      return this.httpClient.get(url, { headers, responseType: 'text' });
    } catch (erro) {
      console.log(erro);
    }
    return null;
  }
}