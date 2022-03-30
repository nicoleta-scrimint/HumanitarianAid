import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';

import { Person } from 'src/app/shared';
import { PersonsService } from 'src/app/shared';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.scss']
})
export class PersonsComponent implements OnInit, AfterViewInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;

  persons: Person[] = [];
  filteredPersons: Person[] = [];
  dataSource = new MatTableDataSource<Person>(this.filteredPersons);
  displayedColumns: string[] = ['name', 'surname', 'age', 'gender'];
  displayedFilterColumns: string[] = ['name-filter', 'surname-filter', 'age-filter', 'gender-filter'];
  genders: { value: string, label: string }[] = [{ value: null, label: '' }, { value: "Male", label: "Male" }, { value: "Female", label: "Female" }, { value: "Other", label: "Other" }]
  filters: Person = {
    name: '',
    surname: '',
    age: null,
    gender: ''
  }

  constructor(
    private readonly service: PersonsService,
    private readonly snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.getPersons();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  filterchanged(value: string | number, field: string): void {
    this.filters[field] = value;
    this.applyFilter();
  }

  private applyFilter(): void {
    this.filteredPersons = [...this.persons];
    if (this.filters.age) {
      this.filteredPersons = this.filteredPersons.filter((
        person: Person
      ) => person.age === Number(this.filters.age));
    }
    if (this.filters.gender) {
      this.filteredPersons = this.filteredPersons.filter((
        person: Person
      ) => person.gender === this.filters.gender);
    }
    if (this.filters.name) {
      this.filteredPersons = this.filteredPersons.filter((
        person: Person
      ) => person.name.includes(this.filters.name));
    }
    if (this.filters.surname) {
      this.filteredPersons = this.filteredPersons.filter((
        person: Person
      ) => person.surname.includes(this.filters.surname));
    }
    console.log(this.filters, this.filteredPersons);
    this.dataSource.filteredData = this.filteredPersons;
    this.dataSource.data = [...this.filteredPersons];
    console.log(this.dataSource.data, this.dataSource.filteredData)
  }

  private getPersons(): void {
    this.service.getPersons().subscribe(
      (data: Person[]) => {
        this.persons = data;
        this.filteredPersons = this.persons;
        this.dataSource.data = [...this.persons];
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
