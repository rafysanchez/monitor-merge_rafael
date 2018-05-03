/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MotivoService } from './motivo.service';

describe('Service: Motivo', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MotivoService]
    });
  });

  it('should ...', inject([MotivoService], (service: MotivoService) => {
    expect(service).toBeTruthy();
  }));
});