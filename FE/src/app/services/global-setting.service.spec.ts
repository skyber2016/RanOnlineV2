import { TestBed } from '@angular/core/testing';

import { GlobalSettingService } from './global-setting.service';

describe('GlobalSettingService', () => {
  let service: GlobalSettingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GlobalSettingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
