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
Object.defineProperty(exports, "__esModule", { value: true });
var ng2_bootstrap_modal_1 = require("ng2-bootstrap-modal");
var ModalComponent = (function (_super) {
    __extends(ModalComponent, _super);
    function ModalComponent(dialogService) {
        return _super.call(this, dialogService) || this;
    }
    ModalComponent.prototype.confirm = function (data) {
        console.log('Modal abstract component confirmed');
        this.result = data;
        this.close();
    };
    ModalComponent.prototype.closeModal = function () {
        console.log('Modal abstract component closed');
        this.close();
    };
    return ModalComponent;
}(ng2_bootstrap_modal_1.DialogComponent));
exports.ModalComponent = ModalComponent;
//# sourceMappingURL=modal.component.model.js.map