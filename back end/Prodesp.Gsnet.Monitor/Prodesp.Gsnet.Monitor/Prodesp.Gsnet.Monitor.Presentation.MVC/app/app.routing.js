"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var prodesp_gsnet_monitor_1 = require("prodesp-gsnet-monitor");
var appRoutes = [
    {
        path: '', redirectTo: 'motivo-acao', pathMatch: 'full'
    },
    {
        path: 'motivo-acao',
        component: prodesp_gsnet_monitor_1.ProdespGsnetMonitorMotivoAcaoComponent,
        data: [{
                breadcrumb: 'Motivos e Ações',
                title: 'Cadastros - Motivos e Ações  '
            }]
    },
    {
        path: 'parametros',
        component: prodesp_gsnet_monitor_1.ProdespMonitorParametroComponent,
        data: {
            breadcrumb: 'Parametros',
            title: 'Cadastros - Paramentros '
        }
    },
    {
        path: 'justificativa',
        component: prodesp_gsnet_monitor_1.ProdespMonitorJustificativaComponent,
        data: {
            breadcrumb: 'Justificativa',
            title: 'CAF - Justificativas  '
        }
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map