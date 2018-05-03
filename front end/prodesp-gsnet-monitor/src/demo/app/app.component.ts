import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'demo-app',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

  meaning: number;
  logo: string ; //  '../../assets/images/logo_suprimentos_white.png';
  ngOnInit(): void {

    this.logo = '../../assets/images/logo_suprimentos_white.png';
  }
}
