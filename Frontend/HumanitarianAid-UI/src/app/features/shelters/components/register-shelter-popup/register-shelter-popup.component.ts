import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { Shelter } from '../../../../shared';
import { SheltersService } from '../../services';

@Component({
  selector: 'app-register-shelter-popup',
  templateUrl: './register-shelter-popup.component.html',
  styleUrls: ['./register-shelter-popup.component.scss'],
})
export class RegisterShelterPopupComponent implements OnInit {
  registerSheterForm: FormGroup;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: string,
    private dialogRef: MatDialogRef<RegisterShelterPopupComponent>
  ) {}

  ngOnInit(): void {
    this.buildRegisterSheterForm();
  }

  registerShelter(): void {
    let shelter = {
      name: this.registerSheterForm.get('name').value,
      numberOfPlaces: this.registerSheterForm.get('numberOfPlaces').value,
      address: this.registerSheterForm.get('address').value,
      ownerName: this.registerSheterForm.get('ownerName').value,
      ownerEmail: this.registerSheterForm.get('ownerEmail').value,
      ownerPhone: this.registerSheterForm.get('ownerPhone').value,
    } as Shelter;

    this.dialogRef.close({ data: shelter });
  }

  private buildRegisterSheterForm(): void {
    this.registerSheterForm = new FormGroup({
      name: new FormControl('', Validators.required),
      numberOfPlaces: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
      ownerName: new FormControl('', Validators.required),
      ownerEmail: new FormControl('', Validators.required),
      ownerPhone: new FormControl('', Validators.required),
    });
  }
}
