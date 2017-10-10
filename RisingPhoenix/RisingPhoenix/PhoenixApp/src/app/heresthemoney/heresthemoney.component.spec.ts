import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeresthemoneyComponent } from './heresthemoney.component';

describe('HeresthemoneyComponent', () => {
  let component: HeresthemoneyComponent;
  let fixture: ComponentFixture<HeresthemoneyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeresthemoneyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeresthemoneyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
