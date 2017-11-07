import { TestBed, inject } from '@angular/core/testing';

import { PPersonEducationService } from './p-person-education.service';

describe('PPersonEducationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PPersonEducationService]
    });
  });

  it('should be created', inject([PPersonEducationService], (service: PPersonEducationService) => {
    expect(service).toBeTruthy();
  }));
});
