import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Licao } from '../models/Licao';

@Injectable({
  providedIn: 'root'
})
export class MatriculaService {
  urlServidor: string = "http://localhost:5091/api/UsuarioHasLicao/";
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*', })
  };
  constructor(private httpClient: HttpClient) {}

  decode(token: string) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace('-', '+').replace('_', '/');
    return JSON.parse(window.atob(base64));
  }

  async finalizarLicao(token:string, licao:Licao){
    const usuario = this.decode(token);
    let o:Object = new Object();
    if(licao.idLicao!=null && usuario.id!=null){
      try {
        let url = this.urlServidor + usuario.id + "/" + licao.idLicao;
        console.log(JSON.stringify(o));
        this.httpClient.patch<any>(url, JSON.stringify(o), this.httpOptions).subscribe((data)=>{
          console.log(data);
        });
      } catch (error) {
        console.log(error);
      }
    }
    return null;
  }

}
