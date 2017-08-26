import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Response, Headers } from '@angular/http';
import { СonnectionString } from '../Models/connectionString';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';


@Injectable()
export class connectionStringService {

    private url = "http://localhost:1483/ConnectionApi";

    constructor(private http: Http) { }

    sendConnectionString(obj: СonnectionString) {
        console.log(obj);
        let headers = new Headers({ 'Content-Type': 'application/json;charser=utf8' });
        const body = JSON.stringify(obj);
        return this.http.post(this.url, body, { headers: headers }).catch((error: any) => { return Observable.throw(error); });
    }
}