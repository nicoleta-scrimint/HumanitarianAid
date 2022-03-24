import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SheltersComponent } from './shelters/shelters.component';
import { PersonsComponent } from './persons/persons.component';
import { ContactComponent } from './contact/contact.component';

@NgModule({
  declarations: [SheltersComponent, PersonsComponent, ContactComponent],
  imports: [CommonModule],
  exports: [SheltersComponent, PersonsComponent, ContactComponent],
})
export class FeaturesModule {}
