import { SearchRequest } from './../../models/searchrequest';
import { ProgramaSaude } from './../../models/programa.saude.model';
import { SituacaoJustificativa } from './../../models/sitaucao.justificativa.model';
import { DialogComponent, DialogService } from 'ng2-bootstrap-modal';
import { PesquisaMedicamento } from './../../models/pesquisa.medicamento.model';
import { Component, OnInit } from '@angular/core';
import { IModal } from 'prodesp-ui';
import { ModalComponent } from '../../models/modal.component.model';
import { SituacaoSaldoMedicamento } from '../../models/situacao.saldo.model';
export interface IModalPesquisaMedicamento extends IModal {
  filtros: PesquisaMedicamento;
  justificador: number;
}
@Component({
  selector: 'prodesp-monitor-pesquisa-medicamento',
  templateUrl: './monitor-pesquisa-medicamento.component.html',
  styleUrls: ['./monitor-pesquisa-medicamento.component.css']
})
export class ProdespMonitorModalPesquisaMedicamentoComponent extends ModalComponent<IModalPesquisaMedicamento> implements OnInit, IModalPesquisaMedicamento {
  justificador: number;
  filtros: PesquisaMedicamento;
  title: string;
  showConfirmButton: boolean;
  closeButtonText: string;
  confirmButtonText: string;
  modalData: any;
  isClickDisabled: boolean;
  situacoesSaldo: SituacaoSaldoMedicamento[] = [];
  situacaoJustificativa: SituacaoJustificativa[] = [];
  programasSaude: ProgramaSaude[] = [];
  /**
   * as
   * @param dialogService
   */
  constructor(dialogService: DialogService) {
    super(dialogService);
   }

  ngOnInit() {
    this.programasSaude = [
      new ProgramaSaude(null,  '-- SELECIONE --'),
      new ProgramaSaude(1,  'DOSE CERTA'),
      new ProgramaSaude(2,  'DOSE CERTA'),
      new ProgramaSaude(3,  'ALTO CUSTO - MEDIC.ESPEC'),
      new ProgramaSaude(5,  'DIABETES'),
      new ProgramaSaude(6,  'DST/AIDS'),
      new ProgramaSaude(7,  'TUBERCULOSE'),
      new ProgramaSaude(8,  'COLERA'),
      new ProgramaSaude(9,  'ESQUISTOSSOMOSE'),
      new ProgramaSaude(10,  'TRACOMA'),
      new ProgramaSaude(11,  'MENINGITE'),
      new ProgramaSaude(12,  'LEISHMANIOSE'),
      new ProgramaSaude(13,  'HANSENIASE'),
      new ProgramaSaude(14,  'LUPUS'),
      new ProgramaSaude(15,  'FIBROSE CISTICA'),
      new ProgramaSaude(16,  'TRS'),
      new ProgramaSaude(17,  'GLAUCOMA'),
      new ProgramaSaude(18,  'MADICAMENTOS BASICOS '),
      new ProgramaSaude(19,  'MALARIA'),
      new ProgramaSaude(20,  'ESQUISTOSSOMOSE TESTE')
    ];

    this.situacoesSaldo = [
      new SituacaoSaldoMedicamento(null, 'TODOS'),
      new SituacaoSaldoMedicamento(1, 'AUTONOMIA'),
      new SituacaoSaldoMedicamento(2, 'SALDO ZERADO')
    ];
    this.situacaoJustificativa = [
      new SituacaoJustificativa(null, 'TODOS'),
      new SituacaoJustificativa(false, 'PENDENTES'),
      new SituacaoJustificativa(true, 'JUSTIFICADOS')
    ];
    this.filtros = new PesquisaMedicamento();
  }
  pesquisarMonitoramento(): void {
    this.result = this.filtros;
  }
}
