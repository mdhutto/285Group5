import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReferraleditComponent } from './referraledit.component';

describe('ReferraleditComponent', () => {
  let component: ReferraleditComponent;
  let fixture: ComponentFixture<ReferraleditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReferraleditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReferraleditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
