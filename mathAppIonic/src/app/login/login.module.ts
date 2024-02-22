import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';  
import { FormsModule } from '@angular/forms';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { LoginPageRoutingModule } from './login-routing.module';

import { LoginPage } from './login.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    LoginPageRoutingModule,
    RouterModule,
    ReactiveFormsModule
  ],
  declarations: [LoginPage]
})
export class LoginPageModule {}
