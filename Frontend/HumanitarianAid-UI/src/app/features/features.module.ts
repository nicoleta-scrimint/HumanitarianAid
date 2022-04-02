import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { NgModule } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';

import { ContactComponent } from './contact/contact.component';
import { ShelterCardComponent } from './shelters/components/shelter-card/shelter-card.component';
import { RegisterShelterPopupComponent } from './shelters/components/register-shelter-popup/register-shelter-popup.component';

import { SheltersService } from './shelters/services';
import { PersonsComponent } from './persons/persons.component';
import { SheltersComponent } from './shelters/shelters.component';
import { PersonsService } from './persons/services';

const materialImports = [
  MatButtonModule,
  MatIconModule,
  MatInputModule,
  MatSnackBarModule,
  MatDialogModule,
  MatTableModule,
  MatSnackBarModule,
  MatPaginatorModule,
  MatSelectModule,
  MatInputModule,
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
  providers: [SheltersService, PersonsService],
})
export class FeaturesModule {}
