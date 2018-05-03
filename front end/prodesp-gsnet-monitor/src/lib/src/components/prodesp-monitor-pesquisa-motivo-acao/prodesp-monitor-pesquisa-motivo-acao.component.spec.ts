/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespMonitorPesquisaMotivoAcaoComponent } from './prodesp-monitor-pesquisa-motivo-acao.component';

describe('ProdespMonitorPesquisaMotivoAcaoComponent', () => {
  let component: ProdespMonitorPesquisaMotivoAcaoComponent;
  let fixture: ComponentFixture<ProdespMonitorPesquisaMotivoAcaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespMonitorPesquisaMotivoAcaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespMonitorPesquisaMotivoAcaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
