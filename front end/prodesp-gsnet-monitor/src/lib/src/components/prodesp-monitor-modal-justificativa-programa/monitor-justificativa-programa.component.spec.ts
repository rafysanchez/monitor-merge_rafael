/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespMonitorModalJustificativaProgramaComponent } from './justificativa-programa.component';

describe('ProdespMonitorModalJustificativaProgramaComponent', () => {
  let component: ProdespMonitorModalJustificativaProgramaComponent;
  let fixture: ComponentFixture<ProdespMonitorModalJustificativaProgramaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespMonitorModalJustificativaProgramaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespMonitorModalJustificativaProgramaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
