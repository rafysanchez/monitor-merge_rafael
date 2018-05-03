/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespMonitorJustificativaComponent } from './prodesp-monitor-justificativa.component';

describe('ProdespMonitorJustificativaComponent', () => {
  let component: ProdespMonitorJustificativaComponent;
  let fixture: ComponentFixture<ProdespMonitorJustificativaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespMonitorJustificativaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespMonitorJustificativaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
