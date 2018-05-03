import { ProgramaSaude } from './../../models/programa.saude.model';
import { DialogService } from 'ng2-bootstrap-modal';
import { Component, OnInit } from '@angular/core';
import { ModalComponent } from './../../models/modal.component.model';
import { IModal } from 'prodesp-ui';
import { Justificativa } from '../../models/justificativa';
import { Motivo } from '../../models/motivo';
import { Acao } from '../../models/acao';
import { AcaoService } from '../../service/acao.service';
import { MotivoService } from '../../service/motivo.service';

export interface IModalMonitorJustificativaPrograma extends IModal {
  programaSaude: ProgramaSaude;
}
@Component({
  selector: 'prodesp-monitor-modal-justificativa-programa',
  templateUrl: './monitor-justificativa-programa.component.html',
  styleUrls: ['./monitor-justificativa-programa.component.css']
})
export class ProdespMonitorModalJustificativaProgramaComponent extends ModalComponent<IModalMonitorJustificativaPrograma> implements OnInit {

  programasSaude: ProgramaSaude[]= [];
  novaJustificativa: Justificativa;
  motivos: Motivo[]= [];
  acoes: Acao[] = [];
  constructor(private acaoService: AcaoService, private motivoService: MotivoService, dialogService: DialogService) {
    super(dialogService);
  }

  ngOnInit() {
    this.programasSaude = [
      new ProgramaSaude(1,  'DOSE CERTA'),
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

    /* Inicializa o objeto da view */
    this.novaJustificativa = new Justificativa();
    console.log(this.novaJustificativa)
    /* Inicializa os combos */
    this.acoes = this.acaoService.get();
    this.motivos = this.motivoService.get();
  }

}
