import { TestBed, inject } from '@angular/core/testing';

import { PJobService } from './p-job.service';

describe('PJobService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PJobService]
    });
  });

  it('should be created', inject([PJobService], (service: PJobService) => {
    expect(service).toBeTruthy();
  }));
});
