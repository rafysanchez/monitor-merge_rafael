import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { ProdespGsnetMonitorModule } from 'prodesp-gsnet-monitor';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DialogService, BootstrapModalModule } from 'ng2-bootstrap-modal';


@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, BootstrapModalModule, NgbModule.forRoot(), ProdespGsnetMonitorModule.forRoot()],
    declarations: [AppComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: '/' }],
    bootstrap: [AppComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class AppModule { }