/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespMonitorIndicadoresComponent } from './prodesp-monitor-indicadores.component';

describe('ProdespMonitorIndicadoresComponent', () => {
  let component: ProdespMonitorIndicadoresComponent;
  let fixture: ComponentFixture<ProdespMonitorIndicadoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespMonitorIndicadoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespMonitorIndicadoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
