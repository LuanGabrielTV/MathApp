import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';  
import { LicaoService } from '../services/licao.service';
import { Licao } from '../models/Licao';

@Component({
  selector: 'app-licoes',
  templateUrl: './licoes.page.html',
  styleUrls: ['./licoes.page.scss'],
})
export class LicoesPage implements OnInit {

  token:any;
  licoes: any[];
  isToastOpen: boolean;

  constructor(private router: Router, private licaoService: LicaoService) { 
    this.token = localStorage.getItem('token');
    this.licoes = [];
    this.isToastOpen = false;
  }

  ngOnInit() {
    this.token = localStorage.getItem('token');
    if(this.token == null){
      this.router.navigate(['login']);
    }
    this.licaoService.getFrontPageLicoes(this.token).then(res => {
      res?.subscribe(data => {
        this.parseLicoes(JSON.parse(data)['$values']);
      })
    })
  }

  async parseLicoes(data: any[]){
    data.forEach((element: any) => {
      this.licoes.push(new Licao(element.idLicao, element.nome, element.matriculado, element.recompensa));
    });
  }

  setOpen(set: boolean) {
    this.isToastOpen = set;
  }

  acessarLicao(licao:Licao){
    if(!licao.matriculado){
      this.setOpen(true);
    }
  }

  logout(){
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

}
