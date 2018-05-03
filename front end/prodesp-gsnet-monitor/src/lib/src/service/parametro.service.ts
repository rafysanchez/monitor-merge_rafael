import { AppConfig } from './../service/config.service';
import { Http, Response } from '@angular/http';
import { Parametro } from './../models/parametro';
import { Injectable } from '@angular/core';
import { BaseService } from 'prodesp-core';
import { MonitorConfig } from '../models/monitorconfig';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class ParametroService extends BaseService<Parametro> {

    url: string; //'http://10.2.108.182:4500/Prodesp.Gsnet.Monitor.WebApi/api/motivoacao';
   // public  url = 'http://localhost:57428/api/motivoacao';
    constructor(http: Http, appConfig: AppConfig) {
        const host: string = appConfig.getConfig('host');
        super(host + 'api/regramotor/', http);
       // this.url = appConfig.getConfig('host');
    }
    CarregarPorID(id: string): Observable<Response> {
        const httpContext = this.getHttpContext();
        return httpContext.get(`${this.url}GetByIdDadosAEditar/` + id);
    }
    Cadastrar(parametro: Parametro): Observable<Response> {
        const httpContext = this.getHttpContext();
        return httpContext.post(`${this.url}InserirDadosRegraParametroValor`, parametro);
    }
    // api/regramotor/EditarDadosRegraParametroValor
    Editar(parametro: Parametro): Observable<Response> {
        const httpContext = this.getHttpContext();
        return httpContext.post(`${this.url}EditarDadosRegraParametroValor`, parametro);
    }
}
