import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SheltersComponent } from './features/shelters/shelters.component';
import { PersonsComponent } from './features/persons/persons.component';
import { ContactComponent } from './features/contact/contact.component';
import { PageNotFoundComponent } from './views/page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'shelters',
    pathMatch: 'full',
  },
  {
    path: 'shelters',
    component: SheltersComponent,
  },
  {
    path: 'persons',
    component: PersonsComponent,
  },
  {
    path: 'contact',
    component: ContactComponent,
  },
  {
    path: 'page-not-found',
    component: PageNotFoundComponent,
  },
  {
    path: '**',
    redirectTo: '/page-not-found',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
