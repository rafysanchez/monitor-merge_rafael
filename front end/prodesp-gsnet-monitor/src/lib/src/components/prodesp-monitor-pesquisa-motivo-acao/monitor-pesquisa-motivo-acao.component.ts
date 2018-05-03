import { TipoAcaoMotivo } from './../../models/tipoacaomotivo';
import { DialogService } from 'ng2-bootstrap-modal';
import { Component, OnInit } from '@angular/core';
import { ModalComponent } from '../../models/modal.component.model';
import { PesquisaMotivoAcao } from '../../models/pesquisamotivoacao';
export interface IPesquisaMotivoAcaoModal {

}
@Component({
  selector: 'app-prodesp-monitor-pesquisa-motivo-acao',
  templateUrl: './prodesp-monitor-pesquisa-motivo-acao.component.html',
  styleUrls: ['./prodesp-monitor-pesquisa-motivo-acao.component.css']
})
export class ProdespMonitorPesquisaMotivoAcaoComponent extends ModalComponent<any> implements OnInit {

  Tipos: TipoAcaoMotivo[] = [];
  filtros: PesquisaMotivoAcao;
  constructor(dialogService: DialogService) {
    super(dialogService);
  }

  ngOnInit() {
    this.carregarComboMotivoAcao();
  }
  carregarComboMotivoAcao() {
    this.Tipos = [
      new TipoAcaoMotivo(-1, 'Todos'),
      new TipoAcaoMotivo(0, 'Ação'),
      new TipoAcaoMotivo(1, 'Motivo'),
    ];
  }

}
