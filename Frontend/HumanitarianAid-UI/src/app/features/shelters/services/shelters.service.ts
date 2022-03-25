import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { Shelter } from '../../../shared';

@Injectable({
  providedIn: 'root',
})
export class SheltersService {
  constructor(private readonly http: HttpClient) {}

  getShelters() {
    return this.http.get(environment.sheltersApiUrl + '/Shelters').pipe(
      map(
        (result: any) => {
          return result;
        },
        (error: any) => {
          return error;
        }
      )
    );
  }

  registerShelters(shelter: Shelter) {
    return this.http
      .post(environment.sheltersApiUrl + '/Shelters', shelter)
      .pipe(
        map(
          (result: any) => {
            return result;
          },
          (error: any) => {
            return error;
          }
        )
      );
  }
}
