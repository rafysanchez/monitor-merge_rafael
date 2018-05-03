/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { IndicadoresService } from './indicadores.service';

describe('Service: Indicadores', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [IndicadoresService]
    });
  });

  it('should ...', inject([IndicadoresService], (service: IndicadoresService) => {
    expect(service).toBeTruthy();
  }));
});