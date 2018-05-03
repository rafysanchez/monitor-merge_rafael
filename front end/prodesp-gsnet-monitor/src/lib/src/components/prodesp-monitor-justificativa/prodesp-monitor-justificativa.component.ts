import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { AppConfig } from './../../service/config.service';
import { MotivoAcao } from './../../models/motivo.acao.model';
import { Acao } from './../../models/acao';
import { Observable } from 'rxjs/Rx';
import { ExpandTableData } from '../../models/expand.table.data';
import { FluxoJustificacao } from '../../models/fluxo.justicacao';
import { FilterRule } from './../../models/filter.rule';
import { Reflection } from './../../models/reflection';
import { SearchRequest } from './../../models/searchrequest';
import { JustificativaService } from '../../service/justificativa.service';
import { ProdespMonitorModalConfirmComponent } from './../prodesp-monitor-modal-confirm/prodesp-monitor-modal-confirm.component';
import { IModalNovaJustificativa } from './../prodesp-monitor-modal-nova-justificativa/nova-justificativa.component';
import { Motivo } from './../../models/motivo';
import { ProdespMonitorModalPesquisaMedicamentoComponent } from './../prodesp-monitor-modal-pesquisa-medicamento/pesquisa-medicamento.component';
import { DialogService } from 'ng2-bootstrap-modal';
import { Component, OnInit } from '@angular/core';
import { ProdespMonitorModalNovaJustificativaComponent } from '../prodesp-monitor-modal-nova-justificativa/nova-justificativa.component';
import { PesquisaMedicamento } from '../../models/pesquisa.medicamento.model';
import { ProdespModalConfirmComponent, TableOptions, TableColumnDefinition } from 'prodesp-ui';
import { ProdespMonitorModalJustificativaProgramaComponent } from '../prodesp-monitor-modal-justificativa-programa/justificativa-programa.component';
import { ProgramaSaude } from '../../models/programa.saude.model';
import { Response } from '@angular/http';
import {Datetime } from 'prodesp-core';
@Component({
  selector: 'prodesp-monitor-justificativa',
  templateUrl: './prodesp-monitor-justificativa.component.html',
  styleUrls: ['./prodesp-monitor-justificativa.component.css']
})
export class ProdespMonitorJustificativaComponent implements OnInit {

