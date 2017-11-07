import { TestBed, inject } from '@angular/core/testing';

import { PPersonExpectedMeetingService } from './p-person-expected-meeting.service';

describe('PPersonExpectedMeetingService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PPersonExpectedMeetingService]
    });
  });

  it('should be created', inject([PPersonExpectedMeetingService], (service: PPersonExpectedMeetingService) => {
    expect(service).toBeTruthy();
  }));
});
