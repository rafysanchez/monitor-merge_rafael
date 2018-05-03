import { Menu } from '../../models/menu';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'prodesp-sidebar',
  templateUrl: './prodesp-sidebar.component.html',
  styleUrls: ['./prodesp-sidebar.component.css']
})
export class ProdespSidebarComponent implements OnInit {

  @Input()menus: Menu[] = [];
  @Input()isSideBarCollapsed: boolean;
  constructor() { }

  ngOnInit() {
    console.log(this.menus)
  }
  toogleOpen(menu: Menu): void {
    menu.isOpen = !menu.isOpen;
  }
}
