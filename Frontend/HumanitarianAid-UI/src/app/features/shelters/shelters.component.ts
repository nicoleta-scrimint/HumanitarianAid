import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';

import { Shelter } from '../../shared';
import { SheltersService } from './services';
import { RegisterShelterPopupComponent } from './components/register-shelter-popup/register-shelter-popup.component';

@Component({
  selector: 'app-shelters',
  templateUrl: './shelters.component.html',
  styleUrls: ['./shelters.component.scss'],
})
export class SheltersComponent implements OnInit {
  shelters: Shelter[] = [];
  filteredShelters: Shelter[] = [];

  filterForm: FormGroup;

  constructor(
    private readonly service: SheltersService,
    public dialog: MatDialog
  ) {}

  openRegisterShelterPopup(): void {
    let dialogRef = this.dialog.open(RegisterShelterPopupComponent);
    dialogRef.afterClosed().subscribe((result) => {
      if (result.data) {
        this.registerShelter(result.data);
      }
    });
  }

  ngOnInit(): void {
    this.buildFilterForm();
    this.getShelters();
  }

  private buildFilterForm(): void {
    this.filterForm = new FormGroup({
      shelterName: new FormControl(''),
      availablePlaces: new FormControl(''),
    });

    this.filterForm.controls['shelterName'].valueChanges.subscribe((value) => {
      this.filterSheltersByShelterName(value);
    });

    this.filterForm.controls['availablePlaces'].valueChanges.subscribe(
      (value) => {
        this.filterSheltersByAvailablePlaces(value);
      }
    );
  }

  private getShelters(): void {
    this.service.getShelters().subscribe(
      (data: Shelter[]) => {
        this.shelters = data;
        this.filteredShelters = this.shelters;
      },
      (error) => {
        //TODO add toaster
        console.log('Error ' + error);
      }
    );
  }

  private filterSheltersByShelterName(shelterName: string): void {
    this.filteredShelters = this.shelters.filter((shelter) =>
      shelter.name.toLowerCase().includes(shelterName.toLowerCase())
    );
  }

  private filterSheltersByAvailablePlaces(availablePlaces: number): void {
    this.filteredShelters = this.shelters.filter(
      (shelter) => shelter.numberOfPlaces >= availablePlaces
    );
  }

  private registerShelter(shelter: Shelter): void {
    this.service.registerShelters(shelter).subscribe(() => {
      this.getShelters();
    });
  }
}
