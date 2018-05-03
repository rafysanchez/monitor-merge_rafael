import { Observable } from 'rxjs/Observable';
import { DialogService } from 'ng2-bootstrap-modal';
import { ProdespMonitorModalConfirmComponent } from './../prodesp-monitor-modal-confirm/prodesp-monitor-modal-confirm.component';
import { JustificativaService } from './../../service/justificativa.service';
import { MotivoService } from './../../service/motivo.service';
import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Justificativa } from '../../models/justificativa';
import { Acao } from '../../models/acao';
import { Motivo } from '../../models/motivo';
import { Response } from '@angular/http';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';

@Component({
  selector: 'prodesp-item-justificativa',
  templateUrl: './prodesp-item-justificativa.component.html',
  styleUrls: ['./prodesp-item-justificativa.component.css']
})
export class ProdespItemJustificativaComponent implements OnInit, OnChanges {

  @Input() idItem: number;
  @Input() idItemGsnet: number;
  @Input() idGestor: number;
  @Input() idJustificador: number;
  @Input() codSetor: string;
  @Input() codTipoJustificativa: number;
  novaJustificativa: Justificativa;
  @Input() acoes: Acao[] = [];
  @Input() motivos: Motivo[] = [];
  motivoSelecionado: Motivo;
  acaoSelecionado: Acao;
  podeJustificar: boolean;
  isLoading: boolean;
  constructor(private justificativaService: JustificativaService, private dialogService: DialogService) { }

  ngOnInit() {
    this.buscarItem();
  }
  ngOnChanges(changes: SimpleChanges): void {
    //throw new Error("Method not implemented.");
  }
  buscarItem() {
    this.isLoading = true;
    this.motivoSelecionado = new Motivo();
    // inicializa a variavel
    this.acaoSelecionado = new Acao();
    // inicializa a variavel
    this.novaJustificativa = new Justificativa();

    this.novaJustificativa.IdItemMonitoramento = this.idItem;
    this.justificativaService
      .buscarPorItemMonitoramento(this.idItem, this.codTipoJustificativa)
      .map((response: Response) => {
        this.isLoading = false;
        // converte a resposta do servico para o tipo Justificativa
        const data = response.json() as Justificativa;
        // se ja houver uma justificativa para o item, seto os valores correspondentes
        if (data.Id !== 0) {
          this.novaJustificativa = data;
          this.motivoSelecionado = new Motivo(data.Motivo.Id, data.Motivo.Nome, data.Motivo.PodeEditarJustificativa, data.Motivo.JustificativaObrigatoria, data.Motivo.justificativa);
          this.acaoSelecionado = new Acao(data.Acao.Id, data.Acao.Nome, data.Acao.PodeEditarJustificativa, data.Acao.JustificativaObrigatoria, data.Acao.justificativa);
        } else {
          this.novaJustificativa.IdJustificador = this.codTipoJustificativa;
        }
        this.novaJustificativa.IdItemGsnet = this.idItemGsnet;
        this.novaJustificativa.IdGestorMonitor = this.idGestor;
        this.podeJustificar = this.verificarPermissaoPublicacao();

      }).catch(error => {
        this.isLoading = false;
        return Observable.throw(error);
      }).subscribe();
  }
  onMotivoChange(item: string): void {
    const id = parseInt(item.split(':')[1].trim());
    this.motivoSelecionado = this.motivos.find(x => x.Id === id);
  }
  onAcaoChange(item: string): void {
    const id = parseInt(item.split(':')[1].trim());
    this.acaoSelecionado = this.acoes.find(x => x.Id === id);
  }
  verificarPermissaoPublicacao() {
    const naoPossuiJustificativa: boolean = (this.novaJustificativa.Id === 0 || !this.novaJustificativa.Id);
    if (!naoPossuiJustificativa) {
      return false;
    }
    const justificadorComPermissao: boolean = (parseInt(this.codTipoJustificativa.toString()) === parseInt(this.idJustificador.toString()));
    const podeJustificarConsultaPublica: boolean = (parseInt(this.codTipoJustificativa.toString()) === 4 && parseInt(this.idJustificador.toString()) === 2);

    const possuiPermissao = (naoPossuiJustificativa && justificadorComPermissao) || (naoPossuiJustificativa && podeJustificarConsultaPublica);
    return possuiPermissao;
  }
  justificar(): void {
    this.isLoading = true;
    this.justificativaService.justificar(this.novaJustificativa).map((response: Response) => {
      this.isLoading = false;
      if (response.ok) {
        this.abrirMensagemSucesso('Item Justificado com sucesso');
        this.buscarItem();
      }
    }).catch(error => this.tratarErro(error)).subscribe();
  }
  usarAnterior(): void {
    this.justificativaService.usarAnterior(this.novaJustificativa).map((response: Response) => {
      if (response.ok) {
        this.abrirMensagemSucesso('Item Justificado com sucesso');
        this.buscarItem();
      }
    }).catch(error => this.tratarErro(error)).subscribe();
  }
  abrirMensagemSucesso(msg: string): void {
    this.dialogService.addDialog(ProdespMonitorModalConfirmComponent, {
      title: 'Solicitação efetivada com sucesso',
      text: msg,
      closeButtonText: 'Fechar',
      confirmButtonText: 'Utilizar',
      showConfirmButton: false
    }).subscribe((result) => {

    });
  }
  tratarErro(error: Response | ErrorObservable) {
    this.isLoading = false;
    debugger
    let errMsg: string;
    if (!errMsg && error instanceof Response) {
      const exception = JSON.stringify(error) || '';
      const e = JSON.parse(exception);
      errMsg = e._body;
    }
    if (errMsg) {
      this.dialogService.addDialog(ProdespMonitorModalConfirmComponent, {
        title: 'Erro na solicitação',
        text: errMsg,
        closeButtonText: 'Fechar',
        confirmButtonText: 'Utilizar',
        showConfirmButton: false
      }).subscribe((data) => { });
    }
    return Observable.throw(error);
  }
}
