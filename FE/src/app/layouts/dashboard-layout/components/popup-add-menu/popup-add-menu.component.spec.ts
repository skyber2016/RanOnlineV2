import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PopupAddMenuComponent } from './popup-add-menu.component';

describe('PopupAddMenuComponent', () => {
  let component: PopupAddMenuComponent;
  let fixture: ComponentFixture<PopupAddMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PopupAddMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PopupAddMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
