/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespFluxoJustificativaComponent } from './prodesp-fluxo-justificativa.component';

describe('ProdespFluxoJustificativaComponent', () => {
  let component: ProdespFluxoJustificativaComponent;
  let fixture: ComponentFixture<ProdespFluxoJustificativaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespFluxoJustificativaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespFluxoJustificativaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
