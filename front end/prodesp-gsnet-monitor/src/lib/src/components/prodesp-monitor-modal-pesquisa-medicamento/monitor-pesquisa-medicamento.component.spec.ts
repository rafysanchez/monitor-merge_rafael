/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespMonitorModalPesquisaMedicamentoComponent } from './pesquisa-medicamento.component';

describe('ProdespMonitorModalPesquisaMedicamentoComponent', () => {
  let component: ProdespMonitorModalPesquisaMedicamentoComponent;
  let fixture: ComponentFixture<ProdespMonitorModalPesquisaMedicamentoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespMonitorModalPesquisaMedicamentoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespMonitorModalPesquisaMedicamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
