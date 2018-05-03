import { Component, OnInit, Input } from '@angular/core';
import { Menu } from '../../models/menu';

@Component({
  selector: 'prodesp-navbar',
  templateUrl: './prodesp-navbar.component.html',
  styleUrls: ['./prodesp-navbar.component.css']
})
export class ProdespNavbarComponent implements OnInit {

  @Input()logoUser: string;
  @Input()navbarBrand: string; // : '/Prodesp.Monitor/Home/Index';
  @Input()navbarLogo: string; // : '/Prodesp.Monitor/Content/img/logo_suprimentos_white.png';
  menus: Menu[] = [];
  navAccountIsOpen: boolean =  false;
  isSideBarCollapsed: boolean = false;
  constructor() { }

  ngOnInit() {
    console.log(this.navbarLogo);
    this.initMenus();
  }
  toogleOpen(menu: Menu): void {
    menu.isOpen = !menu.isOpen;
  }
  initMenus(): void {
    this.menus = [
        new Menu('#', 'fa-cogs', 'Cadastros', [
                new Menu('parametros', '', 'Parâmetros', null),
                new Menu('ItensPorPrograma', '', 'Itens por Farmácia', null),
                new Menu('motivo-acao', '', 'Motivos e Ações', null)
              ]),
        new Menu('#', 'fa-building-o', 'CAF', [
          new Menu('/justificativa', '', 'Justificativas', null)
        ]),
    ];
    console.log('menus')
    console.log(this.menus)

  }
  toogleAccountConfig(): void {
    this.navAccountIsOpen = !this.navAccountIsOpen;
  }
  toogleSideBar(): void {
    this.isSideBarCollapsed = !this.isSideBarCollapsed;
  }

}
