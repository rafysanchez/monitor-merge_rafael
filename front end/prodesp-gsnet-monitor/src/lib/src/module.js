"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var prodesp_sidebar_component_1 = require("./components/prodesp-sidebar/prodesp-sidebar.component");
var config_service_1 = require("./service/config.service");
var monitor_pesquisa_motivo_acao_component_1 = require("./components/prodesp-monitor-pesquisa-motivo-acao/monitor-pesquisa-motivo-acao.component");
var justificativa_service_1 = require("./service/justificativa.service");
var prodesp_breadcrumb_component_1 = require("./components/prodesp-breadcrumb/prodesp-breadcrumb.component");
var prodesp_monitor_parametro_component_1 = require("./components/prodesp-monitor-parametro/prodesp-monitor-parametro.component");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var platform_browser_1 = require("@angular/platform-browser");
var router_1 = require("@angular/router");
var http_1 = require("@angular/http");
var prodesp_core_1 = require("prodesp-core");
var prodesp_ui_1 = require("prodesp-ui");
var prodesp_monitor_justificativa_component_1 = require("./components/prodesp-monitor-justificativa/prodesp-monitor-justificativa.component");
var prodesp_item_justificativa_component_1 = require("./components/prodesp-item-justificativa/prodesp-item-justificativa.component");
var prodesp_table_expandable_component_1 = require("./components/prodesp-table-expandable/prodesp-table-expandable.component");
var prodesp_fluxo_justificativa_component_1 = require("./components/prodesp-fluxo-justificativa/prodesp-fluxo-justificativa.component");
var prodesp_monitor_modal_historico_component_1 = require("./components/prodesp-monitor-modal-historico/prodesp-monitor-modal-historico.component");
var pesquisa_medicamento_component_1 = require("./components/prodesp-monitor-modal-pesquisa-medicamento/pesquisa-medicamento.component");
var ultimas_justificativas_component_1 = require("./components/prodesp-monitor-ultimas-justificativas/ultimas-justificativas.component");
var justificativa_programa_component_1 = require("./components/prodesp-monitor-modal-justificativa-programa/justificativa-programa.component");
var prodesp_monitor_indicadores_component_1 = require("./components/prodesp-monitor-indicadores/prodesp-monitor-indicadores.component");
var indicadores_service_1 = require("./service/indicadores.service");
var prodesp_monitor_modal_confirm_component_1 = require("./components/prodesp-monitor-modal-confirm/prodesp-monitor-modal-confirm.component");
var motivo_service_1 = require("./service/motivo.service");
var acao_service_1 = require("./service/acao.service");
var nova_justificativa_component_1 = require("./components/prodesp-monitor-modal-nova-justificativa/nova-justificativa.component");
var prodesp_justificativa_component_1 = require("./components/prodesp-justificativa/prodesp-justificativa.component");
var status_directive_1 = require("./directives/status.directive");
var prodesp_monitor_modal_parametro_component_1 = require("./components/prodesp-monitor-modal-parametro/prodesp-monitor-modal-parametro.component");
var prodesp_monitor_modal_detalhe_parametro_component_1 = require("./components/prodesp-monitor-modal-detalhe-parametro/prodesp-monitor-modal-detalhe-parametro.component");
var prodesp_monitor_itens_por_programa_component_1 = require("./components/prodesp-monitor-itens-Por-Programa/prodesp-monitor-itens-por-programa.component");
var ng_bootstrap_1 = require("@ng-bootstrap/ng-bootstrap");
var ng2_bootstrap_modal_1 = require("ng2-bootstrap-modal");
var prodesp_navbar_component_1 = require("./components/prodesp-navbar/prodesp-navbar.component");
var monitor_motivo_acao_component_1 = require("./components/prodesp-gsnet-monitor-motivo-acao/monitor-motivo-acao.component");
var motivoacao_service_1 = require("./service/motivoacao.service");
var monitor_modal_motivo_acao_component_1 = require("./components/prodesp-gsnet-monitor-modal-motivo-acao/monitor-modal-motivo-acao.component");
var prodesp_titlebar_component_1 = require("./components/prodesp-titlebar/prodesp-titlebar.component");
var prodesp_loader_component_1 = require("./components/prodesp-loader/prodesp-loader.component");
var parametro_service_1 = require("./service/parametro.service");
var regramotor_service_1 = require("./service/regramotor.service");
exports.monitorRoutes = [
    {
        path: 'motivo-acao',
        component: monitor_motivo_acao_component_1.ProdespGsnetMonitorMotivoAcaoComponent,
        data: [{
                breadcrumb: 'Motivos e Ações',
                title: 'Cadastros - Motivos e Ações  '
            }]
    },
    {
        path: 'parametros',
        component: prodesp_monitor_parametro_component_1.ProdespMonitorParametroComponent,
        data: {
            breadcrumb: 'Parametros',
            title: 'Cadastros - Parametros '
        }
    },
    {
        path: 'justificativa',
        component: prodesp_monitor_justificativa_component_1.ProdespMonitorJustificativaComponent,
        data: {
            breadcrumb: 'Justificativa',
            title: 'CAF - Justificativas  '
        }
    },
    {
        path: 'ItensPorPrograma',
        component: prodesp_monitor_itens_por_programa_component_1.ProdespMonitorItensPorProgramaComponent,
        data: {
            breadcrumb: 'Itens por Farmácia',
            title: 'Itens por Farmácia  '
        }
    }
];
var ProdespGsnetMonitorModule = ProdespGsnetMonitorModule_1 = (function () {
    function ProdespGsnetMonitorModule() {
    }
    ProdespGsnetMonitorModule.forRoot = function () {
        return {
            ngModule: ProdespGsnetMonitorModule_1,
            providers: [
                ng2_bootstrap_modal_1.DialogService,
                acao_service_1.AcaoService,
                motivo_service_1.MotivoService,
                indicadores_service_1.IndicadoresService,
                motivoacao_service_1.MotivoAcaoService,
                parametro_service_1.ParametroService,
                regramotor_service_1.RegraMotorService
            ],
        };
    };
    return ProdespGsnetMonitorModule;
}());
ProdespGsnetMonitorModule = ProdespGsnetMonitorModule_1 = __decorate([
    core_1.NgModule({
        imports: [
            prodesp_core_1.ProdespCoreModule,
            prodesp_ui_1.ProdespUiModule,
            ng2_bootstrap_modal_1.BootstrapModalModule,
            ng_bootstrap_1.NgbModule.forRoot(),
            forms_1.FormsModule,
            forms_1.ReactiveFormsModule,
            platform_browser_1.BrowserModule,
            router_1.RouterModule.forRoot(exports.monitorRoutes)
        ],
        declarations: [
            prodesp_table_expandable_component_1.ProdespExpandableTable,
            prodesp_item_justificativa_component_1.ProdespItemJustificativaComponent,
            prodesp_justificativa_component_1.ProdespJustificativaComponent,
            prodesp_monitor_justificativa_component_1.ProdespMonitorJustificativaComponent,
            prodesp_monitor_parametro_component_1.ProdespMonitorParametroComponent,
            prodesp_fluxo_justificativa_component_1.ProdespFluxoJustificativaComponent,
            status_directive_1.ProdespStatusDirective,
            prodesp_sidebar_component_1.ProdespSidebarComponent,
            prodesp_monitor_modal_historico_component_1.ProdespMonitorModalHistoricoComponent,
            nova_justificativa_component_1.ProdespMonitorModalNovaJustificativaComponent,
            pesquisa_medicamento_component_1.ProdespMonitorModalPesquisaMedicamentoComponent,
            ultimas_justificativas_component_1.ProdespMonitorUltimasJustificativasComponent,
            prodesp_monitor_modal_confirm_component_1.ProdespMonitorModalConfirmComponent,
            justificativa_programa_component_1.ProdespMonitorModalJustificativaProgramaComponent,
            prodesp_monitor_modal_parametro_component_1.ProdespMonitorModalParametroComponent,
            prodesp_monitor_indicadores_component_1.ProdespMonitorIndicadoresComponent,
            prodesp_navbar_component_1.ProdespNavbarComponent,
            monitor_motivo_acao_component_1.ProdespGsnetMonitorMotivoAcaoComponent,
            monitor_modal_motivo_acao_component_1.ProdespGsnetMonitorModalMotivoAcaoComponent,
            prodesp_breadcrumb_component_1.ProdespBreadcrumbComponent,
            prodesp_titlebar_component_1.ProdespTitlebarComponent,
            monitor_pesquisa_motivo_acao_component_1.ProdespMonitorPesquisaMotivoAcaoComponent,
            prodesp_monitor_modal_detalhe_parametro_component_1.ProdespMonitorModalDetalheParametroComponent,
            prodesp_monitor_itens_por_programa_component_1.ProdespMonitorItensPorProgramaComponent,
            monitor_pesquisa_motivo_acao_component_1.ProdespMonitorPesquisaMotivoAcaoComponent,
            prodesp_loader_component_1.ProdespLoaderComponent
        ],
        providers: [
            ng2_bootstrap_modal_1.DialogService,
            acao_service_1.AcaoService,
            motivo_service_1.MotivoService,
            indicadores_service_1.IndicadoresService,
            motivoacao_service_1.MotivoAcaoService,
            parametro_service_1.ParametroService,
            config_service_1.AppConfig,
            { provide: core_1.APP_INITIALIZER, useFactory: function (config) { return function () { return config.load(); }; }, deps: [config_service_1.AppConfig], multi: true },
            justificativa_service_1.JustificativaService,
            {
                provide: http_1.XHRBackend,
                useClass: prodesp_core_1.AuthInterceptor
            },
            {
                provide: prodesp_core_1.WebStorage,
                useClass: prodesp_core_1.CookieStorage
            }
        ],
        exports: [
            monitor_pesquisa_motivo_acao_component_1.ProdespMonitorPesquisaMotivoAcaoComponent,
            prodesp_table_expandable_component_1.ProdespExpandableTable,
            prodesp_item_justificativa_component_1.ProdespItemJustificativaComponent,
            prodesp_justificativa_component_1.ProdespJustificativaComponent,
            prodesp_monitor_justificativa_component_1.ProdespMonitorJustificativaComponent,
            prodesp_monitor_parametro_component_1.ProdespMonitorParametroComponent,
            prodesp_fluxo_justificativa_component_1.ProdespFluxoJustificativaComponent,
            status_directive_1.ProdespStatusDirective,
            prodesp_sidebar_component_1.ProdespSidebarComponent,
            prodesp_monitor_modal_historico_component_1.ProdespMonitorModalHistoricoComponent,
            nova_justificativa_component_1.ProdespMonitorModalNovaJustificativaComponent,
            pesquisa_medicamento_component_1.ProdespMonitorModalPesquisaMedicamentoComponent,
            ultimas_justificativas_component_1.ProdespMonitorUltimasJustificativasComponent,
            prodesp_monitor_modal_confirm_component_1.ProdespMonitorModalConfirmComponent,
            justificativa_programa_component_1.ProdespMonitorModalJustificativaProgramaComponent,
            prodesp_monitor_indicadores_component_1.ProdespMonitorIndicadoresComponent,
            prodesp_navbar_component_1.ProdespNavbarComponent,
            monitor_motivo_acao_component_1.ProdespGsnetMonitorMotivoAcaoComponent,
            monitor_modal_motivo_acao_component_1.ProdespGsnetMonitorModalMotivoAcaoComponent,
            prodesp_breadcrumb_component_1.ProdespBreadcrumbComponent,
            prodesp_titlebar_component_1.ProdespTitlebarComponent,
            prodesp_monitor_modal_parametro_component_1.ProdespMonitorModalParametroComponent,
            prodesp_monitor_modal_detalhe_parametro_component_1.ProdespMonitorModalDetalheParametroComponent,
            prodesp_monitor_itens_por_programa_component_1.ProdespMonitorItensPorProgramaComponent
        ],
        entryComponents: [
            prodesp_monitor_modal_historico_component_1.ProdespMonitorModalHistoricoComponent,
            nova_justificativa_component_1.ProdespMonitorModalNovaJustificativaComponent,
            pesquisa_medicamento_component_1.ProdespMonitorModalPesquisaMedicamentoComponent,
            prodesp_monitor_modal_confirm_component_1.ProdespMonitorModalConfirmComponent,
            justificativa_programa_component_1.ProdespMonitorModalJustificativaProgramaComponent,
            monitor_modal_motivo_acao_component_1.ProdespGsnetMonitorModalMotivoAcaoComponent,
            monitor_pesquisa_motivo_acao_component_1.ProdespMonitorPesquisaMotivoAcaoComponent,
            prodesp_monitor_modal_parametro_component_1.ProdespMonitorModalParametroComponent,
            prodesp_monitor_modal_detalhe_parametro_component_1.ProdespMonitorModalDetalheParametroComponent
        ]
    })
], ProdespGsnetMonitorModule);
exports.ProdespGsnetMonitorModule = ProdespGsnetMonitorModule;
var ProdespGsnetMonitorModule_1;
//# sourceMappingURL=module.js.map