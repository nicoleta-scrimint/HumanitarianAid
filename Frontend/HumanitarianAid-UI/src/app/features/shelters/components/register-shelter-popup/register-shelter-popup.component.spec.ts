import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterShelterPopupComponent } from './register-shelter-popup.component';

describe('RegisterShelterPopupComponent', () => {
  let component: RegisterShelterPopupComponent;
  let fixture: ComponentFixture<RegisterShelterPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RegisterShelterPopupComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterShelterPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
