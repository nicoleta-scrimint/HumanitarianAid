import { Component, Input, OnInit } from '@angular/core';

import { Shelter } from '../../../../shared';

@Component({
  selector: 'app-shelter-card',
  templateUrl: './shelter-card.component.html',
  styleUrls: ['./shelter-card.component.scss'],
})
export class ShelterCardComponent implements OnInit {
  @Input() shelter: Shelter;
  constructor() {}

  ngOnInit(): void {}
}
