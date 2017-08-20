import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Response, Headers } from '@angular/http';
import { Author } from '../Models/author';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AuthorService {

    private url = "http://localhost:1483/AuthorApi";

    constructor(private http: Http) { }

    getAuthors(): Observable<Author[]> {
        return this.http.get(this.url)
                .map((resp: Response) => {

                    let authorList = resp.json();
                    console.log(authorList);
                    let authors: Author[] = [];

                    for (let index in authorList) {
                        console.log(authorList[index]);
                        let author = authorList[index];
                        authors.push({ id: author.Id, name: author.Name, surname: author.Surname });
                    }
                    return authors;
        });
    }

    createAuthor(obj: Author) {
        const body = JSON.stringify(obj);
        console.log(body);
        let headers = new Headers({ 'Content-Type': 'application/json;charser=utf8' });
        return this.http.post(this.url, body, { headers: headers });
    }

    updateAuthor(id: number, obj: Author) {
        let headers = new Headers({ 'Content-Type': 'application/json;charser=utf8' });
        const body = JSON.stringify(obj);
        return this.http.put(this.url + '/' + id, body, { headers: headers });
    }

    deleteUser(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}