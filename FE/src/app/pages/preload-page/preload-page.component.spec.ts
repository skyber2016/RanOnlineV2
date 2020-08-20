import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PreloadPageComponent } from './preload-page.component';

describe('PreloadPageComponent', () => {
  let component: PreloadPageComponent;
  let fixture: ComponentFixture<PreloadPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PreloadPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PreloadPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
