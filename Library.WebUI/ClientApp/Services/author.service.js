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
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var AuthorService = (function () {
    function AuthorService(http) {
        this.http = http;
        this.url = "http://localhost:1483/AuthorApi";
    }
    AuthorService_1 = AuthorService;
    AuthorService.prototype.getAuthors = function () {
        return this.http.get(this.url)
            .map(function (resp) {
            var authorList = resp.json();
            var authors = [];
            console.log(authorList);
            for (var index in authorList) {
                console.log(authorList[index]);
                var author = authorList[index];
                authors.push({ id: author.Id, name: author.Name, surname: author.Surname });
            }
            return authors;
        }).catch(function (error) { return Observable_1.Observable.throw(error); });
    };
    AuthorService.prototype.createAuthor = function (obj) {
        var body = JSON.stringify(obj);
        console.log(body);
        var headers = new http_2.Headers({ 'Content-Type': 'application/json;charser=utf8' });
        return this.http.post(this.url, body, { headers: headers })
            .map(function (res) { return AuthorService_1.json(res); })
            .catch(this.handleError);
    };
    AuthorService.prototype.updateAuthor = function (id, obj) {
        var headers = new http_2.Headers({ 'Content-Type': 'application/json;charser=utf8' });
        var body = JSON.stringify(obj);
        return this.http.put(this.url + '/' + id, body, { headers: headers })
            .map(function (res) { return AuthorService_1.json(res); })
            .catch(this.handleError);
    };
    AuthorService.prototype.deleteUser = function (id) {
        return this.http.delete(this.url + '/' + id)
            .map(function (res) { return AuthorService_1.json(res); })
            .catch(this.handleError);
    };
    AuthorService.json = function (res) {
        return res.text() === "" ? res : res.json();
    };
    AuthorService.prototype.handleError = function (error) {
        console.error(error);
        return Observable_1.Observable.throw(error);
    };
    AuthorService = AuthorService_1 = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], AuthorService);
    return AuthorService;
    var AuthorService_1;
}());
exports.AuthorService = AuthorService;
//# sourceMappingURL=author.service.js.map