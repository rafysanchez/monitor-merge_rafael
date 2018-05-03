import { MotivoAcaoService } from './../../service/motivoacao.service';
import { Response } from '@angular/http';
import { JustificativaService } from './../../service/justificativa.service';
import { Component, OnInit, OnChanges, Output, EventEmitter, Input, SimpleChanges, Directive, TemplateRef, ContentChild } from '@angular/core';
import { Timeline } from 'prodesp-ui';
import { ExpandTableData } from './../../models/expand.table.data';
import { TableOptions, TableColumnDefinition } from 'prodesp-ui';
import { Medicamento } from '../../models/medicamento';
import { FluxoJustificacao } from '../../models/fluxo.justicacao';
import { DialogService } from 'ng2-bootstrap-modal';
import { ProdespMonitorModalHistoricoComponent } from '../prodesp-monitor-modal-historico/prodesp-monitor-modal-historico.component';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Observable } from 'rxjs/Rx';
import { Acao } from '../../models/acao';
import { Motivo } from '../../models/motivo';

@Component({
    selector: 'prodesp-expandable-table',
    templateUrl: './prodesp-table-expandable.component.html',
    styleUrls: ['./prodesp-table-expandable.component.css']
})
export class ProdespExpandableTable implements OnInit, OnChanges {

    @Input() expandAll: boolean;
    @Input() noDataFound: boolean;
    @Input() tableData: ExpandTableData[];
    @Input() page: number;
    @Input() perPage: number;
    @Input() totalPages: number;
    @Input() errorMessage: string;
    selectedAll: any;
    selecteds: number;
    acoes: Acao[] = [];
    motivos: Motivo[] = [];
    @Input() tableOptions: TableOptions;
    @Output() onRowsSelected: EventEmitter<any> = new EventEmitter();
    @Output() onPageChanges: EventEmitter<any> = new EventEmitter();
    @Output() onSortClicked: EventEmitter<any> = new EventEmitter();
    sortDirection: string;
    constructor(private dialogService: DialogService, private motivoAcaoService: MotivoAcaoService) {

    }
    ngOnInit(): void {
        console.log(this.tableData);
        this.carregarDropDownAcao();
        this.carregarDropDownMotivo();
        this.sortDirection = this.tableOptions.sortDirection;
    }
    ngOnChanges(changes: SimpleChanges): void {
        this.toogleExpandAll();
    }
    pageChanges(nextPage: number): void {
        this.onPageChanges.emit(nextPage);
    }
    buscarPagina(): void {

    }
    carregarDropDownAcao(): void {
        this.motivoAcaoService.buscarPorTipo(0)
            .map((response: Response) => {
                this.acoes = response.json();
            }).subscribe();
    }
    carregarDropDownMotivo(): void {
        this.motivoAcaoService.buscarPorTipo(1)
            .map((response: Response) => {

                this.motivos = response.json();
                console.log(this.motivos)
            }).subscribe();
    }
    selectAll() {
        for (let i = 0; i < this.tableData.length; i++) {
            this.tableData[i].selected = this.selectedAll;
        }
        const selecteds = this.obterSelecionados();
        this.selecteds = selecteds.length;
        this.onRowsSelected.emit(selecteds);
    }
    checkIfAllSelected() {
        this.selectedAll = this.tableData.every(function (item: any) {
            return item.selected === true;
        });
        const selecteds = this.obterSelecionados();
        this.selecteds = selecteds.length;
        this.onRowsSelected.emit(selecteds);
    }

    isSorting(name: string) {
        return this.tableOptions.sortBy !== name && name !== '';
    };
    isSortAsc(name: string) {
        const isSortAsc: boolean = this.tableOptions.sortBy === name && this.sortDirection === 'asc';
        return isSortAsc;
    };
    isSortDesc(name: string) {
        const isSortDesc: boolean = this.tableOptions.sortBy === name && this.sortDirection === 'desc';
        return isSortDesc;
    };
    sortHeaderClick(headerName: string) {
        if (headerName) {
            if (this.tableOptions.sortBy === headerName) {
                this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
            } else {
                this.sortDirection = this.tableOptions.sortDirection;
            }
            this.tableOptions.sortBy = headerName;
            // Get the matching column
            // tslint:disable-next-line:no-shadowed-variable
            let column: TableColumnDefinition = this.tableOptions
                .columnsDefinition
                .filter((c) => c.SortColumnId === this.tableOptions.sortBy)[0];
            this.onSortClicked.emit({ column: column, sortDirection: this.sortDirection });
        }
    }
    /* initTableData(): void {
         this.tableData = [
            new ExpandTableData(new Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)',
                'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),

            new ExpandTableData(new Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)',
                'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),

            new ExpandTableData(new Medicamento('1A', 34689, 'IMUNOGLOBULINA HUMANA 5,0G INJETÁVEL (POR FRASCO)',
                'Frasco.', 0, 4, '20/05/2017', 3566, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),
            new ExpandTableData(new Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)',
                'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),

            new ExpandTableData(new Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)',
                'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),

            new ExpandTableData(new Medicamento('1A', 34689, 'IMUNOGLOBULINA HUMANA 5,0G INJETÁVEL (POR FRASCO)',
                'Frasco.', 0, 4, '20/05/2017', 3566, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),
            new ExpandTableData(new Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)',
                'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),

            new ExpandTableData(new Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)',
                'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),

            new ExpandTableData(new Medicamento('1A', 34689, 'IMUNOGLOBULINA HUMANA 5,0G INJETÁVEL (POR FRASCO)',
                'Frasco.', 0, 4, '20/05/2017', 3566, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),
            new ExpandTableData(new Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)',
                'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),

            new ExpandTableData(new Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)',
                'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),

            new ExpandTableData(new Medicamento('1A', 34689, 'IMUNOGLOBULINA HUMANA 5,0G INJETÁVEL (POR FRASCO)',
                'Frasco.', 0, 4, '20/05/2017', 3566, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),
            new ExpandTableData(new Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)',
                'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),

            new ExpandTableData(new Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)',
                'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),

            new ExpandTableData(new Medicamento('1A', 34689, 'IMUNOGLOBULINA HUMANA 5,0G INJETÁVEL (POR FRASCO)',
                'Frasco.', 0, 4, '20/05/2017', 3566, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),
            new ExpandTableData(new Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)',
                'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),

            new ExpandTableData(new Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)',
                'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia',
                new FluxoJustificacao(true, false, false), true), false, false),
        ]
    } */
    toggleExpand(row: ExpandTableData) {
        row.expanded = !row.expanded;
    }
    viewHistorico(row: ExpandTableData): void {
        this.dialogService.addDialog(ProdespMonitorModalHistoricoComponent, {
            title: `Histórico de Justificativas - ${row.data.Nome} - ${row.data.Local} ` ,
            showConfirmButton: false,
            closeButtonText: 'Fechar',
            idItemGsNet: row.data.IdItemGsnet,
            idPrograma: row.data.IdPrograma,
            idGestor: row.data.IdGestorMonitor
        });
    }
    obterSelecionados(): Array<any> {

        let selecteds = [];

        if (this.tableData.length === 0) {
            this.selecteds = 0;
        }
        // tslint:disable-next-line:one-line
        else {
            selecteds = this.tableData.filter((v) => {
                if (v.selected === true) {
                    return true;
                }
                return false;
            });
            return selecteds;
        }
    }
    toogleExpandAll() {
        this.tableData.forEach((item) => { item.expanded = this.expandAll })
    }
}
