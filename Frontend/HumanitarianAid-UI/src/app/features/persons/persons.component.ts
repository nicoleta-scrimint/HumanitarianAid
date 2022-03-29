import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Person } from 'src/app/shared';

import { PersonsService } from './services';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.scss']
})
export class PersonsComponent implements OnInit {
  persons: Person[] = [];
  filteredPersons: Person[] = [];
  displayedColumns: ['name', 'surname', 'age', 'gender']

  constructor(
    private readonly service: PersonsService,
    private readonly snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.getPersons();
  }
  
  // private buildFilterForm(): void {
  //   this.filterForm = new FormGroup({
  //     shelterName: new FormControl(''),
  //     availablePlaces: new FormControl(''),
  //   });

  //   this.filterForm.controls['shelterName'].valueChanges.subscribe((value) => {
  //     this.filterPersonssByPersonName(value);
  //   });

  //   this.filterForm.controls['availablePlaces'].valueChanges.subscribe(
  //     (value) => {
  //       this.filterSheltersByAvailablePlaces(value);
  //     }
  //   );
  // }

  private getPersons(): void {
    this.service.getPersons().subscribe(
      (data: Person[]) => {
        this.persons = data;
        this.filteredPersons = this.persons;
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
  
  private filterPersonssByPersonName(personName: string): void {
    this.filteredPersons = this.persons.filter((person: Person) =>
      person.name.toLowerCase().includes(personName.toLowerCase())
    );
  }
}
