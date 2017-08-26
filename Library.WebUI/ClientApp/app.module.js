"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var router_1 = require("@angular/router");
var http_1 = require("@angular/http");
var app_component_1 = require("./Components/app.component");
var author_component_1 = require("./Components/author.component");
var book_component_1 = require("./Components/book.component");
var connectionString_component_1 = require("./Components/connectionString.component");
var not_found_component_1 = require("./Components/not-found.component");
var appRoutes = [
    { path: '', component: app_component_1.AppComponent },
    { path: 'authors', component: author_component_1.AuthorComponent },
    { path: 'books', component: book_component_1.BookComponent },
    { path: 'booksByAuthor/:id', component: book_component_1.BookComponent },
    { path: 'connectionString', component: connectionString_component_1.ConnectionStringComponent },
    { path: '**', component: not_found_component_1.NotFoundComponent }
];
var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [platform_browser_1.BrowserModule, forms_1.FormsModule, http_1.HttpModule, router_1.RouterModule.forRoot(appRoutes)],
            declarations: [app_component_1.AppComponent, author_component_1.AuthorComponent, book_component_1.BookComponent, connectionString_component_1.ConnectionStringComponent, not_found_component_1.NotFoundComponent],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map