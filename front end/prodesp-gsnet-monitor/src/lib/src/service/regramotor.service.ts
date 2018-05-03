import { AppConfig } from './config.service';
import { Http, Response } from '@angular/http';
import { RegraMotor } from './../models/Regramotor';
import { Injectable } from '@angular/core';
import { BaseService } from 'prodesp-core';
import { MonitorConfig } from '../models/monitorconfig';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class RegraMotorService extends BaseService<RegraMotor> {

    // url = 'http://10.2.108.182:4500/Prodesp.Gsnet.Monitor.WebApi/api/motivoacao';
   // public  url = 'http://localhost:57428/api/motivoacao';
    constructor(http: Http, appConfig: AppConfig) {
        const host: string = appConfig.getConfig('host');
        super(host + 'api/regrammotor', http);
    }

    Cadastrar(parametro: RegraMotor): Observable<Response> {
        const httpContext = this.getHttpContext();
        return httpContext.post(this.url + `/InserirDadosRegraParametroValor`, parametro);
    }

    Editar(parametro: RegraMotor): Observable<Response> {
        const httpContext = this.getHttpContext();
        return httpContext.post(this.url + `/EditarDadosRegraParametroValor`, parametro);
    }
}
