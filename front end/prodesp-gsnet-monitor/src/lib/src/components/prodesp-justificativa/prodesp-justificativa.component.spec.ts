/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespJustificativaComponent } from './prodesp-justificativa.component';

describe('ProdespJustificativaComponent', () => {
  let component: ProdespJustificativaComponent;
  let fixture: ComponentFixture<ProdespJustificativaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespJustificativaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespJustificativaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
