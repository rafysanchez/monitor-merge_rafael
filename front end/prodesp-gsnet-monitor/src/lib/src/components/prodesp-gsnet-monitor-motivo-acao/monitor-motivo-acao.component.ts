import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { AppConfig } from './../../service/config.service';
import { ProdespMonitorModalConfirmComponent } from './../prodesp-monitor-modal-confirm/prodesp-monitor-modal-confirm.component';
import { SearchRequest } from './../../models/searchrequest';
import { Reflection } from './../../models/reflection';
import { PesquisaMotivoAcao } from './../../models/pesquisamotivoacao';
import { FilterRule } from './../../models/filter.rule';
import { ProdespMonitorPesquisaMotivoAcaoComponent } from './../prodesp-monitor-pesquisa-motivo-acao/monitor-pesquisa-motivo-acao.component';
import { ProdespGsnetMonitorModalMotivoAcaoComponent } from './../prodesp-gsnet-monitor-modal-motivo-acao/monitor-modal-motivo-acao.component';
import { Response } from '@angular/http';
import { MotivoAcaoService } from './../../service/motivoacao.service';
import { MotivoAcao } from './../../models/motivo.acao.model';
import { TableOptions, TableColumnDefinition } from 'prodesp-ui';
import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Observable } from 'rxjs/Rx';
import { DialogService } from 'ng2-bootstrap-modal/dist/dialog.service';
@Component({
  selector: 'prodesp-gsnet-monitor-motivo-acao',
  templateUrl: './monitor-motivo-acao.component.html',
  styleUrls: ['./monitor-motivo-acao.component.css']
})
export class ProdespGsnetMonitorMotivoAcaoComponent implements OnInit {

  tableConfig: TableOptions;
  tableData: MotivoAcao[];
  page = 1;
  perPage = 5;
  totalPages = 1;
  sortBy: string;
  sortDirection: string;
  isLoading: boolean;
  filtros: PesquisaMotivoAcao = new PesquisaMotivoAcao();
  constructor(private service: MotivoAcaoService, private dialogService: DialogService, private appConfig: AppConfig) { }

