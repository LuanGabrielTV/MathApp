import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, FormsModule, Validators } from '@angular/forms';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { RouterModule } from '@angular/router';  

import { InicioPageRoutingModule } from './inicio-routing.module';

import { InicioPage } from './inicio.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    InicioPageRoutingModule,
    ReactiveFormsModule,
    RouterModule
  ],
  declarations: [InicioPage]
})
export class InicioPageModule {

}
