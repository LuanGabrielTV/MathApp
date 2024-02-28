import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'inicio',
    pathMatch: 'full'
  },
  {
    path: 'inicio',
    loadChildren: () => import('./inicio/inicio.module').then( m => m.InicioPageModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then( m => m.LoginPageModule)
  },
  {
    path: 'licoes',
    loadChildren: () => import('./licoes/licoes.module').then( m => m.LicoesPageModule)
  },
  {
    path: 'licao',
    loadChildren: () => import('./licao/licao.module').then( m => m.LicaoPageModule)
  },
  {
    path: 'resumo',
    loadChildren: () => import('./resumo/resumo.module').then( m => m.ResumoPageModule)
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