  filtros: PesquisaMedicamento;
  filtroJustificado: FilterRule;
  noDataFound: boolean;
  linhasSelecionadas: Array<any> = [];
  tableData: ExpandTableData[] = [];
  totalPages: number;
  showPerPage: number[] = [5, 10, 15, 20];
  perPage = 5;
  page = 1;
  monitoramento: any;
  expandMode = 'Expandir Todos';
  expandAll = false;
  errorMessage: string;
  idJustificador: number;
  tableOptions: TableOptions;
  sortDirection: string;
  sortBy: string;
  isLoading: boolean;
  showSearchTextBox: boolean;
  constructor(private appConfig: AppConfig, private dialogService: DialogService, private justificativaService: JustificativaService, private service: JustificativaService) {
    this.idJustificador = appConfig.getConfig('IdJustificador');
  }
  ngOnInit() {
    this.showSearchTextBox = false;
    this.filtros = new PesquisaMedicamento();
    this.initTableOptions();
    this.sortDirection = this.tableOptions.sortDirection;
    this.sortBy = this.tableOptions.sortBy;
  }
  toogleExpand(): void {
    this.expandAll = !this.expandAll;
    if (this.expandAll) {
      this.expandMode = 'Recolher Todos';
    } else {
      this.expandMode = 'Expandir Todos';
    }
  }
  abrirPesquisa(): void {
    this.dialogService.addDialog(ProdespMonitorModalPesquisaMedicamentoComponent, {
      title: 'Pesquisar Medicamentos',
      closeButtonText: 'Fechar',
      confirmButtonText: 'Pesquisar',
      showConfirmButton: true,
      justificador: this.idJustificador,
      filtros: this.filtros,
      isClickDisabled: false,
    }).subscribe((data) => {
      if (data !== undefined) {
        this.filtros = data;
        this.totalPages = 0;
        this.page = 1;
        this.buscarPagina(true);
      }
    });
  }
  buscarPagina(resetPageNumber: boolean) {
    this.isLoading = true;
    const request = this.montarPesquisa();
    if (request) {
      this.justificativaService.getHttpContext().post(this.appConfig.getConfig('host') + `api/itemmonitor/queryitens?TYPE=json`, request)
        .map((response: Response) => {
          this.isLoading = false;
          const result: any = response.json();
          if (result.Message === '' || result.Message === null) {
            if (!result.Data || !result.Data.length) {

              this.noDataFound = true;
              this.tableData = [];
              this.totalPages = 0;
              this.monitoramento = null;
              return;
            }
            const itensMonitoramento: any[] = [];
            this.noDataFound = false;
            this.monitoramento = {
              NomePrograma: result.NomePrograma,
              DataMonitoramento: result.DataMonitoramento,
              JustificativasPendentes: result.JustificativasPendentes,
              QuantidadeAlertasItens: result.QuantidadeAlertasItens,
              QuantidadeAlertas: result.QuantidadeAlertas,
              Percentual: result.Percentual,
              QuantidadeItens: result.QuantidadeItens,
              TipoConsumoAutonomia: result.TipoConsumoAutonomia,
              TipoConsumoSaldoZerado: result.TipoConsumoSaldoZerado,
              IdPrograma: result.IdPrograma
            };
            result.Data.forEach((item: any) => {
              item.FluxoJustificacao = new FluxoJustificacao(item.JustificadoFME, item.JustificadoCAF, item.JustificadoCMP, item.CAFPublica);
              itensMonitoramento.push(new ExpandTableData(item, false, false));
            });
            this.tableData = itensMonitoramento;
            if (resetPageNumber) {
              this.totalPages = parseInt(result.TotalPages);
            }
          } else {
            this.noDataFound = true;
            this.tableData = [];
            this.totalPages = 0;
            this.monitoramento = null;
            this.errorMessage = result.Message;
          }
        }).catch(error => this.tratarErro(error)).subscribe();
    } else {
      this.noDataFound = true;
      this.tableData = [];
      this.totalPages = 0;
      this.monitoramento = null;
      this.errorMessage = 'Selecione um valor para a pesquisa';
    }
  }
  onSortClicked(event: any) {
    this.page = 1;
    this.sortBy = event.column.SortColumnId;
    this.sortDirection = event.sortDirection;
    this.buscarPagina(true);
  }
  montarPesquisa(): SearchRequest {
    const request: SearchRequest = new SearchRequest();
    request.OrderBy = this.sortBy;
    request.PageNumber = this.page;
    request.RecordsPerPage = this.perPage;
    request.SortDirection = this.sortDirection;
    const props = Reflection.getObjectPropertyNames(this.filtros);

    const possuiJustificativa = props.filter(item => {
      if (item.includes('Justificado')) {
        return true;
      }
      return false;
    });
    if (!possuiJustificativa) {
      this.filtroJustificado = null;
    }
    const rules: FilterRule[] = [];
    const filter = new FilterRule();
    props.map((item: any) => {
      if (this.filtros[item] !== null) {
        let tipo = Reflection.getTypeofProperty(this.filtros, item);
        let rule = new FilterRule(item.toString(), this.filtros[item], 'AND', 'equal', filter.convertType(tipo.toString()));
        rules.push(rule);
      }
    });
    if (rules.length) {
      let rule = new FilterRule('FlagAtivo', 'S', 'AND', 'equal', 'string');
      rules.push(rule);
    } else {
      return null;
    }
    filter.Rules = rules;
    request.Filter = filter;
    return request;
  }
  rowsSelected(event: any): void {
    this.linhasSelecionadas = event;
  }
  /**
* Captura o evento de mudanca de pagina, disparado pelo componente de paginação, e
* realiza a busca de ocorrencias passando a pagina desejada como parametro
*/
  pageChanges(event: any): void {
    this.page = event;
    this.buscarPagina(false);
  }
  perPageChanged(event: any): void {
    this.page = 1;
    this.perPage = event.perPage;
    this.buscarPagina(true);
  }
  abrirJustificarPorPrograma(): void {
    const data = this.comporDadosModalJustificativa('Justificar Itens por Programa');
    this.dialogService.addDialog(ProdespMonitorModalNovaJustificativaComponent, data).subscribe((novaJustificativa) => {
      if (novaJustificativa) {
        this.isLoading = true;
        let dataToPost: any = novaJustificativa;
        dataToPost.Itens = this.linhasSelecionadas.map((item: any) => {
          return {
            IdItemMonitoramento: item.data.Id,
            IdItemGsnet: item.data.IdItemGsnet,
            IdGestorMonitor : item.data.IdGestorMonitor
          };
        });
        dataToPost.Data = {
          IdJustificador: this.idJustificador,
          IdPrograma: this.monitoramento.IdPrograma,
          Acao: new MotivoAcao(novaJustificativa.IdAcao, novaJustificativa.AcaoJustificativa),
          Motivo: new MotivoAcao(novaJustificativa.IdMotivo, novaJustificativa.MotivoJustificativa)
        };

        this.justificativaService.justificarPorPrograma(dataToPost).map((response: Response) => {
          this.isLoading = false;
          this.abrirMensagemSucesso('Os itens selecionados foram justificados com sucesso');
        }).catch(error => this.tratarErro(error)).subscribe();
      }
    });

  }
  abrirNovaJustificativa(): void {
    const config = this.comporDadosModalJustificativa('Justificar itens selecionados');
    this.abrirModalJustificativa(config);
  }
  excluirJustificativas(): void {
    this.dialogService.addDialog(ProdespMonitorModalConfirmComponent, {
      title: 'Excluir Justificativas selecionadas',
      text: 'Tem certeza que deseja excluir as justificativas para os medicamentos selecionados? Essa operação não poderá ser desfeita',
      closeButtonText: 'Fechar',
      confirmButtonText: 'Excluir',
      showConfirmButton: true
    }).subscribe((confirmed) => {

      if (confirmed) {
        this.isLoading = true;
        let dataToPost: any = {};
        dataToPost.Itens = this.linhasSelecionadas.map((item: any) => {
          return {
            IdItemMonitoramento: item.data.Id,
            IdItemGsnet: item.data.IdItemGsnet,
            IdGestorMonitor : item.data.IdGestorMonitor
          };
        });
        dataToPost.IdJustificador = this.idJustificador;
        this.justificativaService.deletarVarios(dataToPost).map((result: Response) => {
          this.isLoading = false;
          this.abrirMensagemSucesso('Justificativas excluídas com sucesso');
        }).catch(error => this.tratarErro(error)).subscribe();
      }
    });
  }
  abrirMensagemSucesso(msg: string): void {
    this.expandAll = false;
    this.dialogService.addDialog(ProdespMonitorModalConfirmComponent, {
      title: 'Solicitação efetivada com sucesso',
      text: msg,
      closeButtonText: 'Fechar',
      confirmButtonText: 'Utilizar',
      showConfirmButton: false
    }).subscribe((result) => {
      this.page = 1;
      this.buscarPagina(false);
    });
  }
  abrirJustificativaAnterior(): void {
    this.dialogService.addDialog(ProdespMonitorModalConfirmComponent, {
      title: 'Utilizar justificativa anterior',
      text: 'Deseja usar a justificativa anterior desses medicamentos ?',
      closeButtonText: 'Fechar',
      confirmButtonText: 'Utilizar',
      showConfirmButton: true
    }).subscribe((data) => {
      if (data) {
        this.isLoading = true;
        let dataToPost: any = {};
        dataToPost.Itens = this.linhasSelecionadas.map((item: any) => {
          return {
            IdItemMonitoramento: item.data.Id,
            IdItemGsnet: item.data.IdItemGsnet,
            IdGestorMonitor : item.data.IdGestorMonitor
          };
        });
        dataToPost.IdJustificador = this.idJustificador;

        this.justificativaService.usarJustificativaAnterior(dataToPost).map((response: Response) => {
          this.isLoading = false;
          this.abrirMensagemSucesso('Os itens selecionados foram justificados com sucesso');
        }).catch(error => this.tratarErro(error)).subscribe();
      }
    });
  }
  comporDadosModalJustificativa(title: string): any {
    return {
      title: title,
      closeButtonText: 'Fechar',
      confirmButtonText: 'Salvar',
      showConfirmButton: true,
      acao: new Acao(),
      motivo: new Motivo()
    };
  }
  abrirModalJustificativa(data: IModalNovaJustificativa): void {
    this.dialogService.addDialog(ProdespMonitorModalNovaJustificativaComponent, data).subscribe((novaJustificativa) => {
      if (novaJustificativa) {
        this.isLoading = true;
        let dataToPost: any = novaJustificativa;
        dataToPost.Itens = this.linhasSelecionadas.map((item: any) => {
          return {
            IdItemMonitoramento: item.data.Id,
            IdItemGsnet: item.data.IdItemGsnet,
            IdGestorMonitor : item.data.IdGestorMonitor
          };
        });
        dataToPost.IdJustificador = this.idJustificador;

        this.justificativaService.justificarVarios(dataToPost).map((response: Response) => {
          this.isLoading = false;
          this.abrirMensagemSucesso('Os itens selecionados foram justificados com sucesso');
        }).catch(error => this.tratarErro(error)).subscribe();
      }
    });
  }
  initTableOptions(): void {
    this.tableOptions = new TableOptions();
    this.tableOptions.showPerPage = [5, 10, 15, 30, 50, 100, 200];
    this.tableOptions.tableHeader = 'Alertas Gerados';
    this.tableOptions.sortBy = 'Nome';
    this.tableOptions.sortDirection = 'asc';
    this.tableOptions.columnsDefinition = [
      new TableColumnDefinition('GrupoRecursos', 'Grupo de Recursos'),
      new TableColumnDefinition('Local', 'Local'),
      new TableColumnDefinition('IdItemGsnet', 'Código'),
      new TableColumnDefinition('Nome', 'Item'),
      new TableColumnDefinition('UnidadeDistribuicao', 'Unidade de Distribuicao'),
      new TableColumnDefinition('QuantidadeSaldoDisponivel', 'Saldo Disponível'),
      new TableColumnDefinition('QuantidadeDiasAutonomia', 'Autonomia(Dias)'),
      new TableColumnDefinition('DataUltimaFatura', 'Dt. Ultima Fatura'),
      new TableColumnDefinition('QuantidadeUltimaFatura', 'Qt. Última Fatura'),
      new TableColumnDefinition('DataUltimoEmpenho', 'Dt. Ultimo Empenho'),
      new TableColumnDefinition('QuantidadeUltimoEmpenho', 'Qt. Ultimo Empenho'),
      new TableColumnDefinition('QuantidadeConsumo', 'Consumo'),
      new TableColumnDefinition('DataUltimoConsumo', 'Dt. Ultimo Consumo'),
      new TableColumnDefinition('QuantidadeUltimoConsumo', 'Qt. Ultimo Consumo'),
      new TableColumnDefinition('', 'Justificativas'),
      new TableColumnDefinition('', 'Ações')
    ];
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
}
