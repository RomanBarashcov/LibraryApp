import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'my-app',
    template: `<div>
                 <p>
                    <a routerLink="/authors">Все Авторы</a> <a routerLink="/books">Все Книги</a>
                 </p>
                    <router-outlet></router-outlet>
                </div>`,
})
export class AppComponent implements OnDestroy {

    private sub: Subscription;
    constructor(private activatedRoute: ActivatedRoute) {
        this.sub = activatedRoute.params.subscribe();
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}