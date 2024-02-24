import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LicaoPage } from './licao.page';

const routes: Routes = [
  {
    path: '',
    component: LicaoPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LicaoPageRoutingModule {}
