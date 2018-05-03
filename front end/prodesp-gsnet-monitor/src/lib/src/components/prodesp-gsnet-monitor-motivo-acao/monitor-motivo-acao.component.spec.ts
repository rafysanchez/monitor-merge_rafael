/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ProdespGsnetMonitorMotivoAcaoComponent } from './monitor-motivo-acao.component';

describe('ProdespGsnetMonitorMotivoAcaoComponent', () => {
  let component: ProdespGsnetMonitorMotivoAcaoComponent;
  let fixture: ComponentFixture<ProdespGsnetMonitorMotivoAcaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdespGsnetMonitorMotivoAcaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdespGsnetMonitorMotivoAcaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
