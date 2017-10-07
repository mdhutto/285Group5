import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReferralslipComponent } from './referralslip.component';

describe('ReferralslipComponent', () => {
  let component: ReferralslipComponent;
  let fixture: ComponentFixture<ReferralslipComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReferralslipComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReferralslipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
