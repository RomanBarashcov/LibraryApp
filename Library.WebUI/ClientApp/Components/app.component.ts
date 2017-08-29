import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'my-app',
    templateUrl: 'ClientApp/Components/Views/app.component.html',
    styleUrls: ['ClientApp/Components/Style/appStyle.css']
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