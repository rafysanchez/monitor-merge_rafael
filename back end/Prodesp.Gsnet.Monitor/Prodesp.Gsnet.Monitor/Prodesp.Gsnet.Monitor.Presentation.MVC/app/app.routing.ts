import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {  ProdespGsnetMonitorMotivoAcaoComponent, ProdespMonitorParametroComponent, ProdespMonitorJustificativaComponent } from 'prodesp-gsnet-monitor';

const appRoutes: Routes = [
    {
        path: '', redirectTo: 'motivo-acao', pathMatch: 'full'
    },
    {
        path: 'motivo-acao',
        component: ProdespGsnetMonitorMotivoAcaoComponent,
        data: [{
            breadcrumb: 'Motivos e Ações',
            title: 'Cadastros - Motivos e Ações  '
        }]
    },
    {
        path: 'parametros',
        component: ProdespMonitorParametroComponent,
        data: {
            breadcrumb: 'Parametros',
            title: 'Cadastros - Paramentros '
        }
    },
    {
        path: 'justificativa',
        component: ProdespMonitorJustificativaComponent,
        data: {
            breadcrumb: 'Justificativa',
            title: 'CAF - Justificativas  '
        }
    }   
];

export const routing: ModuleWithProviders =
    RouterModule.forRoot(appRoutes);