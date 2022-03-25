import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

import { SheltersComponent } from './shelters/shelters.component';
import { PersonsComponent } from './persons/persons.component';
import { ContactComponent } from './contact/contact.component';
import { ShelterCardComponent } from './shelters/components/shelter-card/shelter-card.component';

import { SheltersService } from './shelters/services';

const materialImports = [
  MatButtonModule,
  MatIconModule,
  MatInputModule,
  MatSlideToggleModule,
];

@NgModule({
  declarations: [
    SheltersComponent,
    PersonsComponent,
    ContactComponent,
    ShelterCardComponent,
  ],
  imports: [CommonModule, HttpClientModule, materialImports],
  exports: [SheltersComponent, PersonsComponent, ContactComponent],
  providers: [SheltersService],
})
export class FeaturesModule {}
