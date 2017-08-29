import { Component, OnDestroy } from '@angular/core';
import { СonnectionString } from '../Models/connectionString';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { connectionStringService } from '../Services/connectionString.service';

@Component({
    selector: 'chose-connection-string',
    templateUrl: 'ClientApp/Components/Views/connectionString.component.html',
    styleUrls: ['ClientApp/Components/Style/appStyle.css'],
    providers: [connectionStringService]
})

export class ConnectionStringComponent implements OnDestroy {

    private sub: Subscription;
    DefaultConnection: string = "DefaultConnection";
    MongoDbConnection: string = "MongoDbConnection";
    conStringDb: СonnectionString;
    error: any;
    chosedDb: string;

    constructor(private serv: connectionStringService, private activatedRoute: ActivatedRoute, private router: Router) {
        this.sub = activatedRoute.params.subscribe();
    }

    choseDb(conString: string) {
        this.conStringDb = new СonnectionString(conString);
        this.serv.sendConnectionString(this.conStringDb).subscribe(error => { this.error = error; console.log(error); });
        if (this.error == null) {
            this.chosedDb = " Chosed " + conString + " Db successful! You can chose any tab!";
        }
    }

    redirectToAuthors() {
        this.router.navigate(['']);
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}