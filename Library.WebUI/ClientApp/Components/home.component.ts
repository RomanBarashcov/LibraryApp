import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'home-component',
    template: ``,
})
export class HomeComponent implements OnDestroy {

    private sub: Subscription;
    constructor(private activatedRoute: ActivatedRoute) {
        this.sub = activatedRoute.params.subscribe();
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}