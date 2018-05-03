/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespMonitorModalNovaJustificativaComponent } from './prodesp-monitor-modal-nova-justificativa.component';

describe('ProdespMonitorModalNovaJustificativaComponent', () => {
  let component: ProdespMonitorModalNovaJustificativaComponent;
  let fixture: ComponentFixture<ProdespMonitorModalNovaJustificativaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespMonitorModalNovaJustificativaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespMonitorModalNovaJustificativaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
