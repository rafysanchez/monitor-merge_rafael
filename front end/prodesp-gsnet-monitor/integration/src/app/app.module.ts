import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ProdespGsnetMonitorModule } from 'prodesp-gsnet-monitor';

import { AppComponent }  from './app.component';

@NgModule({
  imports:      [ BrowserModule, ProdespGsnetMonitorModule],
  declarations: [ AppComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
