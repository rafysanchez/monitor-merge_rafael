import { AppConfig } from '../../service/config.service';
import { ParametroLista } from './../../models/parametroLista';
import { Component, OnInit } from '@angular/core';
import { TableOptions, TableColumnDefinition } from 'prodesp-ui';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Observable } from 'rxjs/Rx';
import { DialogService } from 'ng2-bootstrap-modal/dist/dialog.service';
import { Response } from '@angular/http';
import { ParametroService } from './../../service/parametro.service';
import { SearchRequest } from './../../models/searchrequest';
import { Reflection } from './../../models/reflection';
import { FilterRule } from './../../models/filter.rule';
import { PesquisaRegraMotor } from './../../models/PesquisaRegraMotor';
import { ProdespMonitorModalParametroComponent } from '../prodesp-monitor-modal-parametro/prodesp-monitor-modal-parametro.component';
import { Parametro } from './../../models/parametro';
import { TipoParametro } from './../../models/tipoparametro';
import { ProdespMonitorModalDetalheParametroComponent } from '../prodesp-monitor-modal-detalhe-parametro/prodesp-monitor-modal-detalhe-parametro.component';

@Component({
  selector: 'prodesp-monitor-parametro',
  templateUrl: './prodesp-monitor-parametro.component.html',
  styleUrls: ['./prodesp-monitor-parametro.component.css']
})
export class ProdespMonitorParametroComponent implements OnInit {
  Tipos: TipoParametro[];
  selectedTipo: number;
  comboData: TipoParametro[];
  tableConfig: TableOptions;
  tableData: ParametroLista[];
  page = 1;
  perPage = 5;
  totalPages = 1;
  filtros: PesquisaRegraMotor = new PesquisaRegraMotor();
  parametros: any[]; /*Mutavel,defini o tipo de de receber o valor*/
  constructor(
    private dialogService: DialogService,
    private service: ParametroService,
    private appConfig: AppConfig
  ) {
    this.parametros = [];
  }

