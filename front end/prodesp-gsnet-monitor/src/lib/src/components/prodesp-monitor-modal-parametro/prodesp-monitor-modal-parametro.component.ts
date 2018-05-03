import { ModalComponent } from '../../models/modal.component.model';
import { DialogService } from 'ng2-bootstrap-modal/dist/dialog.service';
import { IModal } from 'prodesp-ui';
import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { Parametro } from '../../models/parametro';
import { ParametroService } from '../../service/parametro.service';
import { TipoAcaoMotivo } from './../../models/tipoacaomotivo';
import { TipoProgramaSaude } from './../../models/TipoProgramaSaude';
import { Response } from '@angular/http';

export interface IModalParametro extends IModal {
  novoParametro: Parametro;
  editMode: boolean;
  tipoPrograma: number;

}

@Component({
  selector: 'app-prodesp-monitor-modal-parametro',
  templateUrl: './prodesp-monitor-modal-parametro.component.html',
  styleUrls: ['./prodesp-monitor-modal-parametro.component.css']
})
export class ProdespMonitorModalParametroComponent extends ModalComponent<IModalParametro> implements OnInit, OnChanges, IModalParametro {
  tipoPrograma: number;
  comboData: TipoProgramaSaude[];
  editMode: boolean;
  novoParametro: Parametro;
  Erros: string;
  mensagem: string = null;
  Tipos: TipoAcaoMotivo[]= [];
  constructor(dialogService: DialogService, private service: ParametroService) {
    super(dialogService);
   }
   ngOnInit() {
    // this.novoMotivoAcao = this.novoMotivoAcao === null ? new MotivoAcao() : this.novoMotivoAcao;
    this.Tipos  = [
      new TipoAcaoMotivo(0, 'Ação'),
      new TipoAcaoMotivo(1, 'Motivo'),
    ];

  this.carregaComboNomeprogramas();
  }
  ngOnChanges(changes: SimpleChanges): void {
    // debugger;
   }
   confirm(data: any) {
    this.result = this.novoParametro;
    this.closeModal();
  /*   let result: any = {};
    if (this.editMode) {
      debugger;
      this.service.atualizar(data).map((response: any) => {
        response = response.json();
        result.sucesso = response.Sucesso;
        if (!response.Sucesso) {
          result.mensagem = response.Mensagem;
          this.Erros = response.Mensagem;
        } else {
          this.mostrarMensagemSucesso('Registro atualizado com sucesso.');
          // this.close();
        }
      }).subscribe();
    } else {
    } */
  }
  carregaComboNomeprogramas () {
    this.service.getHttpContext().get(`http://localhost:57428/api/programasaude/ListarProgramasSaude`).map((response: Response) => {
      // debugger
       const data = response.json();
       this.comboData = data;
       console.log(data);
     }).subscribe();

  }
   limparMotivoAcao() {
    this.novoParametro.NomePrograma = '';
    this.novoParametro.NomeTipoParametro = '';
   this.novoParametro.ConsumoMensal = '';
   this.novoParametro.Autonomia = '';
  this.novoParametro.FormulaCalculo =  '' ;
   // this.novoParametro.Situacao = false;
  }
  mostrarMensagemSucesso(mensagem: string): void {
    this.mensagem = mensagem;
    setTimeout(() => this.mensagem = null, 3000);
  }
}
