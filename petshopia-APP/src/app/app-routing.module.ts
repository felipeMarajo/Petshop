import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlojamentosComponent } from './alojamentos/alojamentos.component';
import { AnimaisComponent } from './animais/animais.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path: 'alojamentos', component: AlojamentosComponent},
  {path: 'animais', component: AnimaisComponent},
  {path: 'home', component: HomeComponent},
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: '*', redirectTo: 'home', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
