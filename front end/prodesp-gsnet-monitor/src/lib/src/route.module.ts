import { ProdespMonitorParametroComponent } from './components/prodesp-monitor-parametro/prodesp-monitor-parametro.component';
import { ModuleWithProviders  } from '@angular/core';
import { ProdespGsnetMonitorMotivoAcaoComponent } from './components/prodesp-gsnet-monitor-motivo-acao/monitor-motivo-acao.component';
import { RouterModule, Routes } from '@angular/router';
import { ProdespMonitorJustificativaComponent } from './components/prodesp-monitor-justificativa/prodesp-monitor-justificativa.component';

export const monitorRoutes: Routes = [
  {
     path: 'cadastro', data : { breadcrumb: 'Cadastros', icon: 'fa-cogs'},
     children: [
        {
           path: 'motivo-acao',
           component: ProdespGsnetMonitorMotivoAcaoComponent,
           data: {
              breadcrumb: 'Motivos e Ações',
              title: 'Motivos e Ações'
           }
        },
        {
          path: 'ItensPorPrograma',
          component: ProdespGsnetMonitorMotivoAcaoComponent,
          data: {
             breadcrumb: 'Itens Por Programa'
          }
       },
        {
           path: 'parametros',
           component: ProdespMonitorParametroComponent,
           data: {
              breadcrumb: 'Parametros'
           }
        }
     ]
  },
  {
    path: 'caf', data : { breadcrumb: 'CAF', icon: 'fa-building-o'},
    children: [
      {
        path: 'justificativa',
        component: ProdespMonitorJustificativaComponent,
        data: {
           breadcrumb: 'Justificativa'
        }
     },
    ]
 }
];
