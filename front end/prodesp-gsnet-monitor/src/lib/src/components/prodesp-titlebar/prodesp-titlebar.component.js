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
var router_1 = require("@angular/router");
var ProdespTitlebarComponent = (function () {
    function ProdespTitlebarComponent(route, activatedRoute) {
        this.route = route;
        this.activatedRoute = activatedRoute;
    }
    ProdespTitlebarComponent.prototype.ngOnInit = function () {
        this.title = this.activatedRoute.snapshot.data['title'];
    };
    return ProdespTitlebarComponent;
}());
ProdespTitlebarComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-titlebar',
        templateUrl: './prodesp-titlebar.component.html',
        styleUrls: ['./prodesp-titlebar.component.css']
    }),
    __metadata("design:paramtypes", [router_1.Router, router_1.ActivatedRoute])
], ProdespTitlebarComponent);
exports.ProdespTitlebarComponent = ProdespTitlebarComponent;
//# sourceMappingURL=prodesp-titlebar.component.js.map