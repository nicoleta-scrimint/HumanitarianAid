import { Component, Inject, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

import { RegisterFamilyData, Shelter } from '../../models';

@Component({
  selector: 'app-register-family-popup',
  templateUrl: './register-family-popup.component.html',
  styleUrls: ['./register-family-popup.component.scss']
})
export class RegisterFamilyPopupComponent implements OnInit {

  registerFamilyForm: FormGroup = new FormGroup({
    shelter: new FormControl('', Validators.required),
    persons: new FormArray([])
  });
  shelters: Shelter[];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: RegisterFamilyData
  ) { }

  ngOnInit(): void {
    this.addPerson();
  }

  get persons(): FormArray {
    return this.registerFamilyForm.controls["persons"] as FormArray;
  }

  get selectedShelter(): Shelter {
    let selectedShelterId = this.registerFamilyForm.get("shelter").value;
    return this.data.availableShelters.find(shelter => shelter.id === selectedShelterId);
  }

  addPerson(): void {
    const newPersonForm = new FormGroup({
      name: new FormControl('', Validators.required),
      surname: new FormControl('', Validators.required),
      age: new FormControl(null, [Validators.required, Validators.min(0)]),
      gender: new FormControl('', Validators.required),
    });
    this.persons.push(newPersonForm);
  }

  deletePerson(personIndex: number): void {
    this.persons.removeAt(personIndex);
  }

  registerFamily(): void {
    console.log(this.registerFamilyForm);
  }
}
