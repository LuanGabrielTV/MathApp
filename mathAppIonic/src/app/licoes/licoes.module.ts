import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';  
import { IonicModule } from '@ionic/angular';

import { LicoesPageRoutingModule } from './licoes-routing.module';

import { LicoesPage } from './licoes.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule,
    LicoesPageRoutingModule
  ],
  declarations: [LicoesPage]
})
export class LicoesPageModule {}
