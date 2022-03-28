import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterFamilyPopupComponent } from './register-family-popup.component';

describe('RegisterFamilyPopupComponent', () => {
  let component: RegisterFamilyPopupComponent;
  let fixture: ComponentFixture<RegisterFamilyPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterFamilyPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterFamilyPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
