import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SheltersComponent } from './shelters/shelters.component';
import { PersonsComponent } from './persons/persons.component';
import { ContactComponent } from './contact/contact.component';

import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

const materialImports = [
  MatButtonModule,
  MatIconModule,
  MatInputModule,
  MatSlideToggleModule,
];

@NgModule({
  declarations: [SheltersComponent, PersonsComponent, ContactComponent],
  imports: [CommonModule, materialImports],
  exports: [SheltersComponent, PersonsComponent, ContactComponent],
})
export class FeaturesModule {}
