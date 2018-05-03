/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespMonitorUltimasJustificativasComponent } from './ultimas-justificativas.component';

describe('ProdespMonitorUltimasJustificativasComponent', () => {
  let component: ProdespMonitorUltimasJustificativasComponent;
  let fixture: ComponentFixture<ProdespMonitorUltimasJustificativasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespMonitorUltimasJustificativasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespMonitorUltimasJustificativasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
