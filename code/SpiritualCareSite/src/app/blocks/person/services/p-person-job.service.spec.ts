import { TestBed, inject } from '@angular/core/testing';

import { PPersonJobService } from './p-person-job.service';

describe('PPersonJobService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PPersonJobService]
    });
  });

  it('should be created', inject([PPersonJobService], (service: PPersonJobService) => {
    expect(service).toBeTruthy();
  }));
});
