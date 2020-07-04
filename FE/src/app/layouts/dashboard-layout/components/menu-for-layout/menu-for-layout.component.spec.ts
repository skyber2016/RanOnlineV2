import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuForLayoutComponent } from './menu-for-layout.component';

describe('MenuForLayoutComponent', () => {
  let component: MenuForLayoutComponent;
  let fixture: ComponentFixture<MenuForLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuForLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuForLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
