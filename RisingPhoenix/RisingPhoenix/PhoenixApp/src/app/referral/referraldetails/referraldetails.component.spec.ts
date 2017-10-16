import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReferraldetailsComponent } from './referraldetails.component';

describe('ReferraldetailsComponent', () => {
  let component: ReferraldetailsComponent;
  let fixture: ComponentFixture<ReferraldetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReferraldetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReferraldetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
