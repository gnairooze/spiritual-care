import { TestBed, inject } from '@angular/core/testing';

import { PPersonActualMeetingService } from './p-person-actual-meeting.service';

describe('PPersonActualMeetingService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PPersonActualMeetingService]
    });
  });

  it('should be created', inject([PPersonActualMeetingService], (service: PPersonActualMeetingService) => {
    expect(service).toBeTruthy();
  }));
});
