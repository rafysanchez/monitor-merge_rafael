/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MotivoacaoService } from './motivoacao.service';

describe('Service: Motivoacao', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MotivoacaoService]
    });
  });

  it('should ...', inject([MotivoacaoService], (service: MotivoacaoService) => {
    expect(service).toBeTruthy();
  }));
});