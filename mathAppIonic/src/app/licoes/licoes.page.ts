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

  token: any;
  licoes: any[];
  isToastOpen: boolean;


  constructor(private router: Router, private licaoService: LicaoService) {
    this.token = localStorage.getItem('token');
    this.licoes = [];
    this.isToastOpen = false;
    this.ionViewWillEnter()
  }

  ngOnInit() {
    this.licoes = [];
    this.token = localStorage.getItem('token');
    if (this.token == null) {
      this.router.navigate(['login']);
    }
  }

  ionViewWillEnter() {
    this.licoes = [];
    
    console.log("load");
  }

  ionViewDidEnter(){
    this.licoes = [];
    this.licaoService.getFrontPageLicoes(this.token).then(res => {
      res?.subscribe(data => {
        this.parseLicoes(JSON.parse(data)['$values']);
      })
    })
  }

  parseLicoes(data: any[]) {
    this.licoes = [];
    data.forEach((element: any) => {
      this.licoes.push(new Licao(element.idLicao, element.nome, element.matricula, element.recompensa));
    });
    console.log(this.licoes);
  }

  setOpen(set: boolean) {
    this.isToastOpen = set;
  }

  acessarLicao(licao: Licao) {
    if (licao.matriculas != null) {
      if (licao.matriculas.isFinished) {
        this.router.navigate(['resumo'], {
          queryParams:
            { idLicao: licao.idLicao , 'isFinished': licao.matriculas.isFinished }
        });

      } else {
        this.router.navigate(['licao'], {
          queryParams:
            { idLicao: licao.idLicao , 'isFinished': licao.matriculas.isFinished }
        });
      }
    }
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

}
