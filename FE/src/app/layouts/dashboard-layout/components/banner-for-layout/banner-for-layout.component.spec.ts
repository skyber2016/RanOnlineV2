import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BannerForLayoutComponent } from './banner-for-layout.component';

describe('BannerForLayoutComponent', () => {
  let component: BannerForLayoutComponent;
  let fixture: ComponentFixture<BannerForLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BannerForLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BannerForLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
