import { TestBed, inject } from '@angular/core/testing';

import { PViberService } from './p-viber.service';

describe('PViberService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PViberService]
    });
  });

  it('should be created', inject([PViberService], (service: PViberService) => {
    expect(service).toBeTruthy();
  }));
});
