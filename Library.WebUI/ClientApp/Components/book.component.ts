import { TemplateRef, ViewChild } from '@angular/core';
import { Component, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Response } from '@angular/http';
import { Subscription } from 'rxjs/Subscription';
import { BookService } from '../Services/book.service';
import { Book } from '../Models/book';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';

@Component({
    selector: 'books-app',
    templateUrl: 'ClientApp/Components/Views/book.component.html',
    providers: [BookService]
})
export class BookComponent implements OnDestroy {

    @ViewChild('readOnlyTemplate') readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate') editTemplate: TemplateRef<any>;

    books: Book[]=[];
    editedBook: Book;
    isNewRecord: boolean;
    statusMessage: string;
    hiddenAuthorId: number;
    private sub: Subscription;
    private id: number;

    constructor(private serv: BookService, private activateRoute: ActivatedRoute) {
        this.sub = activateRoute.params.subscribe((params) => { params['id'] != null ? this.loadBookByAuthor(params['id']) : this.loadBooks() });
    }

    loadBooks() {
        this.serv.getBooks().subscribe((data) => 
            this.books = data);
    }

    loadBookByAuthor(id: number) {
        this.serv.getBookByAuthorId(id).subscribe((data) =>
            this.books = data);
        this.hiddenAuthorId = id;
    }

    addBook(authorId: number) {
        this.editedBook = new Book(0, 0, "", "", authorId);
        this.books.push(this.editedBook);
        this.isNewRecord = true;
    }

    editBook(book: Book) {
        this.editedBook = new Book(book.id, book.year, book.name, book.description, book.authorId);
    }

    loadTemplate(book: Book) {
        if (this.editedBook && this.editedBook.id == book.id) {
            return this.editTemplate;
        } else {
            return this.readOnlyTemplate;
        }
    }

    saveBook() {
        if (this.isNewRecord) {
            this.serv.createBook(this.editedBook).subscribe((resp: Response) => {
                this.statusMessage = 'Данные сохранены успешно';
                this.loadBooks();
            });
            this.isNewRecord = false;
            this.editedBook = null;
        } else {
            this.serv.updateBook(this.editedBook.id, this.editedBook).subscribe((resp: Response) => {
                this.statusMessage = 'Данные успешно обновлены';
                this.loadBooks();
            });
            this.editedBook = null;
        }
    }

    cancel() {
        this.editedBook = null;
    }

    deleteBook(book: Book) {
        this.serv.deleteBook(book.id).subscribe((resp: Response) => {
            this.statusMessage = 'Данные успешно удалены',
                this.loadBooks();
        });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

}