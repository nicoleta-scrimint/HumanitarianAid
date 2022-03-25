import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SheltersComponent } from './shelters/shelters.component';
import { PersonsComponent } from './persons/persons.component';
import { ContactComponent } from './contact/contact.component';
import { ShelterCardComponent } from './shelters/components/shelter-card/shelter-card.component';

@NgModule({
  declarations: [SheltersComponent, PersonsComponent, ContactComponent, ShelterCardComponent],
  imports: [CommonModule],
  exports: [SheltersComponent, PersonsComponent, ContactComponent],
})
export class FeaturesModule {}
