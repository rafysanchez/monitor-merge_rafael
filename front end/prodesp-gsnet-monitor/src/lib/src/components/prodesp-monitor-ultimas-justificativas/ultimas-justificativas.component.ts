import { JustificativaService } from './../../service/justificativa.service';
import { Component, OnInit, Input } from '@angular/core';
import { Acao } from '../../models/acao';
import { Motivo } from '../../models/motivo';
import { Justificativa } from './../../models/justificativa';
import { Response } from '@angular/http';

@Component({
  selector: 'prodesp-monitor-ultimas-justificativas',
  templateUrl: './monitor-ultimas-justificativas.component.html',
  styleUrls: ['./monitor-ultimas-justificativas.component.css']
})
export class ProdespMonitorUltimasJustificativasComponent implements OnInit {

  @Input() idItem: number;
  @Input() idItemGsnet: number;
  @Input() idGestor: number;
  @Input() idJustificador: number;
  @Input() codSetor: string;
  ultimasJustificativas: Justificativa[] = [];
  constructor(private justificativaService: JustificativaService) { }

  ngOnInit() {
    this.justificativaService.buscarUltimasJustificativas(this.idItemGsnet, this.idJustificador, this.idGestor)
        .map((response: Response) => {
            const data = response.json();
            console.log('ultimas justificativas');
            this.ultimasJustificativas = data;
        }).subscribe();
  }

}
