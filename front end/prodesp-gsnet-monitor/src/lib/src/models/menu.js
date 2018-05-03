"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Menu = (function () {
    function Menu(link, icon, descricao, subMenus, isOpen) {
        if (subMenus === void 0) { subMenus = []; }
        if (isOpen === void 0) { isOpen = false; }
        this.link = link;
        this.icon = icon;
        this.descricao = descricao;
        this.subMenus = subMenus;
        this.isOpen = isOpen;
    }
    return Menu;
}());
exports.Menu = Menu;
//# sourceMappingURL=menu.js.map