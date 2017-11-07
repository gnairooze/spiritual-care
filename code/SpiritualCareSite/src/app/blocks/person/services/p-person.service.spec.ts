import { TestBed, inject } from '@angular/core/testing';

import { PPersonService } from './p-person.service';

describe('PPersonService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PPersonService]
    });
  });

  it('should be created', inject([PPersonService], (service: PPersonService) => {
    expect(service).toBeTruthy();
  }));
});
