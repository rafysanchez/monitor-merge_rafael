import { ProdespSidebarComponent } from './components/prodesp-sidebar/prodesp-sidebar.component';
import { AppConfig } from './service/config.service';
import { ProdespMonitorPesquisaMotivoAcaoComponent } from './components/prodesp-monitor-pesquisa-motivo-acao/monitor-pesquisa-motivo-acao.component';
import { JustificativaService } from './service/justificativa.service';
import { ProdespBreadcrumbComponent } from './components/prodesp-breadcrumb/prodesp-breadcrumb.component';
import { ProdespMonitorParametroComponent } from './components/prodesp-monitor-parametro/prodesp-monitor-parametro.component';

/* Angular imports */
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { XHRBackend } from '@angular/http';
/* Prodesp imports */
import {ProdespCoreModule, AuthInterceptor, WebStorage, CookieStorage} from 'prodesp-core';
import { ProdespUiModule } from 'prodesp-ui';

/* app components imports */
import { ProdespMonitorJustificativaComponent } from './components/prodesp-monitor-justificativa/prodesp-monitor-justificativa.component';
import { ProdespItemJustificativaComponent } from './components/prodesp-item-justificativa/prodesp-item-justificativa.component';
import { ProdespExpandableTable } from './components/prodesp-table-expandable/prodesp-table-expandable.component';
import { ProdespFluxoJustificativaComponent } from './components/prodesp-fluxo-justificativa/prodesp-fluxo-justificativa.component';
import { ProdespMonitorModalHistoricoComponent } from './components/prodesp-monitor-modal-historico/prodesp-monitor-modal-historico.component';
import { ProdespMonitorModalPesquisaMedicamentoComponent } from './components/prodesp-monitor-modal-pesquisa-medicamento/pesquisa-medicamento.component';
import { ProdespMonitorUltimasJustificativasComponent } from './components/prodesp-monitor-ultimas-justificativas/ultimas-justificativas.component';
import { ProdespMonitorModalJustificativaProgramaComponent } from './components/prodesp-monitor-modal-justificativa-programa/justificativa-programa.component';
import { ProdespMonitorIndicadoresComponent } from './components/prodesp-monitor-indicadores/prodesp-monitor-indicadores.component';
import { IndicadoresService } from './service/indicadores.service';
import { ProdespMonitorModalConfirmComponent } from './components/prodesp-monitor-modal-confirm/prodesp-monitor-modal-confirm.component';
import { MotivoService } from './service/motivo.service';
import { AcaoService } from './service/acao.service';
import { ProdespMonitorModalNovaJustificativaComponent } from './components/prodesp-monitor-modal-nova-justificativa/nova-justificativa.component';
// import { ProdespTableWidgetComponent, NgWidgetBody, NgWidgetActions } from './components/prodesp-table-widget/prodesp-table-widget.component';
import { ProdespJustificativaComponent } from './components/prodesp-justificativa/prodesp-justificativa.component';
import { ProdespStatusDirective } from './directives/status.directive';
import { ProdespMonitorModalParametroComponent } from './components/prodesp-monitor-modal-parametro/prodesp-monitor-modal-parametro.component'; 
import { ProdespMonitorModalDetalheParametroComponent } from './components/prodesp-monitor-modal-detalhe-parametro/prodesp-monitor-modal-detalhe-parametro.component';
import { ProdespMonitorItensPorProgramaComponent } from './components/prodesp-monitor-itens-Por-Programa/prodesp-monitor-itens-por-programa.component';

/*  3 party components */
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DialogService, BootstrapModalModule } from 'ng2-bootstrap-modal';
import { ProdespNavbarComponent } from './components/prodesp-navbar/prodesp-navbar.component';
import { ProdespGsnetMonitorMotivoAcaoComponent } from './components/prodesp-gsnet-monitor-motivo-acao/monitor-motivo-acao.component';
import { MotivoAcaoService } from './service/motivoacao.service';
import { ProdespGsnetMonitorModalMotivoAcaoComponent } from './components/prodesp-gsnet-monitor-modal-motivo-acao/monitor-modal-motivo-acao.component';
import { ProdespTitlebarComponent } from './components/prodesp-titlebar/prodesp-titlebar.component';
import { ModuleWithProviders } from '@angular/core/src/metadata/ng_module';
import { ProdespLoaderComponent } from './components/prodesp-loader/prodesp-loader.component';
import { ParametroService } from './service/parametro.service';
import { RegraMotorService } from './service/regramotor.service';



