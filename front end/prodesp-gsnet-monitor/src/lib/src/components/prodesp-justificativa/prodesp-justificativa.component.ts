import { AppConfig } from './../../service/config.service';
import { Component, OnInit, Input } from '@angular/core';
import { Acao } from '../../models/acao';
import { Motivo } from '../../models/motivo';

@Component({
  selector: 'prodesp-justificativa',
  templateUrl: './prodesp-justificativa.component.html',
  styleUrls: ['./prodesp-justificativa.component.css']
})
export class ProdespJustificativaComponent implements OnInit {

  @Input()idItem: number;
  @Input()idItemGsnet: number;
  @Input()idGestor: number;
  @Input()idJustificador: number;
  @Input()acoes: Acao[]= [];
  @Input()motivos: Motivo[] = [];
  constructor(appConfig: AppConfig) {
    debugger
    this.idJustificador = appConfig.getConfig('IdJustificador');
  }

  ngOnInit() {
  }

}
