import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PopupAddSubMenuComponent } from './popup-add-sub-menu.component';

describe('PopupAddSubMenuComponent', () => {
  let component: PopupAddSubMenuComponent;
  let fixture: ComponentFixture<PopupAddSubMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PopupAddSubMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PopupAddSubMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
