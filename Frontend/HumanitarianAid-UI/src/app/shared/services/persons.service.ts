import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Person, Shelter } from '../models';

@Injectable({
  providedIn: 'root',
})
export class PersonsService {
  constructor(
    private readonly http: HttpClient
  ) { }

  getPersons(): Observable<any> {
    return this.http.get(`${environment.sheltersApiUrl}/Persons`);
  }

  registerPersonsToShelter(registeredFamily: { shelter: Shelter, persons: Person[] }): Observable<any> {
    return this.http
      .post(environment.sheltersApiUrl + `/Shelters/${registeredFamily.shelter}/persons`, registeredFamily.persons);
  }
}