  ngOnInit() {
    this.tableConfig = new TableOptions();
    this.tableConfig.showPerPage = [5, 10, 15, 30, 50, 100];
    this.tableConfig.tableHeader = 'Motivos/Ações';
    this.tableConfig.columnsDefinition = [
      new TableColumnDefinition('Tipo', 'Tipo'),
      new TableColumnDefinition('Nome', 'Motivo/Ação'),
      new TableColumnDefinition('Descricao', 'Descrição'),
      new TableColumnDefinition('JustificativaObrigatoria', 'Justif. Obrg.'),
      new TableColumnDefinition('PodeEditarJustificativa', 'Pode Editar Justif.'),
      new TableColumnDefinition('FlagAtivo', 'Status'),
      new TableColumnDefinition('', 'Ações')
    ];
    this.sortDirection = this.tableConfig.sortDirection = 'asc';
    this.sortBy = this.tableConfig.sortBy = 'Nome';
    this.buscarPagina(true);
  }
  initTableData(): void {
    this.service.buscarTodos().map((resp: any) => {
      this.tableData = resp;
      console.log(this.tableData);
    }).subscribe();
  }
  onAdd(): void {
    this.dialogService.addDialog(ProdespGsnetMonitorModalMotivoAcaoComponent, {
      title: 'Adicionar Motivo/Ação',
      closeButtonText: 'Fechar',
      confirmButtonText: 'Salvar',
      showConfirmButton: true,
      isClickDisabled: true,
      novoMotivoAcao: new MotivoAcao()
    }).subscribe((result) => {
      if (result) {
        this.service.inserir(result).map((response: any) => {
          this.initTableData();
          this.abrirMensagemSucesso('Item atualizado com sucesso');
        }).catch(error => this.tratarErro(error)).subscribe();
      }
    });
  }
  onSortClicked(event: any) {
    this.page = 1;
    this.sortBy = event.column.SortColumnId;
    this.sortDirection = event.sortDirection;
    this.buscarPagina(false);
  }
  onSearch(): void {
    this.dialogService.addDialog(ProdespMonitorPesquisaMotivoAcaoComponent, {
      title: 'Pesquisar Motivo/Ação',
      closeButtonText: 'Fechar',
      confirmButtonText: 'Pesquisar',
      showConfirmButton: true,
      filtros: this.filtros
    }).subscribe((result) => {
      if (result) {
        this.page = 1;
        this.buscarPagina(true);
      }
    });
  }
  buscarPagina(resetTotalPages?: boolean) {
    this.isLoading = true;
    const request = this.montarPesquisa();
    this.service.getHttpContext().post(this.appConfig.getConfig('host') + `api/motivoacao/queryitens?TYPE=json`, request).map((response: Response) => {
      this.isLoading = false;
      const data = response.json();
      this.tableData = data.Itens;
      if (resetTotalPages) {
        this.totalPages = data.TotalPages;
      }
    }).catch(error => this.tratarErro(error)).subscribe();
  }
  montarPesquisa(): SearchRequest {
    const request: SearchRequest = new SearchRequest();
    request.OrderBy = this.sortBy;
    request.PageNumber = this.page;
    request.RecordsPerPage = this.perPage;
    request.SortDirection = this.sortDirection;
    const props = Reflection.getObjectPropertyNames(this.filtros);

    const rules: FilterRule[] = [];
    const filter = new FilterRule();
    props.map((item: any) => {
      if (this.filtros[item] !== null && this.filtros[item].toString() !== '-1') {
        let tipo = Reflection.getTypeofProperty(this.filtros, item);
        let rule = new FilterRule(item.toString(), this.filtros[item], 'AND', 'equal', filter.convertType(tipo.toString()));
        rules.push(rule);
      }
    });
    // let rule = new FilterRule('FlagAtivo', 'S', 'AND', 'equal', 'string');
    // rules.push(rule);
    filter.Rules = rules;
    request.Filter = filter;
    return request;
  }
  onEdit(item: MotivoAcao): void {
    this.service.buscarPorId(`/${item.Id.toString()}`).map((motivoAcao: any) => {
      this.dialogService.addDialog(ProdespGsnetMonitorModalMotivoAcaoComponent, {
        title: 'Editar Motivo/Ação',
        closeButtonText: 'Fechar',
        confirmButtonText: 'Salvar',
        showConfirmButton: true,
        isClickDisabled: true,
        editMode: true,
        modalData: motivoAcao,
        novoMotivoAcao: motivoAcao
      }).subscribe((result => {
        if (result) {
          this.service.atualizar(result).map((response: any) => {
            this.initTableData();

            this.abrirMensagemSucesso('Item atualizado com sucesso');

          }).catch(error => this.tratarErro(error)).subscribe();
        }
      }));
    }).subscribe();
  }
  tratarErro(error: Response | ErrorObservable) {
    this.isLoading = false;
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
  abrirMensagemSucesso(msg: string): void {
    this.dialogService.addDialog(ProdespMonitorModalConfirmComponent, {
      title: 'Solicitação efetivada com sucesso',
      text: msg,
      closeButtonText: 'Fechar',
      confirmButtonText: 'Utilizar',
      showConfirmButton: false
    }).subscribe((result) => {
      this.page = 1;
      this.buscarPagina();
    });
  }
  decodeSituacao(item: MotivoAcao): string {
    return item.Situacao ? 'Ativo' : 'Inativo';
  }
  decodeJustificativaObrigatoria(item: MotivoAcao): string {
    return item.JustificativaObrigatoria ? 'Sim' : 'Não';
  }
  decodePodeEditarJustificativa(item: MotivoAcao): string {
    return item.PodeEditarJustificativa ? 'Sim' : 'Não';
  }
  abrirPesquisa() { }
  pageChanges(value: any) {
    debugger
    this.page = value;
    this.buscarPagina();
  }
  perPageChanged(value: any) {
    this.page = 1;
    this.perPage = value.perPage;
    this.buscarPagina(true);
  }
}
