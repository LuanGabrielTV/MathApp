import { Component, OnInit } from '@angular/core';
import { LicaoService } from '../services/licao.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Licao } from '../models/Licao';
import { Atividade } from '../models/Atividade';
import { createAnimation, Animation } from '@ionic/core';




@Component({
  selector: 'app-licao',
  templateUrl: './licao.page.html',
  styleUrls: ['./licao.page.scss'],
})
export class LicaoPage implements OnInit {
  token: any;
  licao: any;
  atividades: any = [];

  constructor(private router: Router, private licaoService: LicaoService) {
    this.token = localStorage.getItem('token');
  }

  ngOnInit() {
    this.token = localStorage.getItem('token');
    if (this.token == null) {
      this.router.navigate(['login']);
    }
    const idLicao = this.router.parseUrl(this.router.url).queryParams['idLicao'];
    console.log(idLicao);
    if (idLicao == null) {
      this.router.navigate(['licoes']);
    } else {
      this.licaoService.getLicao(this.token, idLicao).then(res => {
        res?.subscribe(data => {
          this.parseLicao(JSON.parse(data));
        })
      })
    }
  }

  parseLicao(data: any) {
    this.licao = new Licao(data.idLicao, data.nome, data.matriculas, data.recompensa);
    this.licao.conteudo = data.conteudo.replaceAll('\n', '<br><br>');
    data.atividades['$values'].forEach((element: any) => {
      this.atividades.push(new Atividade(element.idAtividade, element.enunciado, element.conteudo, element.questao, element.solucao));
    })
  }



  selecionar(atividade: Atividade, alternativa: string, target: any, index:number) {
    let selector: string = "#a" + atividade.idAtividade?.toString();
    const card = document.querySelector<HTMLElement>(selector)!;
    selector = "#q" + atividade.idAtividade?.toString() + alternativa;
    const botao = document.querySelector<HTMLElement>(selector)!;
    if (alternativa != atividade.solucao) {
      card.animate({
        borderColor: ["#ffffff", "#ff9999", "#ffffff", "#ff9999"],
        transform: ["translateX(0px)", "translateX(-10px)", "translateX(10px)", "translateX(0px)"]
      }, 500);
      botao.style.setProperty("--background","#ffd2d2");
      card.style.setProperty('border', "3px solid #ff9999");
      this.atividades[this.atividades.indexOf(atividade)].isFinished = false;
    } else {
      card.animate({
        borderColor: ["#ffffff", "#77ff8a"],
        transform: ["translateY(0px)", "translateY(-10px)", "translateY(0px)"]
      }, 375);
      card.style.setProperty('border', "3px solid #77ff8a");
      botao.style.setProperty("--background","#afffba");
      this.atividades[this.atividades.indexOf(atividade)].isFinished = true;
    }
    console.log(this.atividades);
  }

  isFinishedAtividade(element:any, index:any, array:any){
    return element.isFinished;
  }

}
