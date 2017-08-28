import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'my-app',
    template: `<div>
                 <p>
                    <a routerLink="/authors">All Authors</a> <a routerLink="/books">All Books</a> <a routerLink="/connectionString">Chose Db</a>
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