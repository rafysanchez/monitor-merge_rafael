import { Motivo } from './../models/motivo';
import { Injectable } from '@angular/core';

@Injectable()
export class MotivoService {

    constructor() { }
    get() {
        return [
            new Motivo(1, 'Falha na Programação'),
            new Motivo(2, 'Paciente Novo'),
            new Motivo(3, 'Aguardando Emissão de Fatura'),
            new Motivo(4, 'Aguardando entrega da Furp'),
            new Motivo(0, 'Outros'),
        ];
    }
}

