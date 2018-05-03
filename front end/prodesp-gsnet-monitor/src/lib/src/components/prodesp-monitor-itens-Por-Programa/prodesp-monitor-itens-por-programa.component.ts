
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
import { Acao } from '../../models/acao';
import { ProdespModalConfirmComponent } from 'prodesp-ui';
import { ProdespMonitorModalJustificativaProgramaComponent } from '../prodesp-monitor-modal-justificativa-programa/justificativa-programa.component';
import { ListDadosFarmacia } from '../../models/ListDadosFarmacia';
import { Response } from '@angular/http';
import { TableOptions, TableColumnDefinition } from 'prodesp-ui';

@Component({
  selector: 'prodesp-monitor-itens-por-programa',
  templateUrl: './prodesp-monitor-itens-por-programa.component.html',
  styleUrls: ['./prodesp-monitor-itens-por-programa.component.css']
})
export class ProdespMonitorItensPorProgramaComponent implements OnInit {
  tableConfig: TableOptions;
  filtros: PesquisaMedicamento;
  filtroJustificado: FilterRule;
  noDataFound: boolean;
  linhasSelecionadas: Array<any> = [];
  tableData: ListDadosFarmacia[] = [];
  totalPages: number;
  showPerPage: number[] = [5, 10, 15, 20, 50, 100, 200];
  perPage = 5;
  page = 1;
  monitoramento: any;
  expandMode = 'Expandir Todos';
  expanded = false;
  errorMessage: string;
  idJustificador = 1;

  constructor(private dialogService: DialogService, private justificativaService: JustificativaService,
    private service: JustificativaService) {
  }
  ngOnInit() {
    this.filtros = new PesquisaMedicamento();

    this.tableConfig = new TableOptions();
    this.tableConfig.showPerPage = [5, 15, 20, 100, 200, 300];
    this.tableConfig.tableHeader = 'Farmácia';

    this.tableConfig.columnsDefinition = [
      new TableColumnDefinition('', 'Grupo de recurso'),
      new TableColumnDefinition('', 'Código'),
      new TableColumnDefinition('', 'SIAFISICO'),
      new TableColumnDefinition('', 'Nome do Item'),
      new TableColumnDefinition('', 'Unid. Distribuição'),
      new TableColumnDefinition('', 'Status'),
      new TableColumnDefinition('', 'Ações')

    ];
    this.buscarPagina(this.totalPages);
    // this.carregaComboProgramas();
     // this.carregaComboFarmacias();
  }

  abrirPesquisa(): void {
    this.dialogService.addDialog(ProdespMonitorModalPesquisaMedicamentoComponent, {
      title: 'Pesquisar Medicamentos',
      closeButtonText: 'Fechar',
      confirmButtonText: 'Pesquisar',
      showConfirmButton: true,
      justificador: 1,
      filtros: this.filtros,
      isClickDisabled: false,
    }).subscribe((data) => {
      if (data !== undefined) {
        this.filtros = data;
        this.totalPages = 0;
        this.buscarPagina(this.totalPages);
      }
    });
  }
  buscarPagina(totalPages?: number) {
    const request = this.montarPesquisa();
    if (request) {
      this.justificativaService.getHttpContext().post(`http://localhost:57428/api/itemmonitor/queryitens?TYPE=json`, request)
        .map((response: Response) => {
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
              TipoConsumoSaldoZerado: result.TipoConsumoSaldoZerado
            };
            result.Data.forEach((item: any) => {
              // item.FluxoJustificacao = new FluxoJustificacao(item.JustificadoFME, item.JustificadoCAF, item.JustificadoCMP);
              itensMonitoramento.push(new ExpandTableData(item, false, false));
            });
            this.tableData = itensMonitoramento;
            if (totalPages !== undefined) {
              this.totalPages = parseInt(result.TotalPages);
            }
          } else {
            this.noDataFound = true;
            this.tableData = [];
            this.totalPages = 0;
            this.monitoramento = null;
            this.errorMessage = result.Message;
          }
        }).subscribe();
    }else {
      this.noDataFound = true;
      this.tableData = [];
      this.totalPages = 0;
      this.monitoramento = null;
      this.errorMessage = 'Selecione um valor para a pesquisa';
    }
  }
  montarPesquisa(): SearchRequest {
    const request: SearchRequest = new SearchRequest();
    request.OrderBy = 'id_item_programa';
    request.PageNumber = this.page;
    request.RecordsPerPage = this.perPage;
    request.SortDirection = 'asc';
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
    this.buscarPagina();
  }
  perPageChanged(event: any): void {
    this.page = 1;
    this.perPage = event.perPage;
    this.buscarPagina(this.totalPages);
  }


}
