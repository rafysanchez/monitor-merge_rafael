import { DialogService } from 'ng2-bootstrap-modal';
import { MotivoAcaoService } from './../../service/motivoacao.service';
import { Motivo } from './../../models/motivo';
import { Justificativa } from './../../models/justificativa';
import { IModal } from 'prodesp-ui';
import { DialogComponent } from 'ng2-bootstrap-modal';
import { Component, OnInit, Input } from '@angular/core';
import { AcaoService } from '../../service/acao.service';
import { MotivoService } from '../../service/motivo.service';
import { Acao } from '../../models/acao';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { ModalComponent } from '../../models/modal.component.model';
export interface IModalNovaJustificativa extends IModal {
  novaJustificativa: Justificativa;
  acao: Acao;
  motivo: Motivo;
}
@Component({
  selector: 'prodesp-monitor-modal-nova-justificativa',
  templateUrl: './monitor-modal-nova-justificativa.component.html',
  styleUrls: ['./monitor-modal-nova-justificativa.component.css']
})
export class ProdespMonitorModalNovaJustificativaComponent extends ModalComponent<IModalNovaJustificativa> implements OnInit, IModalNovaJustificativa {

  acao: Acao;
  motivo: Motivo;
  isClickDisabled: boolean;

  novaJustificativa: Justificativa;
  title: string;
  showConfirmButton: boolean;
  closeButtonText: string;
  confirmButtonText: string;
  modalData: any;
  acoes: Acao[] = [];
  motivos: Motivo[] = [];
  motivoSelecionado: Motivo;
  acaoSelecionado: Acao;
  constructor(private motivoAcaoService: MotivoAcaoService, dialogService: DialogService) {
    super(dialogService);
  }

  ngOnInit() {
    /* Inicializa o objeto da view */
    this.novaJustificativa = new Justificativa();
     // inicializa a variavel
     this.motivoSelecionado = new Motivo();
     // inicializa a variavel
     this.acaoSelecionado = new Acao();
    console.log(this.novaJustificativa)
    /* Inicializa os combos */
    this.carregarDropDownMotivo();
    this.carregarDropDownAcao();
  }
  carregarDropDownAcao(): void {
    this.motivoAcaoService.buscarPorTipo(0)
      .map((response: Response) => {
        const data = response.json();
        this.acoes = data;
      }).subscribe();
  }
  carregarDropDownMotivo(): void {
    this.motivoAcaoService.buscarPorTipo(1)
      .map((response: Response) => {
        this.motivos = response.json();
      }).subscribe();
  }
  salvarNovaJustificativa(justificativa: Justificativa): void {
    this.result = this.novaJustificativa;
    this.close();
  }
  closeModal(): void {
    this.close();
  }
  onMotivoChange(item: string): void {
    const id = parseInt(item.split(':')[1].trim());
    this.motivoSelecionado = this.motivos.find(x => x.Id === id);
  }
  onAcaoChange(item: string): void {
    const id = parseInt(item.split(':')[1].trim());
    this.acaoSelecionado = this.acoes.find(x => x.Id === id);
  }
}
