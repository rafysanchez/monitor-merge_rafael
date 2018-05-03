import { AppConfig } from './config.service';
import { SearchRequest } from './../models/searchrequest';
import { Observable } from 'rxjs/Rx';
import { Justificativa } from './../models/justificativa';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { BaseService } from 'prodesp-core';


@Injectable()
export class JustificativaService extends BaseService<Justificativa> {

    private host: string;
    constructor(http: Http, appConfig: AppConfig) {
        const _host = appConfig.getConfig('host');
        super(_host + '/api/justificativa', http);
        this.host = _host;
     }

    justificar(request: any): Observable<Response> {
        return  this.getHttpContext().post(`${this.host}api/justificativa/justificar`, request);
    }
    usarAnterior(request: any): Observable<Response> {
        return  this.getHttpContext().post(`${this.host}api/justificativa/usarAnterior`, request);
    }
    buscarHistorico(idItemGsnet: number, idPrograma: number, idGestor: number) {
        return  this.getHttpContext().get(`${this.host}api/justificativa/historico/${idPrograma}/${idItemGsnet}/${idGestor}?TYPE=json`);
    }
    buscarItemsMonitorados(request: SearchRequest): Observable<Response> {
        return  this.getHttpContext().post(`${this.host}api/itemmonitor/queryitens?TYPE=json`, request);
    }
    buscarPorItemMonitoramento(iditem: number, idJustificador: number): Observable<Response> {
        return  this.getHttpContext().get(`${this.host}api/justificativa/BuscarPorItem/${iditem}/${idJustificador}?TYPE=json`);
    }
    buscarUltimasJustificativas(idItem: number, idJustificador: number, idGestor: number): Observable<Response> {
        return this.getHttpContext().get(`${this.host}api/justificativa/BuscarUltimasJustificativas/${idItem}/${idJustificador}/${idGestor}?TYPE=json`);
    }
    usarJustificativaAnterior(data: any): Observable<Response> {
        return this.getHttpContext().post(`${this.host}api/justificativa/UsarJustificativaAnterior`, data);
    }
    justificarVarios(data: any): Observable<Response> {
        return this.getHttpContext().post(`${this.host}api/justificativa/JustificarVarios`, data);
    }
    deletarVarios(data: any): Observable<Response> {
        return this.getHttpContext().post(`${this.host}api/justificativa/DeletarVarios`, data);
    }
    justificarPorPrograma(data: any): Observable<Response> {
        return this.getHttpContext().post(`${this.host}api/justificativa/justificarPorPrograma`, data);
    }
    // justificarPorPrograma
}
