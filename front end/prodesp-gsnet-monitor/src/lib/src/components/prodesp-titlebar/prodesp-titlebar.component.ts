import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'prodesp-titlebar',
  templateUrl: './prodesp-titlebar.component.html',
  styleUrls: ['./prodesp-titlebar.component.css']
})
export class ProdespTitlebarComponent implements OnInit {

  title: string;
  constructor(private route: Router, private activatedRoute: ActivatedRoute) {

              }

  ngOnInit() {
    this.title = this.activatedRoute.snapshot.data['title'];
  }

}
