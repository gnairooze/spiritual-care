import { TestBed, inject } from '@angular/core/testing';

import { PContactWay3Service } from './p-contact-way3.service';

describe('PContactWay3Service', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PContactWay3Service]
    });
  });

  it('should be created', inject([PContactWay3Service], (service: PContactWay3Service) => {
    expect(service).toBeTruthy();
  }));
});
