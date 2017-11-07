import { TestBed, inject } from '@angular/core/testing';

import { PWhatsappService } from './p-whatsapp.service';

describe('PWhatsappService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PWhatsappService]
    });
  });

  it('should be created', inject([PWhatsappService], (service: PWhatsappService) => {
    expect(service).toBeTruthy();
  }));
});
