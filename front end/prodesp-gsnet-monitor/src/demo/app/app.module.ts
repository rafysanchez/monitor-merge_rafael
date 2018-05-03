import { NgModule }      from '@angular/core';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProdespGsnetMonitorModule } from 'prodesp-gsnet-monitor';
/* import { SweetAlertService } from 'angular-sweetalert-service'; */

import { AppComponent }  from './app.component';

@NgModule({
  imports:      [ HttpModule, BrowserModule, ProdespGsnetMonitorModule, FormsModule, ReactiveFormsModule],
  declarations: [ AppComponent ],
  providers : [
    //SweetAlertService
  ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
