import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { Response } from '@angular/http';
import { ModalComponent } from '../../models/modal.component.model';
import { DialogService } from 'ng2-bootstrap-modal/dist/dialog.service';
import { IModal } from 'prodesp-ui';
import { TableOptions, TableColumnDefinition } from 'prodesp-ui';
import { SearchRequest } from './../../models/searchrequest';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Observable } from 'rxjs/Rx';
import { Reflection } from './../../models/reflection';
import { ParametroService } from '../../service/parametro.service';
import { Parametro } from '../../models/parametro';
import { FilterRule } from './../../models/filter.rule';
import { PesquisaMotivoAcao } from './../../models/pesquisamotivoacao';

export interface IModalDetalheParametro extends IModal {
  novoParametro: Parametro;
  idRegraMotor: number;
}

@Component({
  selector: 'app-prodesp-monitor-modal-detalhe-parametro',
  templateUrl: './prodesp-monitor-modal-detalhe-parametro.component.html',
  styleUrls: ['./prodesp-monitor-modal-detalhe-parametro.component.css']
})
export class ProdespMonitorModalDetalheParametroComponent extends ModalComponent<IModalDetalheParametro> implements OnInit, OnChanges, IModalDetalheParametro {
  novoParametro: Parametro;
  tableConfig: TableOptions;
  tableData: Parametro[];
  page = 1;
  perPage = 5;
  totalPages = 1;
  filtros: PesquisaMotivoAcao = new PesquisaMotivoAcao();
  idRegraMotor = 0;

  constructor(private service: ParametroService,  dialogService: DialogService) { super(dialogService); }

  ngOnInit() {
    this.tableConfig = new TableOptions();
    this.tableConfig.showPerPage = [5, 10, 15, 30, 50, 100];
    this.tableConfig.tableHeader = 'Detalhes - Autonomia Consumo';
    this.tableConfig.columnsDefinition = [
      new TableColumnDefinition('', 'Nome do Parâmetro'),
      new TableColumnDefinition('', 'Valor do Parâmetro')

    ];
    this.buscarDados(this.idRegraMotor);
  }
  ngOnChanges(changes: SimpleChanges): void {
  //  debugger;
   }

  buscarDados(Id?: number) {

    this.service.getHttpContext().get(`http://localhost:57428/api/parametrovalor/retDadosViewDetalheConsumo/`  + Id).map((response: Response) => {
      const data = response.json();
    //  debugger;
      this.tableData = data;

    }).subscribe();
  }

  montarPesquisa(): SearchRequest {
    const request: SearchRequest = new SearchRequest();
    request.OrderBy = 'Nome';
    request.PageNumber = this.page;
    request.RecordsPerPage = this.perPage;
    request.SortDirection = 'asc';
    const props = Reflection.getObjectPropertyNames(this.filtros);

    const rules: FilterRule[] = [];
    const filter = new FilterRule();
    props.map((item: any) => {
      if (this.filtros[item] !== null || this.filtros[item] === -1) {
        let tipo = Reflection.getTypeofProperty(this.filtros, item);
        let rule = new FilterRule(item.toString(), this.filtros[item], 'AND', 'equal', filter.convertType(tipo.toString()));
        rules.push(rule);
      }
    });

    let rule = new FilterRule('FlagAtivo', 'S', 'AND', 'equal', 'string');
    rules.push(rule);

    filter.Rules = rules;
    request.Filter = filter;
    return request;
  }
  onSearch(): void {
    /* this.dialogService.addDialog(ProdespMonitorPesquisaMotivoAcaoComponent, {
      title: 'Pesquisar Motivo/Ação',
      closeButtonText: 'Fechar',
      confirmButtonText: 'Pesquisar',
      showConfirmButton: true,
      filtros: this.filtros
    }).subscribe((result) => {
      this.page = 1;
      this.buscarPagina(this.totalPages);
    }); */
  }
  perPageChanged(value: any) {
    this.page = 1;
    this.perPage = value;
    this.buscarDados();
  }
}
