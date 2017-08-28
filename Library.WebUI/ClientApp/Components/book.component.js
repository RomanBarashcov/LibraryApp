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
var book_service_1 = require("../Services/book.service");
var book_1 = require("../Models/book");
require("rxjs/Rx");
var pagination_service_1 = require("../Services/pagination.service");
var BookComponent = (function () {
    function BookComponent(serv, activateRoute, pagerService) {
        var _this = this;
        this.serv = serv;
        this.activateRoute = activateRoute;
        this.pagerService = pagerService;
        this.books = [];
        this.pager = {};
        this.sub = activateRoute.params.subscribe(function (params) { params['id'] != null ? _this.loadBookByAuthor(params['id']) : _this.loadBooks(); });
    }
    BookComponent.prototype.loadBooks = function () {
        var _this = this;
        this.serv.getBooks().subscribe(function (data) {
            _this.books = data,
                _this.setPage(1);
        });
    };
    BookComponent.prototype.loadBookByAuthor = function (id) {
        var _this = this;
        this.serv.getBookByAuthorId(id).subscribe(function (data) {
            _this.books = data;
            _this.setPage(1);
            _this.hiddenAuthorId = id;
        });
    };
    BookComponent.prototype.addBook = function (authorId) {
        this.editedBook = new book_1.Book("", 0, "", "", authorId);
        this.books.push(this.editedBook);
        this.isNewRecord = true;
        this.setPage(this.pager.totalPages);
    };
    BookComponent.prototype.editBook = function (book) {
        this.editedBook = new book_1.Book(book.id, book.year, book.name, book.description, book.authorId);
    };
    BookComponent.prototype.loadTemplate = function (book) {
        if (this.editedBook && this.editedBook.id == book.id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    };
    BookComponent.prototype.saveBook = function () {
        var _this = this;
        if (this.isNewRecord) {
            this.serv.createBook(this.editedBook).subscribe(function (resp) {
                if (resp.ok) {
                    _this.statusMessage = 'Saved successfully!';
                    _this.loadBooks();
                }
            });
            this.isNewRecord = false;
            this.editedBook = null;
        }
        else {
            this.serv.updateBook(this.editedBook.id, this.editedBook).subscribe(function (resp) {
                if (resp.ok) {
                    _this.statusMessage = 'Updated successfully!';
                    _this.loadBooks();
                }
            });
            this.editedBook = null;
        }
    };
    BookComponent.prototype.cancel = function () {
        this.editedBook = null;
    };
    BookComponent.prototype.deleteBook = function (book) {
        var _this = this;
        this.serv.deleteBook(book.id).subscribe(function (resp) {
            if (resp.ok) {
                _this.statusMessage = 'Deleted successfully!',
                    _this.loadBooks();
            }
        });
    };
    BookComponent.prototype.setPage = function (page) {
        if (page < 1 || page > this.pager.totalPages) {
            return;
        }
        // get pager object from service
        this.pager = this.pagerService.getPager(this.books.length, page);
        // get current page of items
        this.pagedBookItems = this.books.slice(this.pager.startIndex, this.pager.endIndex + 1);
    };
    BookComponent.prototype.ngOnDestroy = function () {
        this.sub.unsubscribe();
    };
    __decorate([
        core_1.ViewChild('readOnlyTemplate'),
        __metadata("design:type", core_1.TemplateRef)
    ], BookComponent.prototype, "readOnlyTemplate", void 0);
    __decorate([
        core_1.ViewChild('editTemplate'),
        __metadata("design:type", core_1.TemplateRef)
    ], BookComponent.prototype, "editTemplate", void 0);
    BookComponent = __decorate([
        core_2.Component({
            selector: 'books-app',
            templateUrl: 'ClientApp/Components/Views/book.component.html',
            providers: [book_service_1.BookService]
        }),
        __metadata("design:paramtypes", [book_service_1.BookService, router_1.ActivatedRoute, pagination_service_1.PagerService])
    ], BookComponent);
    return BookComponent;
}());
exports.BookComponent = BookComponent;
//# sourceMappingURL=book.component.js.map