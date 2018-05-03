"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var menu_1 = require("../../models/menu");
var ProdespNavbarComponent = (function () {
    function ProdespNavbarComponent() {
        this.menus = [];
        this.navAccountIsOpen = false;
        this.isSideBarCollapsed = false;
    }
    ProdespNavbarComponent.prototype.ngOnInit = function () {
        console.log(this.navbarLogo);
        this.initMenus();
    };
    ProdespNavbarComponent.prototype.toogleOpen = function (menu) {
        menu.isOpen = !menu.isOpen;
    };
    ProdespNavbarComponent.prototype.initMenus = function () {
        this.menus = [
            new menu_1.Menu('#', 'fa-cogs', 'Cadastros', [
                new menu_1.Menu('parametros', '', 'Parâmetros', null),
                new menu_1.Menu('ItensPorPrograma', '', 'Itens por Farmácia', null),
                new menu_1.Menu('motivo-acao', '', 'Motivos e Ações', null)
            ]),
            new menu_1.Menu('#', 'fa-building-o', 'CAF', [
                new menu_1.Menu('/justificativa', '', 'Justificativas', null)
            ]),
        ];
        console.log('menus');
        console.log(this.menus);
    };
    ProdespNavbarComponent.prototype.toogleAccountConfig = function () {
        this.navAccountIsOpen = !this.navAccountIsOpen;
    };
    ProdespNavbarComponent.prototype.toogleSideBar = function () {
        this.isSideBarCollapsed = !this.isSideBarCollapsed;
    };
    return ProdespNavbarComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], ProdespNavbarComponent.prototype, "logoUser", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], ProdespNavbarComponent.prototype, "navbarBrand", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], ProdespNavbarComponent.prototype, "navbarLogo", void 0);
ProdespNavbarComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-navbar',
        templateUrl: './prodesp-navbar.component.html',
        styleUrls: ['./prodesp-navbar.component.css']
    }),
    __metadata("design:paramtypes", [])
], ProdespNavbarComponent);
exports.ProdespNavbarComponent = ProdespNavbarComponent;
//# sourceMappingURL=prodesp-navbar.component.js.map