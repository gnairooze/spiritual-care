import { TestBed, inject } from '@angular/core/testing';

import { PPersonAddressService } from './p-person-address.service';

describe('PPersonAddressService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PPersonAddressService]
    });
  });

  it('should be created', inject([PPersonAddressService], (service: PPersonAddressService) => {
    expect(service).toBeTruthy();
  }));
});
