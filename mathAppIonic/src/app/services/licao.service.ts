import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { jwtDecode } from "jwt-decode";
import { Usuario } from '../models/Usuario';
import { Licao } from '../models/Licao';
import { Atividade } from '../models/Atividade';

@Injectable({
  providedIn: 'root'
})
export class LicaoService {

  urlServidor: string = "http://localhost:5091/api/Licao/";
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*', })
  };

  constructor(private httpClient: HttpClient) { }

  decode(token: string) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace('-', '+').replace('_', '/');
    return JSON.parse(window.atob(base64));
  }

  async getFrontPageLicoes(token: string) {
    const usuario = this.decode(token);

    let url = this.urlServidor + "Inicio/" + usuario.id;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*', 'token': token });
    try {
      return this.httpClient.get(url, { headers, responseType: 'text' });
    } catch (erro) {
      console.log(erro);
    }
    return null;
  }

  async getLicao(token: string, idLicao: string) {
    const usuario = this.decode(token);

    let url = this.urlServidor + idLicao;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*', 'token': token });
    try {
      return this.httpClient.get(url, { headers, responseType: 'text' });
    } catch (erro) {
      console.log(erro);
    }
    return null;
  }

  async finalizarLicao(token:string, licao:Licao){
    const headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*', 'token': token });
    licao.atividades?.forEach((element : Atividade) => {

    });
    try {

    } catch (erro) {
      console.log(erro);
    }
  }
}
