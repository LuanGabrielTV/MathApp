import { Component, OnInit } from '@angular/core';
import { Usuario } from '../models/Usuario';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from '../services/usuario.service';
import { ToastController } from '@ionic/angular';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';  

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  form: FormGroup;
  usuario: Usuario;
  toastController: ToastController;
  isToastOpen: boolean;


  constructor(private fBuilder: FormBuilder, private usuarioService: UsuarioService, private tController: ToastController, private router:Router) {
    this.usuario = new Usuario();
    this.form = this.fBuilder.group({
      'email': [this.usuario.email, Validators.compose([
        Validators.minLength(8),
        Validators.required])],
      'senha': [this.usuario.senha, Validators.compose([
        Validators.minLength(8),
        Validators.maxLength(15),
        Validators.required])]
    });
    this.toastController = tController;
    this.isToastOpen = false;
  }

  ngOnInit() {
  }

  ionViewWillEnter() {
    this.form.reset();
  }

  onSubmit() {
    this.usuario.email = this.form.get('email')?.value;
    this.usuario.senha = this.form.get('senha')?.value;
    let token:any;
    this.usuarioService.login(this.usuario).then(res => {
      res?.subscribe(data => {
        token = data;
        if(token!=null){
          localStorage.setItem('token', token);
          this.router.navigate(['licoes']);
        }else{
          this.setOpen(true);
        }
      });
    });
   
  }

  setOpen(set: boolean) {
    this.isToastOpen = set;
  }
}  