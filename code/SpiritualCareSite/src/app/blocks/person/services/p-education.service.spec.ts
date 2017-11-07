import { TestBed, inject } from '@angular/core/testing';

import { PEducationService } from './p-education.service';

describe('PEducationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PEducationService]
    });
  });

  it('should be created', inject([PEducationService], (service: PEducationService) => {
    expect(service).toBeTruthy();
  }));
});
