import { Component, OnInit } from '@angular/core';

import { Shelter } from '../../shared';
import { SheltersService } from './services';

@Component({
  selector: 'app-shelters',
  templateUrl: './shelters.component.html',
  styleUrls: ['./shelters.component.scss'],
})
export class SheltersComponent implements OnInit {
  shelters: Shelter[];
  constructor(private readonly service: SheltersService) {}

  ngOnInit(): void {
    this.getShelters();
  }

  getShelters() {
    this.service.getShelters().subscribe(
      (data: Shelter[]) => {
        this.shelters = data;
      },
      (error) => {
        console.log('Error ' + error);
      }
    );
  }
}
