import { Component, OnInit, ViewChild } from '@angular/core';
import { LicaoService } from '../services/licao.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Licao } from '../models/Licao';
import { Atividade } from '../models/Atividade';
import { createAnimation, Animation } from '@ionic/core';
import { UsuarioService } from '../services/usuario.service';
import { MatriculaService } from '../services/matricula.service';
import { AnimationController, IonModal, ModalController } from '@ionic/angular';




@Component({
  selector: 'app-licao',
  templateUrl: './licao.page.html',
  styleUrls: ['./licao.page.scss'],
})
export class LicaoPage implements OnInit {
  @ViewChild(IonModal) modal: IonModal | undefined
  token: any;
  licao: any;
  atividades: any = [];
  isModalOpen = false;
  prox: any;

  switchModal() {
    this.isModalOpen = !this.isModalOpen;
  }

  constructor(private router: Router, private licaoService: LicaoService, private matriculaService: MatriculaService, private usuarioService: UsuarioService, private modalCtrl: ModalController) {
    this.token = localStorage.getItem('token');
  }

  ngOnInit() {
    this.token = localStorage.getItem('token');
    if (this.token == null) {
      this.router.navigate(['login']);
    }


  }


  ionViewDidEnter() {
    const idLicao = this.router.parseUrl(this.router.url).queryParams['idLicao'];
    let isFinished = this.router.parseUrl(this.router.url).queryParams['isFinished'];
    if (idLicao != null && isFinished=='false') {
      this.licaoService.getLicao(this.token, idLicao).then(res => {
        res?.subscribe(data => {
          this.parseLicao(JSON.parse(data));
        })
      })
      let idProx: number = +idLicao;
      this.licaoService.getLicao(this.token, (idProx + 1).toString()).then(res => {
        res?.subscribe(data => {
          let info = JSON.parse(data);
          this.prox = new Licao(info.idLicao, info.nome, info.matriculas, info.recompensa);
        })
      })
    } else {
      this.router.navigate(['licoes']);
    }
  }

  parseLicao(data: any) {
    this.licao = new Licao(data.idLicao, data.nome, data.matriculas, data.recompensa);
    this.licao.conteudo = data.conteudo.replaceAll('\n', '<br><br>');
    data.atividades['$values'].forEach((element: any) => {
      this.atividades.push(new Atividade(element.idAtividade, element.enunciado, element.conteudo, element.questao, element.solucao));
    });
    if (this.licao.matriculas.isFinished) {
      this.router.navigate(['resumo'], {
        queryParams:
          { idLicao: this.licao.idLicao }
      });
    }
  }



  selecionar(atividade: Atividade, alternativa: string, target: any, index: number) {
    let selector: string = "#a" + atividade.idAtividade?.toString();
    const card = document.querySelector<HTMLElement>(selector)!;
    selector = "#q" + atividade.idAtividade?.toString() + alternativa;
    const botao = document.querySelector<HTMLElement>(selector)!;
    if (alternativa != atividade.solucao) {
      card.animate({
        borderColor: ["#ffffff", "#ff9999", "#ffffff", "#ff9999"],
        transform: ["translateX(0px)", "translateX(-10px)", "translateX(10px)", "translateX(0px)"]
      }, 500);
      botao.style.setProperty("--background", "#ffd2d2");
      botao.style.setProperty("--border-color", "#ffd2d2");
      card.style.setProperty('border', "3px solid #ff9999");
      this.atividades[this.atividades.indexOf(atividade)].isFinished = false;
    } else {
      card.animate({
        borderColor: ["#ffffff", "#77ff8a"],
        transform: ["translateY(0px)", "translateY(-10px)", "translateY(0px)"]
      }, 375);
      card.style.setProperty('border', "3px solid #77ff8a");
      botao.style.setProperty("--background", "#afffba");
      botao.style.setProperty("--border-color", "#afffba");

      this.atividades[this.atividades.indexOf(atividade)].isFinished = true;
    }
    console.log(this.atividades);
  }

  isFinishedAtividade(element: any, index: any, array: any) {
    return element.isFinished;
  }

  finalizarLicao() {
    if (this.licao.matriculas['$values'][0].isFinished) {
      this.router.navigate(['resumo'], {
        queryParams:
          { idLicao: this.licao.idLicao }
      });
    }
    this.modal?.dismiss();
    this.matriculaService.finalizarLicao(this.token, this.licao).finally(() => { this.matricularUsuario(); });
  }

  matricularUsuario() {
    this.usuarioService.matricular(this.token, this.licao).finally(() => { this.progredirUsuario(); });
  }

  progredirUsuario() {
    this.usuarioService.progredir(this.token, this.licao);
    this.router.navigate(['licoes']);
  }


}
