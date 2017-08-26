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
var http_1 = require("@angular/http");
var http_2 = require("@angular/http");
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var connectionStringService = (function () {
    function connectionStringService(http) {
        this.http = http;
        this.url = "http://localhost:1483/ConnectionApi";
    }
    connectionStringService.prototype.sendConnectionString = function (obj) {
        console.log(obj);
        var headers = new http_2.Headers({ 'Content-Type': 'application/json;charser=utf8' });
        var body = JSON.stringify(obj);
        return this.http.post(this.url, body, { headers: headers }).catch(function (error) { return Observable_1.Observable.throw(error); });
    };
    connectionStringService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], connectionStringService);
    return connectionStringService;
}());
exports.connectionStringService = connectionStringService;
//# sourceMappingURL=connectionString.service.js.map