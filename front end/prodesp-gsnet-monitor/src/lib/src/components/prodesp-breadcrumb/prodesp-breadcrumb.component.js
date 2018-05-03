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
require("rxjs/add/operator/filter");
var ProdespBreadcrumbComponent = (function () {
    function ProdespBreadcrumbComponent(activatedRoute, router) {
        this.activatedRoute = activatedRoute;
        this.router = router;
        this.breadcrumbs = [];
    }
    ProdespBreadcrumbComponent.prototype.ngOnInit = function () {
        var _this = this;
        var ROUTE_DATA_BREADCRUMB = 'breadcrumb';
        this.router.events.filter(function (event) { return event instanceof router_1.NavigationEnd; }).subscribe(function (event) {
            var root = _this.activatedRoute.root;
            _this.breadcrumbs = _this.getBreadcrumbs(root);
        });
    };
    ProdespBreadcrumbComponent.prototype.getBreadcrumbs = function (route, url, breadcrumbs) {
        if (url === void 0) { url = ''; }
        if (breadcrumbs === void 0) { breadcrumbs = []; }
        var ROUTE_DATA_BREADCRUMB = 'breadcrumb';
        var ROUTE_DATA_BREADCRUMB_ICON = 'icon';
        var children = route.children;
        if (children.length === 0) {
            return breadcrumbs;
        }
        for (var _i = 0, children_1 = children; _i < children_1.length; _i++) {
            var child = children_1[_i];
            if (child.outlet !== router_1.PRIMARY_OUTLET) {
                continue;
            }
            if (!child.snapshot.data.hasOwnProperty(ROUTE_DATA_BREADCRUMB)) {
                return this.getBreadcrumbs(child, url, breadcrumbs);
            }
            var routeURL = child.snapshot.url.map(function (segment) { return segment.path; }).join('/');
            url += "/" + routeURL;
            var breadcrumb = {
                label: child.snapshot.data[ROUTE_DATA_BREADCRUMB],
                icon: child.snapshot.data[ROUTE_DATA_BREADCRUMB_ICON],
                params: child.snapshot.params,
                url: url
            };
            breadcrumbs.push(breadcrumb);
            return this.getBreadcrumbs(child, url, breadcrumbs);
        }
        return breadcrumbs;
    };
    return ProdespBreadcrumbComponent;
}());
ProdespBreadcrumbComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-breadcrumb',
        templateUrl: './prodesp-breadcrumb.component.html'
    }),
    __metadata("design:paramtypes", [router_1.ActivatedRoute,
        router_1.Router])
], ProdespBreadcrumbComponent);
exports.ProdespBreadcrumbComponent = ProdespBreadcrumbComponent;
//# sourceMappingURL=prodesp-breadcrumb.component.js.map