  /*Start inicial do componente onde vai ser gerado a tag,onload componet
   */
  ngOnInit() {
    this.selectedTipo = 0;

    this.tableConfig = new TableOptions();
    this.tableConfig.showPerPage = [5, 15, 20, 100, 200, 300];
    this.tableConfig.tableHeader = 'Parâmetro';

    this.tableConfig.columnsDefinition = [
      new TableColumnDefinition('', 'Programa'),
      new TableColumnDefinition('', 'Tipo'),
      new TableColumnDefinition('', 'Vigência'),
      new TableColumnDefinition('', 'Status'),
      new TableColumnDefinition('', 'Ações')
    ];
    this.Tipos = [
      new TipoParametro(1, '1', 'Autonomia Consumo'),
      new TipoParametro(2, '2', 'Saldo Zerado')
    ];
    this.comboData = this.Tipos;
    this.buscarPagina(this.totalPages);
    this.carregaComboTipos();
  }
  initTableData(): void {
    this.service
      .buscarTodos()
      .map((resp: any) => {
        this.tableData = resp;
        /* console.log('Entrou no table data');
      console.log(this.tableData); */
      })
      .subscribe();
  }
  carregaComboTipos() {
    /* this.service.getHttpContext().get(`http://localhost:57428/api/regramotor/ListCombo`).map((response: Response) => {
     // debugger
      const data = response.json();
      this.comboData = data;
      console.log(this.comboData);
    }).subscribe(); */
  }
  onSelect(Id: number) {
    this.selectedTipo = Id;
    // debugger
    console.log(this.selectedTipo);
  }
  onAdd(tipo: number): void {
    const novoPrograma = new Parametro();

    novoPrograma.Tipo = this.selectedTipo;
    if (tipo > 0) {
      console.log('tipo: ' + tipo);
      this.dialogService
        .addDialog(ProdespMonitorModalParametroComponent, {
          title:
            novoPrograma.Tipo == 1
              ? 'Cadastro - Autonomia Consumo'
              : 'Cadastro Saldo Zerado',
          closeButtonText: 'Fechar',
          confirmButtonText: 'Salvar',
          showConfirmButton: true,
          isClickDisabled: true,
          editMode: false,
          tipoPrograma: this.selectedTipo,
          novoParametro: novoPrograma
        })
        .subscribe(result => {
          if (result) {
            this.service
              .Cadastrar(result)
              .map((response: any) => {
                alert('ok');
                // this.result = result;
              })
              .catch((error: Response) => {

                alert('deu erro');

                return Observable.throw(error);
              })
              .subscribe();
          }
        });
    }
  }
  onEdit(item: Parametro): void {
    this.service.CarregarPorID(`/${item.IdRegraMotor.toString()}`)
      .map(response => {
        this.dialogService
          .addDialog(ProdespMonitorModalParametroComponent, {
            title: 'Editar Parâmetros Autonomia - Consumo',
            closeButtonText: 'Fechar',
            confirmButtonText: 'Salvar',
            showConfirmButton: true,
            isClickDisabled: true,
            editMode: true,
            tipoPrograma: this.selectedTipo
            , novoParametro: response.json() as Parametro
          })
          .subscribe(result => {
            if (result) {
              this.service
                .Editar(result)
                // tslint:disable-next-line:no-shadowed-variable
                .map((response: any) => {
                  alert('ok');
                  // this.result = result;
                })
                .catch((error: Response) => {

                  alert('deu erro');

                  return Observable.throw(error);
                })
                .subscribe();
            }
          });
      })
      .subscribe();
  }

/* 
  onDetalhe(item: Parametro): void {
    this.service
      .buscarPorId(`/${item.IdRegraMotor.toString()}`)
      .map(Response => {
        this.dialogService
          .addDialog(ProdespMonitorModalDetalheParametroComponent, {
            title: 'Detalhes  Autonomia - Consumo',
            closeButtonText: 'Fechar',
            showConfirmButton: true,
            isClickDisabled: true,
            novoParametro: Response,
            idRegraMotor: item.IdRegraMotor
          })
          .subscribe(result => {
            if (result.sucesso) {
              this.initTableData();
            }
          });
      })
      .subscribe();
  }
 */
  buscarPagina(totalPages?: number) {

    const request = this.montarPesquisa();
    this.service
      .getHttpContext()
      .post(`${this.appConfig.getConfig('host')}api/regramotor/queryitens`, request)
      .map((response: Response) => {
        const data = response.json();

        this.tableData = data.Itens;
        if (totalPages) {
          this.totalPages = data.TotalPages;
        }
      })
      .subscribe();
  }
  montarPesquisa(): SearchRequest {
    const request: SearchRequest = new SearchRequest();
    request.OrderBy = 'IdRegraMotor';
    request.PageNumber = this.page;
    request.RecordsPerPage = this.perPage;
    request.SortDirection = 'asc';
    const props = Reflection.getObjectPropertyNames(this.filtros);

    const rules: FilterRule[] = [];
    const filter = new FilterRule();
    props.map((item: any) => {
      if (this.filtros[item] !== null || this.filtros[item] === -1) {
        let tipo = Reflection.getTypeofProperty(this.filtros, item);
        let rule = new FilterRule(
          item.toString(),
          this.filtros[item],
          'AND',
          'equal',
          filter.convertType(tipo.toString())
        );
        rules.push(rule);
      }
    });

    let rule = new FilterRule('FlagAtivo', 'S', 'AND', 'equal', 'string');
    rules.push(rule);

    filter.Rules = rules;
    request.Filter = filter;
    return request;
  }
  decodeSituacao(item: ParametroLista): string {
    return item.FlagAtivo ? 'Ativo' : 'Inativo';
  }
  decodeTipo(item: ParametroLista): string {
    return item.Tipo ? 'Ativo' : 'Inativo';
  }
  pageChanges(value: any) {
    this.page = value;
    this.buscarPagina();
  }
  perPageChanged(value: any) {
    this.page = 1;
    this.perPage = value;
    this.buscarPagina();
  }

  onSearch(): void {
    /*     this.dialogService.addDialog(ProdespMonitorPesquisaMotivoAcaoComponent, {
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
}
