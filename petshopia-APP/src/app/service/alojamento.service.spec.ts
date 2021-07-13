/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AlojamentoService } from './alojamento.service';

describe('Service: Alojamento', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AlojamentoService]
    });
  });

  it('should ...', inject([AlojamentoService], (service: AlojamentoService) => {
    expect(service).toBeTruthy();
  }));
});
