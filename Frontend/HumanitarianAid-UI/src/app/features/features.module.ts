import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';

import { ContactComponent } from './contact/contact.component';
import { PersonsComponent } from './persons/persons.component';
import { PersonsService } from './persons/services';
import { ShelterCardComponent } from './shelters/components/shelter-card/shelter-card.component';
import { SheltersComponent } from './shelters/shelters.component';

const materialImports = [
  MatTableModule,
  MatSnackBarModule
]

@NgModule({
  declarations: [SheltersComponent, PersonsComponent, ContactComponent, ShelterCardComponent],
  imports: [CommonModule, HttpClientModule, materialImports, ],
  exports: [SheltersComponent, PersonsComponent, ContactComponent],
  providers: [PersonsService]
})
export class FeaturesModule { }
