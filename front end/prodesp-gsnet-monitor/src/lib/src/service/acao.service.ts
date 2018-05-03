import { Injectable } from '@angular/core';
import { Acao } from './../models/acao';
import {BaseService} from 'prodesp-core';
import { Http } from '@angular/http';
@Injectable()
export class AcaoService extends BaseService<Acao> {

    constructor(_http: Http) {
        super('', _http);
    }
    get() {
        return [
            new Acao(1, 'Compra solicitada'),
            new Acao(2, 'Remanejamento'),
            new Acao(0, 'Outros')
        ];
    }

}

