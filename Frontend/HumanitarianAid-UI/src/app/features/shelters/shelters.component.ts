import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

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
    private readonly snackBar: MatSnackBar,
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

  private registerShelter(shelter: Shelter): void {
    this.service.registerShelters(shelter).subscribe(
      (data) => {
        this.snackBar.open(
          'The shelter ' + data.name + ' was successfully added!',
          '',
          {
            duration: 3000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
            panelClass: ['success-snackbar'],
          }
        );
        this.getShelters();
      },
      (error) => {
        this.snackBar.open(error.error, '', {
          duration: 3000,
          horizontalPosition: 'right',
          verticalPosition: 'top',
          panelClass: ['error-snackbar'],
        });
      }
    );
  }
}
