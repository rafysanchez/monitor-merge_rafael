import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'prodesp-loader',
  templateUrl: './prodesp-loader.component.html',
  styleUrls: ['./prodesp-loader.component.css']
})
export class ProdespLoaderComponent implements OnInit {

  @Input()isLoading: boolean;
  constructor() { }

  ngOnInit() {
  }

}
