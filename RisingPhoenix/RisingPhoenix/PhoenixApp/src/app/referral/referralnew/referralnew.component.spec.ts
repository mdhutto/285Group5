import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReferralnewComponent } from './referralnew.component';

describe('ReferralnewComponent', () => {
  let component: ReferralnewComponent;
  let fixture: ComponentFixture<ReferralnewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReferralnewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReferralnewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
