"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var modal_component_model_1 = require("../../models/modal.component.model");
var dialog_service_1 = require("ng2-bootstrap-modal/dist/dialog.service");
var ProdespMonitorModalConfirmComponent = (function (_super) {
    __extends(ProdespMonitorModalConfirmComponent, _super);
    function ProdespMonitorModalConfirmComponent(dialogService) {
        return _super.call(this, dialogService) || this;
    }
    ProdespMonitorModalConfirmComponent.prototype.ngOnInit = function () {
    };
    ProdespMonitorModalConfirmComponent.prototype.confirm = function (data) {
        this.result = true;
        this.close();
    };
    return ProdespMonitorModalConfirmComponent;
}(modal_component_model_1.ModalComponent));
ProdespMonitorModalConfirmComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-monitor-modal-confirm',
        templateUrl: './prodesp-monitor-modal-confirm.component.html',
        styleUrls: ['./prodesp-monitor-modal-confirm.component.css']
    }),
    __metadata("design:paramtypes", [dialog_service_1.DialogService])
], ProdespMonitorModalConfirmComponent);
exports.ProdespMonitorModalConfirmComponent = ProdespMonitorModalConfirmComponent;
//# sourceMappingURL=prodesp-monitor-modal-confirm.component.js.map