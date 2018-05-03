import { ProdespMonitorModalConfirmComponent } from './../prodesp-monitor-modal-confirm/prodesp-monitor-modal-confirm.component';
import { Observable } from 'rxjs/Rx';
import { HistoricoJustificativa } from './../../models/historicojustificativa';
import { JustificativaService } from './../../service/justificativa.service';
import { DialogService } from 'ng2-bootstrap-modal';
import { Component, OnInit } from '@angular/core';
import { DialogComponent } from 'ng2-bootstrap-modal';
import { IModal, Timeline } from 'prodesp-ui';
import { ModalComponent } from '../../models/modal.component.model';
import { Response } from '@angular/http';
export interface IModalMonitorHistorico extends IModal {
  idItemGsNet: number;
  idPrograma: number;
  idGestor: number;
  
}
@Component({
  selector: 'prodesp-monitor-modal-historico',
  templateUrl: './prodesp-monitor-modal-historico.component.html',
  styleUrls: ['./prodesp-monitor-modal-historico.component.css']
})
export class ProdespMonitorModalHistoricoComponent
  extends ModalComponent<IModalMonitorHistorico> implements OnInit {

  // historico: Timeline[];
  idItemGsNet: number;
  idPrograma: number;
  idGestor: number;
  historico: Timeline[] = [];

  constructor(private justificativaService: JustificativaService, dialogService: DialogService) {
    super(dialogService);
  }
  ngOnInit() {
    console.log(this.historico);
    this.justificativaService.buscarHistorico(this.idItemGsNet, this.idPrograma, this.idGestor).map((response: Response) => {
      const data = response.json() as HistoricoJustificativa[];
      if (!data.length)
      {
         this.showAlertDialog('O item selecionado não possui historico de justificativas',
                                'Item histórico de justificativas',
                                 'Fechar').subscribe(result => {
                                   this.closeModal();
                                 });
      }else {
        data.map((item: HistoricoJustificativa) => {
          this.historico.push(new Timeline(item.DataInicioVigencia, 'fa-tag', 'blue', this.makeTimelineBody(item), item.DataMonitoramentoExtenso, 'Resumo Diário'));
        });
    }
    }).subscribe();
  }
  showAlertDialog(msg: string, title: string, closeButtonText: string): Observable<any> {
    return this.dialogService.addDialog(ProdespMonitorModalConfirmComponent, {
      title: title,
      text: msg,
      closeButtonText: closeButtonText,
      showConfirmButton: false
    });
  }
  makeTimelineBody(item: HistoricoJustificativa): string {
    // tslint:disable-next-line:max-line-length
    return `
    <div class='table-responsive'>
    <table class="table table-striped table-hover table-bordered dataTable no-footer table-responsive font-90 tablesorter" role="grid">
       <thead>
          <tr>
             <th class="header">
             </th>
             <th class="header">
             </th>
          </tr>
       </thead>
       <tbody>
          <tr>
             <td colspan='2'><strong>F.M.E:</strong> ${item.JustificativaFME}</td>
          </tr>
          <tr>
             <td colspan='2'><strong>C.A.F:</strong> ${item.JustificativaCAF}</td>
          </tr>
          <tr>
             <td colspan='2'><strong>C.A.F Pública:</strong>${item.JustificativaCAFPublica}</td>
          </tr>
          <tr>
             <td colspan='2'> <strong>Compras:</strong> ${item.JustificativaCompras}</td>
          </tr>
          <tr>
             <td>Saldo Disponível</td>
             <td>${item.SaldoDisponivel}</td>
          </tr>
          <tr>
             <td>Consumo Medex (dia)</td>
             <td>${item.ConsumoMedex}</td>
          </tr>
          <tr>
             <td>Fatura Emitida (CAF)</td>
             <td>${item.DataUltimaFatura}</td>
          </tr>
          <tr>
            <td>Ultimo Empenho</td>
            <td>${item.DataUltimoEmpenho}</td>
          </tr>
       </tbody>
    </table>
 </div>`;
  }

}
