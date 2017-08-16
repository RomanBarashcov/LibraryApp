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
var http_service_1 = require("./http.service");
var AppComponent = (function () {
    function AppComponent(httpService) {
        this.httpService = httpService;
        this.authors = [];
    }
    AppComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.httpService.getAuthors()
            .subscribe(function (data) { return _this.authors = data; }, function (error) { _this.error = error; console.log(error); });
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            template: "<div> \n                    <ul>\n                      <li *ngFor=\"let author of authors\">\n                         <input type=\"hidden\" value=\"{{author?.id}}\" />\n                         <p>\u0410\u0432\u0442\u043E\u0440: {{author?.firstName}}  {{author?.serName}}</p>\n                      </li>\n                    </ul>\n                <div>{{error}}</div>\n               </div>",
            providers: [http_service_1.HttpService]
        }),
        __metadata("design:paramtypes", [http_service_1.HttpService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map