import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

import { SheltersComponent } from './shelters/shelters.component';
import { PersonsComponent } from './persons/persons.component';
import { ContactComponent } from './contact/contact.component';
import { ShelterCardComponent } from './shelters/components/shelter-card/shelter-card.component';
import { RegisterShelterPopupComponent } from './shelters/components/register-shelter-popup/register-shelter-popup.component';

import { SheltersService } from './shelters/services';

const materialImports = [
  MatButtonModule,
  MatIconModule,
  MatInputModule,
  MatDialogModule,
];

@NgModule({
  declarations: [
    SheltersComponent,
    PersonsComponent,
    ContactComponent,
    ShelterCardComponent,
    RegisterShelterPopupComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    materialImports,
  ],
  exports: [SheltersComponent, PersonsComponent, ContactComponent],
  providers: [SheltersService],
})
export class FeaturesModule {}
