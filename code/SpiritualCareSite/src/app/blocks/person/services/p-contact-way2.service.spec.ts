import { TestBed, inject } from '@angular/core/testing';

import { PContactWay2Service } from './p-contact-way2.service';

describe('PContactWay2Service', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PContactWay2Service]
    });
  });

  it('should be created', inject([PContactWay2Service], (service: PContactWay2Service) => {
    expect(service).toBeTruthy();
  }));
});
