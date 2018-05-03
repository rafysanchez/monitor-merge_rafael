"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var prodesp_monitor_parametro_component_1 = require("./components/prodesp-monitor-parametro/prodesp-monitor-parametro.component");
var prodesp_gsnet_monitor_motivo_acao_component_1 = require("./components/prodesp-gsnet-monitor-motivo-acao/prodesp-gsnet-monitor-motivo-acao.component");
var prodesp_monitor_justificativa_component_1 = require("./components/prodesp-monitor-justificativa/prodesp-monitor-justificativa.component");
exports.monitorRoutes = [
    {
        path: 'cadastro', data: { breadcrumb: 'Cadastros', icon: 'fa-cogs' },
        children: [
            {
                path: 'motivo-acao',
                component: prodesp_gsnet_monitor_motivo_acao_component_1.ProdespGsnetMonitorMotivoAcaoComponent,
                data: {
                    breadcrumb: 'Motivos e Ações'
                }
            },
            {
                path: 'parametros',
                component: prodesp_monitor_parametro_component_1.ProdespMonitorParametroComponent,
                data: {
                    breadcrumb: 'Parametros'
                }
            }
        ]
    },
    {
        path: 'caf', data: { breadcrumb: 'CAF', icon: 'fa-building-o' },
        children: [
            {
                path: 'justificativa',
                component: prodesp_monitor_justificativa_component_1.ProdespMonitorJustificativaComponent,
                data: {
                    breadcrumb: 'Justificativa'
                }
            },
        ]
    }
];
//# sourceMappingURL=route.module.js.map