import { TestBed, inject } from '@angular/core/testing';

import { PFacebookService } from './p-facebook.service';

describe('PFacebookService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PFacebookService]
    });
  });

  it('should be created', inject([PFacebookService], (service: PFacebookService) => {
    expect(service).toBeTruthy();
  }));
});
