import { AppConfig } from './config.service';
import { Http, Response } from '@angular/http';
import { MotivoAcao } from './../models/motivo.acao.model';
import { Injectable } from '@angular/core';
import { BaseService } from 'prodesp-core';
import { MonitorConfig } from '../models/monitorconfig';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Observable } from 'rxjs/Rx';
@Injectable()
export class MotivoAcaoService extends BaseService<MotivoAcao> {

    // url = 'http://10.2.108.182:4500/Prodesp.Gsnet.Monitor.WebApi/api/motivoacao';
   // public  url = 'http://localhost:57428/api/motivoacao';
    constructor(http: Http, config: AppConfig) {
        const host: string = config.getConfig('host');
        super(host + 'api/motivoacao', http);
    }
    buscarPorTipo(id: number): Observable<Response> {
        const httpContext = this.getHttpContext();
        return httpContext.get(this.url + `/tipo/${id}?type=json`);
    }
}
