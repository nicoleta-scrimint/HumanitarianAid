import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  private opened = true;
  
  @Input() 
  get menuOpened(): boolean {
    return this.opened;
  }
  @Output() menuOpenedChange = new EventEmitter<boolean>();
  
  set menuOpened(val) {
    this.opened = val;
    this.menuOpenedChange.emit(this.menuOpened);
  }

  updateMenuState(): void {
    this.menuOpened = !this.menuOpened;
  }
  
  constructor() { }

  ngOnInit(): void {
  }

}
