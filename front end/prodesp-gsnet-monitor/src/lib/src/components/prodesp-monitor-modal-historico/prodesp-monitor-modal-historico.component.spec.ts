/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespMonitorModalHistoricoComponent } from './prodesp-monitor-modal-historico.component';

describe('ProdespMonitorModalHistoricoComponent', () => {
  let component: ProdespMonitorModalHistoricoComponent;
  let fixture: ComponentFixture<ProdespMonitorModalHistoricoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespMonitorModalHistoricoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespMonitorModalHistoricoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
