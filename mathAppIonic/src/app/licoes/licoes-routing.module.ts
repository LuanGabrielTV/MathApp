import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LicoesPage } from './licoes.page';

const routes: Routes = [
  {
    path: '',
    component: LicoesPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LicoesPageRoutingModule {}
