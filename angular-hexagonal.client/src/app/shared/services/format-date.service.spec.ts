/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FormatDateService } from './format-date.service';

describe('Service: FormatDate', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FormatDateService]
    });
  });

  it('should ...', inject([FormatDateService], (service: FormatDateService) => {
    expect(service).toBeTruthy();
  }));
});
