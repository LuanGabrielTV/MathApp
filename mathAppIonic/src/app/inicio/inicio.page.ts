import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms'
import { UsuarioService } from '..//services/usuario.service';
import { Usuario } from '../models/Usuario';
@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.page.html',
  styleUrls: ['./inicio.page.scss'],
})
export class InicioPage implements OnInit {
  form: FormGroup;
  usuario:Usuario;

  constructor(private fBuilder: FormBuilder, private usuarioService:UsuarioService) {
    this.usuario = new Usuario();
    this.form = this.fBuilder.group({
      'nome': [this.usuario.nome, Validators.compose([
        Validators.minLength(2),
        Validators.maxLength(15),
        Validators.required])],
      'email': [this.usuario.email, Validators.compose([
        Validators.minLength(8),
        Validators.required])],
      'senha': [this.usuario.senha, Validators.compose([
        Validators.minLength(8),
        Validators.maxLength(15),
        Validators.required])]
    })
  }

  ngOnInit() {
  }

  onSubmit() {
    this.usuario.nome = this.form.get('nome')?.value;
    this.usuario.email = this.form.get('email')?.value;
    this.usuario.senha = this.form.get('senha')?.value;
    this.usuarioService.addUsuario(this.usuario);
  }
}
