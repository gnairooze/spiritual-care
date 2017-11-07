import { TestBed, inject } from '@angular/core/testing';

import { PPersonPersonService } from './p-person-person.service';

describe('PPersonPersonService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PPersonPersonService]
    });
  });

  it('should be created', inject([PPersonPersonService], (service: PPersonPersonService) => {
    expect(service).toBeTruthy();
  }));
});
