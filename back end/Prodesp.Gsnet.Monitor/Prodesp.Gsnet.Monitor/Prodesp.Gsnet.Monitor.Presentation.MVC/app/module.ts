import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { RouterModule, Routes} from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { ProdespGsnetMonitorModule, ProdespGsnetMonitorMotivoAcaoComponent, ProdespMonitorParametroComponent, ProdespMonitorJustificativaComponent }
            from 'prodesp-gsnet-monitor';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DialogService, BootstrapModalModule } from 'ng2-bootstrap-modal';
import { routing } from './app.routing';

export const monitorRoutes: Routes = [   
    {
        path: 'cadastro', data: { breadcrumb: 'Cadastros', icon: 'fa-cogs' },
        children: [
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
            }
        ]
    },
    {
        path: 'caf', data: { breadcrumb: 'CAF', icon: 'fa-building-o' },
        children: [
            {
                path: 'justificativa',
                component: ProdespMonitorJustificativaComponent,
                data: {
                    breadcrumb: 'Justificativa',
                    title: 'CAF - Justificativas  '
                }
            },
        ]
    }
];
@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, BootstrapModalModule,
        NgbModule.forRoot(), routing, ProdespGsnetMonitorModule.forRoot()],
    declarations: [AppComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: '/Prodesp.Gsnet.Monitor.Angular/' }],
    bootstrap: [AppComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class AppModule { }