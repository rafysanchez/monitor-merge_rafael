import { FluxoJustificacao } from './../../models/fluxo.justicacao';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'prodesp-fluxo-justificativa',
  templateUrl: './prodesp-fluxo-justificativa.component.html',
  styleUrls: ['./prodesp-fluxo-justificativa.component.css']
})
export class ProdespFluxoJustificativaComponent implements OnInit {

  @Input()fluxo: FluxoJustificacao;
  constructor() { }

  ngOnInit() {
  }

}
