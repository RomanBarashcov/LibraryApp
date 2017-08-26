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
var core_2 = require("@angular/core");
var router_1 = require("@angular/router");
var author_service_1 = require("../Services/author.service");
var author_1 = require("../Models/author");
require("rxjs/Rx");
var AuthorComponent = (function () {
    function AuthorComponent(serv, router, activateRoute) {
        this.serv = serv;
        this.router = router;
        this.activateRoute = activateRoute;
        this.authors = [];
        this.sub = activateRoute.params.subscribe();
        this.loadAuthors();
    }
    AuthorComponent.prototype.loadAuthors = function () {
        var _this = this;
        this.serv.getAuthors().subscribe(function (data) {
            return _this.authors = data;
        });
        console.log("method loadBook in bookComponent" + this.authors);
    };
    AuthorComponent.prototype.addAuthor = function () {
        this.editedAuthor = new author_1.Author("", "", "");
        this.authors.push(this.editedAuthor);
        this.isNewRecord = true;
    };
    AuthorComponent.prototype.editAuthor = function (author) {
        this.editedAuthor = new author_1.Author(author.id, author.name, author.surname);
    };
    AuthorComponent.prototype.loadTemplate = function (author) {
        if (this.editedAuthor && this.editedAuthor.id == author.id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    };
    AuthorComponent.prototype.saveAuthor = function () {
        var _this = this;
        if (this.isNewRecord) {
            this.serv.createAuthor(this.editedAuthor).subscribe(function (resp) {
                _this.statusMessage = 'Данные сохранены успешно';
                _this.loadAuthors();
            });
            this.isNewRecord = false;
            this.editedAuthor = null;
        }
        else {
            this.serv.updateAuthor(this.editedAuthor.id, this.editedAuthor).subscribe(function (resp) {
                _this.statusMessage = 'Данные успешно обновлены';
                _this.loadAuthors();
            });
            this.editedAuthor = null;
        }
    };
    AuthorComponent.prototype.cancel = function () {
        this.editedAuthor = null;
    };
    AuthorComponent.prototype.deleteAuthor = function (author) {
        var _this = this;
        this.serv.deleteUser(author.id).subscribe(function (resp) {
            _this.statusMessage = 'Данные успешно удалены',
                _this.loadAuthors();
        });
    };
    AuthorComponent.prototype.routeToBooks = function (author) {
        this.router.navigate(['/booksByAuthor', author.id]);
    };
    AuthorComponent.prototype.ngOnDestroy = function () {
        this.sub.unsubscribe();
    };
    __decorate([
        core_1.ViewChild('readOnlyTemplate'),
        __metadata("design:type", core_1.TemplateRef)
    ], AuthorComponent.prototype, "readOnlyTemplate", void 0);
    __decorate([
        core_1.ViewChild('editTemplate'),
        __metadata("design:type", core_1.TemplateRef)
    ], AuthorComponent.prototype, "editTemplate", void 0);
    AuthorComponent = __decorate([
        core_2.Component({
            selector: 'authors-app',
            templateUrl: 'ClientApp/Components/Views/author.component.html',
            providers: [author_service_1.AuthorService]
        }),
        __metadata("design:paramtypes", [author_service_1.AuthorService, router_1.Router, router_1.ActivatedRoute])
    ], AuthorComponent);
    return AuthorComponent;
}());
exports.AuthorComponent = AuthorComponent;
//# sourceMappingURL=author.component.js.map