import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Response, Headers } from '@angular/http';
import { Book } from '../Models/book';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class BookService {

    private url = "http://localhost:1483/BookApi";

    constructor(private http: Http) { }

    getBooks(): Observable<Book[]> {
        return this.http.get(this.url)
            .map((resp: Response) => {

                let bookList = resp.json();
                let books: Book[] = [];
                for (let index in bookList) {
                    console.log(bookList[index]);
                    let book = bookList[index];
                    books.push({ id: book.Id, year: book.Year, name: book.Name, description: book.Description, authorId: book.AuthorId });
                }
                return books;

            });
    }

    getBookByAuthorId(id: string): Observable<Book[]> {

        return this.http.get(this.url + '/GetBookByAuthorId/' + id).map((resp: Response) => {

            let bookList = resp.json();
            let books: Book[] = [];

            for (let index in bookList) {
                    let book = bookList[index];
                    console.log(bookList[index])
                    books.push({ id: book.Id, year: book.Year, name: book.Name, description: book.Description, authorId: book.AuthorId });
                }
            return books;
        });
    }
        createBook(obj: Book) {
            const body = JSON.stringify(obj);
            let headers = new Headers({ 'Content-Type': 'application/json;charser=utf8' });
            return this.http.post(this.url, body, { headers: headers });
        }

        updateBook(id: string, obj: Book) {
            let headers = new Headers({ 'Content-Type': 'application/json;charser=utf8' });
            const body = JSON.stringify(obj);
            return this.http.put(this.url + '/' + id, body, { headers: headers });
        }

        deleteBook(id: string) {
            return this.http.delete(this.url + '/' + id);
        }
    }