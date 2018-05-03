import { TipoAcaoMotivo } from './../../models/tipoacaomotivo';
import { DialogService } from 'ng2-bootstrap-modal/dist/dialog.service';
import { IModal } from 'prodesp-ui';
import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { ModalComponent } from '../../models/modal.component.model';
import { MotivoAcao } from '../../models/motivo.acao.model';
import { MotivoAcaoService } from '../../service/motivoacao.service';

import * as $ from 'jquery';

export interface IModalMotivoAcao extends IModal {
  novoMotivoAcao: MotivoAcao;
  editMode: boolean;
}
 
@Component({
  selector: 'prodesp-gsnet-monitor-modal-motivo-acao',
  templateUrl: './monitor-modal-motivo-acao.component.html',
  styleUrls: ['./monitor-modal-motivo-acao.component.css']
})
export class ProdespGsnetMonitorModalMotivoAcaoComponent extends ModalComponent<IModalMotivoAcao> implements OnInit, IModalMotivoAcao {

  editMode: boolean;
  novoMotivoAcao: MotivoAcao;
  Erros: string;
  mensagem: string = null;
  Tipos: TipoAcaoMotivo[] = [];
  constructor(dialogService: DialogService, private service: MotivoAcaoService) {
    super(dialogService);
  }

  ngOnInit() {
    this.Tipos = [
      new TipoAcaoMotivo(0, 'Ação'),
      new TipoAcaoMotivo(1, 'Motivo'),
    ];
  }
  confirm(data: any) {

    this.result = this.novoMotivoAcao;
    this.close();

  }
  limparMotivoAcao() {
    this.novoMotivoAcao.Nome = '';
    this.novoMotivoAcao.Descricao = '';
    this.novoMotivoAcao.Tipo = '';
    this.novoMotivoAcao.PodeEditarJustificativa = false;
    this.novoMotivoAcao.JustificativaObrigatoria = false;
    this.novoMotivoAcao.Situacao = false;
  }
}
