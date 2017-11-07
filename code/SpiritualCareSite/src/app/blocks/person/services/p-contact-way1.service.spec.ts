import { TestBed, inject } from '@angular/core/testing';

import { PContactWay1Service } from './p-contact-way1.service';

describe('PContactWay1Service', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PContactWay1Service]
    });
  });

  it('should be created', inject([PContactWay1Service], (service: PContactWay1Service) => {
    expect(service).toBeTruthy();
  }));
});
