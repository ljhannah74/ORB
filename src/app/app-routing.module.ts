import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchOrbsComponent } from './search-orbs/search-orbs.component';

const routes: Routes = [
  { path: '', component: SearchOrbsComponent, pathMatch: 'full' },
  { path: 'search-orbs', component: SearchOrbsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
