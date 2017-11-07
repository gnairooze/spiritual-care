import { TestBed, inject } from '@angular/core/testing';

import { PAddressService } from './p-address.service';

describe('PAddressService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PAddressService]
    });
  });

  it('should be created', inject([PAddressService], (service: PAddressService) => {
    expect(service).toBeTruthy();
  }));
});