export const monitorRoutes: Routes = [
  {
    path: 'motivo-acao',
    component: ProdespGsnetMonitorMotivoAcaoComponent,
    data: [{
       breadcrumb: 'Motivos e Ações',
       title : 'Cadastros - Motivos e Ações  '
    }]
  },
  {
      path: 'parametros',
      component: ProdespMonitorParametroComponent,
      data: {
        breadcrumb: 'Parametros',
        title : 'Cadastros - Parametros '
      }
  },
  {
    path: 'justificativa',
    component: ProdespMonitorJustificativaComponent,
    data: {
      breadcrumb: 'Justificativa',
      title : 'CAF - Justificativas  '
    }
  },
  {
    path: 'ItensPorPrograma',
    component: ProdespMonitorItensPorProgramaComponent,
    data: {
      breadcrumb: 'Itens por Farmácia',
      title : 'Itens por Farmácia  '
    }
  }
];
@NgModule({
  imports: [
    ProdespCoreModule,
    ProdespUiModule,
    BootstrapModalModule,
    NgbModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    RouterModule.forRoot(
      monitorRoutes
    )
  ],
  declarations: [
    ProdespExpandableTable,
    ProdespItemJustificativaComponent,
    ProdespJustificativaComponent,
    ProdespMonitorJustificativaComponent,
    ProdespMonitorParametroComponent,
    ProdespFluxoJustificativaComponent,
    ProdespStatusDirective,
    ProdespSidebarComponent,
    ProdespMonitorModalHistoricoComponent,
    ProdespMonitorModalNovaJustificativaComponent,
    ProdespMonitorModalPesquisaMedicamentoComponent,
    // ProdespTableWidgetComponent,
    ProdespMonitorUltimasJustificativasComponent,
    ProdespMonitorModalConfirmComponent,
    ProdespMonitorModalJustificativaProgramaComponent,
    ProdespMonitorModalParametroComponent,
    ProdespMonitorIndicadoresComponent,
    ProdespNavbarComponent,
    ProdespGsnetMonitorMotivoAcaoComponent,
    ProdespGsnetMonitorModalMotivoAcaoComponent,
    ProdespBreadcrumbComponent,
    ProdespTitlebarComponent,
    ProdespMonitorPesquisaMotivoAcaoComponent,
    ProdespMonitorModalDetalheParametroComponent,
    ProdespMonitorItensPorProgramaComponent,
    ProdespMonitorPesquisaMotivoAcaoComponent,
    ProdespLoaderComponent
  ],
  providers: [
    DialogService,
    AcaoService,
    MotivoService,
    IndicadoresService,
    MotivoAcaoService,
    ParametroService,
    AppConfig,
    { provide: APP_INITIALIZER, useFactory: (config: AppConfig) => () => config.load(), deps: [AppConfig], multi: true },
    JustificativaService,
    {
      provide:  XHRBackend,
      useClass: AuthInterceptor
    },
    {
      provide:  WebStorage,
      useClass: CookieStorage
    }
  ],
  exports: [
    ProdespMonitorPesquisaMotivoAcaoComponent,
    ProdespExpandableTable,
    ProdespItemJustificativaComponent,
    ProdespJustificativaComponent,
    ProdespMonitorJustificativaComponent,
    ProdespMonitorParametroComponent,
    ProdespFluxoJustificativaComponent,
    ProdespStatusDirective,
    ProdespSidebarComponent,
    /* NgWidgetBody,
    NgWidgetActions, */
    ProdespMonitorModalHistoricoComponent,
    ProdespMonitorModalNovaJustificativaComponent,
    ProdespMonitorModalPesquisaMedicamentoComponent,
    // ProdespTableWidgetComponent,
    ProdespMonitorUltimasJustificativasComponent,
    ProdespMonitorModalConfirmComponent,
    ProdespMonitorModalJustificativaProgramaComponent,
    ProdespMonitorIndicadoresComponent,
    ProdespNavbarComponent,
    ProdespGsnetMonitorMotivoAcaoComponent,
    ProdespGsnetMonitorModalMotivoAcaoComponent,
    ProdespBreadcrumbComponent,
    ProdespTitlebarComponent,
    ProdespMonitorModalParametroComponent,
    ProdespMonitorModalDetalheParametroComponent,
    ProdespMonitorItensPorProgramaComponent

  ],
  entryComponents: [
    ProdespMonitorModalHistoricoComponent,
    ProdespMonitorModalNovaJustificativaComponent,
    ProdespMonitorModalPesquisaMedicamentoComponent,
    ProdespMonitorModalConfirmComponent,
    ProdespMonitorModalJustificativaProgramaComponent,
    ProdespGsnetMonitorModalMotivoAcaoComponent,
    ProdespMonitorPesquisaMotivoAcaoComponent,
    ProdespMonitorModalParametroComponent,
    ProdespMonitorModalDetalheParametroComponent
  ]
})
export class ProdespGsnetMonitorModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: ProdespGsnetMonitorModule,
      providers: [
        DialogService,
        AcaoService,
        MotivoService,
        IndicadoresService,
        MotivoAcaoService,
        ParametroService,
        RegraMotorService
      ],
    };
  }
 }
