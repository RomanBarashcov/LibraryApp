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
var AuthorService = (function () {
    function AuthorService(http) {
        this.http = http;
        this.url = "http://localhost:1483/AuthorApi";
    }
    AuthorService.prototype.getAuthors = function () {
        return this.http.get(this.url)
            .map(function (resp) {
            var authorList = resp.json();
            console.log(authorList);
            var authors = [];
            for (var index in authorList) {
                console.log(authorList[index]);
                var author = authorList[index];
                authors.push({ id: author.Id, name: author.Name, surname: author.Surname });
            }
            return authors;
        });
    };
    AuthorService.prototype.createAuthor = function (obj) {
        var body = JSON.stringify(obj);
        console.log(body);
        var headers = new http_2.Headers({ 'Content-Type': 'application/json;charser=utf8' });
        return this.http.post(this.url, body, { headers: headers });
    };
    AuthorService.prototype.updateAuthor = function (id, obj) {
        var headers = new http_2.Headers({ 'Content-Type': 'application/json;charser=utf8' });
        var body = JSON.stringify(obj);
        return this.http.put(this.url + '/' + id, body, { headers: headers });
    };
    AuthorService.prototype.deleteUser = function (id) {
        return this.http.delete(this.url + '/' + id);
    };
    AuthorService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], AuthorService);
    return AuthorService;
}());
exports.AuthorService = AuthorService;
//# sourceMappingURL=author.service.js.map