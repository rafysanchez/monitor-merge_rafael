/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { JustificativaService } from './justificativa.service';

describe('Service: Justificativa', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [JustificativaService]
    });
  });

  it('should ...', inject([JustificativaService], (service: JustificativaService) => {
    expect(service).toBeTruthy();
  }));
});