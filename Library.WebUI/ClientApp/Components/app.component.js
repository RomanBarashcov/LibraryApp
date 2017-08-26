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
var AppComponent = (function () {
    function AppComponent(activatedRoute) {
        this.activatedRoute = activatedRoute;
        this.sub = activatedRoute.params.subscribe();
    }
    AppComponent.prototype.ngOnDestroy = function () {
        this.sub.unsubscribe();
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            template: "<div>\n                 <p>\n                    <a routerLink=\"/authors\">\u0412\u0441\u0435 \u0410\u0432\u0442\u043E\u0440\u044B</a> <a routerLink=\"/books\">\u0412\u0441\u0435 \u041A\u043D\u0438\u0433\u0438</a> <a routerLink=\"/connectionString\">\u0412\u044B\u0431\u043E\u0440 \u0411\u0434</a>\n                 </p>\n                    <router-outlet></router-outlet>\n                </div>",
        }),
        __metadata("design:paramtypes", [router_1.ActivatedRoute])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map