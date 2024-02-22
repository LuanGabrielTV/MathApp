import { TestBed } from '@angular/core/testing';

import { LicaoService } from './licao.service';

describe('LicaoService', () => {
  let service: LicaoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LicaoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
