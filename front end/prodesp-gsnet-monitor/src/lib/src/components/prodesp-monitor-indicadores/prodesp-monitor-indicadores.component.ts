import { IndicadoresService } from './../../service/indicadores.service';
import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Response } from '@angular/http';
import { Indicadores } from '../../models/indicadores.model';
import { Datetime } from 'prodesp-core';

@Component({
  selector: 'prodesp-monitor-indicadores',
  templateUrl: './prodesp-monitor-indicadores.component.html',
  styleUrls: ['./prodesp-monitor-indicadores.component.css']
})
export class ProdespMonitorIndicadoresComponent implements OnInit {
  @Input()indicadores: any;
  constructor(private indicadoresService: IndicadoresService) { }

  ngOnInit() {
    console.log('monitoramento ' + this.indicadores);
    debugger
    let date = new Datetime();
    //let datetime = date.toDateTime(this.indicadores.DataMonitoramento);

  }

}
