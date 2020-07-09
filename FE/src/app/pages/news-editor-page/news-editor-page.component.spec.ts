import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsEditorPageComponent } from './news-editor-page.component';

describe('NewsEditorPageComponent', () => {
  let component: NewsEditorPageComponent;
  let fixture: ComponentFixture<NewsEditorPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewsEditorPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsEditorPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
