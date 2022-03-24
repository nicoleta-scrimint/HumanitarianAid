import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SheltersComponent } from './shelters/shelters.component';
import { PersonsComponent } from './persons/persons.component';
import { ContactComponent } from './contact/contact.component';

const components = [SheltersComponent, PersonsComponent, ContactComponent];

@NgModule({
  declarations: [components],
  imports: [CommonModule],
  exports: [components],
})
export class FeaturesModule {}
