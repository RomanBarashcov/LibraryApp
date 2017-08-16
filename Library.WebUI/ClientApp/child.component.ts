import { Input, Output, EventEmitter, Component } from '@angular/core';

@Component({
    selector: 'child-comp',
    template: `<h1 [ngClass]="{ red:true }"> Ваше Имя {{userName}}</h1>
               <h2 [ngClass]="{ red:false, silver:true }">Ваш возраст {{userAge}} </h2>
               <button (click)="change(true)"> + </button>
               <button (click)="change(false)"> - </button>`,
    styles: [`.red{ font-size:13px; color:red; }
              .silver{ font-size:14; color:silver; }`
            ]
})
export class ChildComponent {
    @Input() userName: string;
    _userAge: number;

    @Input()
    set userAge(age: number) {
        if (age < 0)
            this._userAge = 0;
        else if (age > 100)
            this._userAge = 100;
        else
            this._userAge = age;
    }

    get userAge() { return this._userAge; }

    @Output() onChanged = new EventEmitter<boolean>();
    change(increased:boolean) {
        this.onChanged.emit(increased);
    }   
}