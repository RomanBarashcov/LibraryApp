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
var connectionString_1 = require("../Models/connectionString");
var router_1 = require("@angular/router");
var connectionString_service_1 = require("../Services/connectionString.service");
var ConnectionStringComponent = (function () {
    function ConnectionStringComponent(serv, activatedRoute, router) {
        this.serv = serv;
        this.activatedRoute = activatedRoute;
        this.router = router;
        this.DefaultConnection = "DefaultConnection";
        this.MongoDbConnection = "MongoDbConnection";
        this.sub = activatedRoute.params.subscribe();
    }
    ConnectionStringComponent.prototype.choseDb = function (conString) {
        var _this = this;
        this.conStringDb = new connectionString_1.СonnectionString(conString);
        this.serv.sendConnectionString(this.conStringDb).subscribe(function (error) { _this.error = error; console.log(error); });
        if (this.error == null) {
            this.chosedDb = " Chosed " + conString + " Db successful! You can chose any tab!";
        }
    };
    ConnectionStringComponent.prototype.redirectToAuthors = function () {
        this.router.navigate(['']);
    };
    ConnectionStringComponent.prototype.ngOnDestroy = function () {
        this.sub.unsubscribe();
    };
    ConnectionStringComponent = __decorate([
        core_1.Component({
            selector: 'chose-connection-string',
            templateUrl: 'ClientApp/Components/Views/connectionString.component.html',
            styleUrls: ['ClientApp/Components/Style/appStyle.css'],
            providers: [connectionString_service_1.connectionStringService]
        }),
        __metadata("design:paramtypes", [connectionString_service_1.connectionStringService, router_1.ActivatedRoute, router_1.Router])
    ], ConnectionStringComponent);
    return ConnectionStringComponent;
}());
exports.ConnectionStringComponent = ConnectionStringComponent;
//# sourceMappingURL=connectionString.component.js.map