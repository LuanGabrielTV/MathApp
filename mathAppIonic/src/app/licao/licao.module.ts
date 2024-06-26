import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { LicaoPageRoutingModule } from './licao-routing.module';

import { LicaoPage } from './licao.page';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    LicaoPageRoutingModule,
    RouterModule
  ],
  declarations: [LicaoPage]
})
export class LicaoPageModule {}
