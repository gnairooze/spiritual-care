import { TestBed, inject } from '@angular/core/testing';

import { PEmailService } from './p-email.service';

describe('PEmailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PEmailService]
    });
  });

  it('should be created', inject([PEmailService], (service: PEmailService) => {
    expect(service).toBeTruthy();
  }));
});
