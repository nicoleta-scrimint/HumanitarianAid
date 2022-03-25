import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Shelter } from 'src/app/shared';

@Component({
  selector: 'app-register-shelter-popup',
  templateUrl: './register-shelter-popup.component.html',
  styleUrls: ['./register-shelter-popup.component.scss'],
})
export class RegisterShelterPopupComponent implements OnInit {
  registerSheterForm: FormGroup;

  constructor() {}

  ngOnInit(): void {
    this.buildRegisterSheterForm();
  }

  registerShelter() {
    let shelter = {
      name: this.registerSheterForm.get('name').value,
      numberOfPlaces: this.registerSheterForm.get('numberOfPlaces').value,
      address: this.registerSheterForm.get('address').value,
      ownerName: this.registerSheterForm.get('ownerName').value,
      ownerEmail: this.registerSheterForm.get('ownerEmail').value,
      ownerPhone: this.registerSheterForm.get('ownerPhone').value,
    } as Shelter;

    console.table(shelter);
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
