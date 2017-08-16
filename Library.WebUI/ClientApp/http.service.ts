import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Response } from '@angular/http';
import { Author } from './author';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class HttpService {

    constructor(private http: Http) { }

    getAuthors(): Observable<Author[]> {

        return this.http.get('http://localhost:1483/AuthorApi')
            .map((resp: Response) => {

                let authorList = resp.json();
                let authors: Author[] = [];
                for (let index in authorList) {
                    console.log(authorList[index]);
                    let author = authorList[index];
                    authors.push({ id: author.Id, firstName: author.Name, surName: author.Surname });
                }
                return authors;
            }).catch((error: any) => { return Observable.throw(error); });
    }
}