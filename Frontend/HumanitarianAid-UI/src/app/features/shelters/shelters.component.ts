import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

import { Shelter } from '../../shared';
import { SheltersService } from './services';

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
    private readonly snackBar: MatSnackBar
  ) {}

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
        this.snackBar.open(error.message, '', {
          duration: 3000,
          horizontalPosition: 'right',
          verticalPosition: 'top',
          panelClass: ['error-snackbar'],
        });
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
}
