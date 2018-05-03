/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespMonitorModalDetalheParametroComponent } from './prodesp-monitor-modal-detalhe-parametro.component';

describe('ProdespMonitorModalDetalheParametroComponent', () => {
  let component: ProdespMonitorModalDetalheParametroComponent;
  let fixture: ComponentFixture<ProdespMonitorModalDetalheParametroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespMonitorModalDetalheParametroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespMonitorModalDetalheParametroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
