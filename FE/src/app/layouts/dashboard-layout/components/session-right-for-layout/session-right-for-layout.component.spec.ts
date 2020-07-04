import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SessionRightForLayoutComponent } from './session-right-for-layout.component';

describe('SessionRightForLayoutComponent', () => {
  let component: SessionRightForLayoutComponent;
  let fixture: ComponentFixture<SessionRightForLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SessionRightForLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SessionRightForLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
