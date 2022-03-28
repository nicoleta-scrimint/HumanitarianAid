import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';

import { RegisterFamilyPopupComponent } from './components/register-family-popup/register-family-popup.component';

const materialImports = [
  MatDialogModule,
  MatButtonModule,
  MatIconModule,
  MatInputModule,
  MatRadioModule,
  MatCardModule,
  MatSelectModule
];

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    materialImports
  ],
  declarations: [
    RegisterFamilyPopupComponent
  ],
})
export class SharedModule {}
