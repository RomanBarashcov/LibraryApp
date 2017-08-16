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
var ChildComponent = (function () {
    function ChildComponent() {
        this.onChanged = new core_1.EventEmitter();
    }
    Object.defineProperty(ChildComponent.prototype, "userAge", {
        get: function () { return this._userAge; },
        set: function (age) {
            if (age < 0)
                this._userAge = 0;
            else if (age > 100)
                this._userAge = 100;
            else
                this._userAge = age;
        },
        enumerable: true,
        configurable: true
    });
    ChildComponent.prototype.change = function (increased) {
        this.onChanged.emit(increased);
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], ChildComponent.prototype, "userName", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Number),
        __metadata("design:paramtypes", [Number])
    ], ChildComponent.prototype, "userAge", null);
    __decorate([
        core_1.Output(),
        __metadata("design:type", Object)
    ], ChildComponent.prototype, "onChanged", void 0);
    ChildComponent = __decorate([
        core_1.Component({
            selector: 'child-comp',
            template: "<h1 [ngClass]=\"{ red:true }\"> \u0412\u0430\u0448\u0435 \u0418\u043C\u044F {{userName}}</h1>\n               <h2 [ngClass]=\"{ red:false, silver:true }\">\u0412\u0430\u0448 \u0432\u043E\u0437\u0440\u0430\u0441\u0442 {{userAge}} </h2>\n               <button (click)=\"change(true)\"> + </button>\n               <button (click)=\"change(false)\"> - </button>",
            styles: [".red{ font-size:13px; color:red; }\n              .silver{ font-size:14; color:silver; }"
            ]
        })
    ], ChildComponent);
    return ChildComponent;
}());
exports.ChildComponent = ChildComponent;
//# sourceMappingURL=child.component.js.map