import { BaseService } from 'prodesp-core';
import { Injectable, } from '@angular/core';
import { Indicadores } from '../models/indicadores.model';
import { Http } from '@angular/http';
@Injectable()
export class IndicadoresService extends BaseService<Indicadores> {

constructor(http: Http) {
    super('', http);
 }
}
