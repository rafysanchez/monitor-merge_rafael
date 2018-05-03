import { Http, Response } from '@angular/http';
import { ListDadosFarmacia } from './../models/ListDadosFarmacia';
import { Injectable } from '@angular/core';
import { BaseService } from 'prodesp-core';
import { MonitorConfig } from '../models/monitorconfig';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class ItensporProgramaService extends BaseService<ListDadosFarmacia> {

    // url = 'http://10.2.108.182:4500/Prodesp.Gsnet.Monitor.WebApi/api/motivoacao';
   // public  url = 'http://localhost:57428/api/motivoacao';
    constructor(http: Http) {
        super('http://localhost:57428/api/parametro', http);
    }
    CarregarPorID(id: string): Observable<Response> {
        const httpContext = this.getHttpContext();
        return httpContext.get(`http://localhost:57428/api/regramotor/GetByIdDadosAEditar/` + id);
    }
    Cadastrar(parametro: ListDadosFarmacia): Observable<Response> {
        const httpContext = this.getHttpContext();
        return httpContext.post('http://localhost:57428/api/regramotor' + `/InserirDadosRegraParametroValor`, parametro);
    }
    // api/regramotor/EditarDadosRegraParametroValor
    Editar(parametro: ListDadosFarmacia): Observable<Response> {
        const httpContext = this.getHttpContext();
        return httpContext.post('http://localhost:57428/api/regramotor' + `/EditarDadosRegraParametroValor`, parametro);
    }
}
