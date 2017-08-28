import { TemplateRef, ViewChild } from '@angular/core';
import { Component, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Response } from '@angular/http';
import { Subscription } from 'rxjs/Subscription';
import { BookService } from '../Services/book.service';
import { Book } from '../Models/book';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import * as _ from 'underscore';
import { PagerService } from '../Services/pagination.service';

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
    hiddenAuthorId: string;
    private sub: Subscription;
    private id: number;
    private allItems: any[];
    pagedBookItems: any[];
    pager: any = {};

    constructor(private serv: BookService, private activateRoute: ActivatedRoute, private pagerService: PagerService) {
        this.sub = activateRoute.params.subscribe((params) => { params['id'] != null ? this.loadBookByAuthor(params['id']) : this.loadBooks() });
    }

    loadBooks() {
        this.serv.getBooks().subscribe((data) => {
            this.books = data,
            this.setPage(1)
        });
    }

    loadBookByAuthor(id: string) {
        this.serv.getBookByAuthorId(id).subscribe((data) => {
            this.books = data
            this.setPage(1);
            this.hiddenAuthorId = id;
        });
    }

    addBook(authorId: string) {
        this.editedBook = new Book("", 0, "", "", authorId);
        this.books.push(this.editedBook);
        this.isNewRecord = true;
        this.setPage(this.pager.totalPages);
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
                if (resp.ok) {
                    this.statusMessage = 'Saved successfully!';
                    this.loadBooks();
                }
            });
            this.isNewRecord = false;
            this.editedBook = null;
        } else {
            this.serv.updateBook(this.editedBook.id, this.editedBook).subscribe((resp: Response) => {
                if (resp.ok) {
                    this.statusMessage = 'Updated successfully!';
                    this.loadBooks();
                }
            });
            this.editedBook = null;
        }
    }

    cancel() {
        this.editedBook = null;
    }

    deleteBook(book: Book) {
        this.serv.deleteBook(book.id).subscribe((resp: Response) => {
            if (resp.ok) {
                this.statusMessage = 'Deleted successfully!',
                    this.loadBooks();
            }
        });
    }

    setPage(page: number) {
        if (page < 1 || page > this.pager.totalPages) {
            return;
        }

        // get pager object from service
        this.pager = this.pagerService.getPager(this.books.length, page);

        // get current page of items
        this.pagedBookItems = this.books.slice(this.pager.startIndex, this.pager.endIndex + 1);

    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

}