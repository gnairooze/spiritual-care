import { TestBed, inject } from '@angular/core/testing';

import { PPhoneService } from './p-phone.service';

describe('PPhoneService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PPhoneService]
    });
  });

  it('should be created', inject([PPhoneService], (service: PPhoneService) => {
    expect(service).toBeTruthy();
  }));
});
