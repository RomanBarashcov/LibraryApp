import { TemplateRef, ViewChild } from '@angular/core';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Response } from '@angular/http';
import { Subscription } from 'rxjs/Subscription';
import { AuthorService } from '../Services/author.service';
import { Author } from '../Models/author';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import * as _ from 'underscore';
import { PagerService } from '../Services/pagination.service';

@Component({
    selector: 'authors-app',
    templateUrl: 'ClientApp/Components/Views/author.component.html',
    styleUrls: ['ClientApp/Components/Style/appStyle.css'],
    providers: [AuthorService]
})
export class AuthorComponent implements OnDestroy, OnInit {

    @ViewChild('readOnlyTemplate') readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate') editTemplate: TemplateRef<any>;

    authors: Author[] = [];
    editedAuthor: Author;
    isNewRecord: boolean;
    statusMessage: string;
    private sub: Subscription;
    private allItems: any[];
    pagedAuthorItems: any[];
    pager: any = {};

    constructor(private serv: AuthorService, private router: Router, private activateRoute: ActivatedRoute, private pagerService: PagerService) {
        this.sub = activateRoute.params.subscribe();
    }

    ngOnInit() {
        this.serv.getAuthors().subscribe((data) => {
            this.authors = data;
            this.setPage(1);
        });
    }

    addAuthor() {
        this.editedAuthor = new Author("", "", "");
        this.authors.push(this.editedAuthor);
        this.pagedAuthorItems = this.authors;
        this.isNewRecord = true;
        if (this.pager.totalPages > 0) {
            this.setPage(this.pager.totalPages);
        }
    }

    editAuthor(author: Author) {
        this.editedAuthor = new Author(author.id, author.name, author.surname);
    }

    loadTemplate(author: Author) {
        if (this.editedAuthor && this.editedAuthor.id == author.id) {
            return this.editTemplate;
        } else {
            return this.readOnlyTemplate;
        }
    }

    saveAuthor() {
        if (this.isNewRecord) {
            this.serv.createAuthor(this.editedAuthor).subscribe((resp: Response) => {
                if (resp.ok) {
                    this.statusMessage = 'Saved successfully!';
                    this.ngOnInit();
                }
            });
            this.isNewRecord = false;
            this.editedAuthor = null;
        } else {
            this.serv.updateAuthor(this.editedAuthor.id, this.editedAuthor).subscribe((resp: Response) => {
                if (resp.ok) {
                    this.statusMessage = 'Updated successfully!';
                    this.ngOnInit();
                }
            });
            this.editedAuthor = null;
        }
    }

    cancel() {
        this.editedAuthor = null;
    }

    deleteAuthor(author: Author) {
        this.serv.deleteUser(author.id).subscribe((resp: Response) => {
            if (resp.ok) {
                this.statusMessage = 'Deleted successfully!',
                    this.ngOnInit();
            }
        });
    }

    routeToBooks(author: Author) {
        this.router.navigate(['/booksByAuthor', author.id]);
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    setPage(page: number) {
        if (page < 1 || page > this.pager.totalPages) {
            return;
        }
        // get pager object from service
        this.pager = this.pagerService.getPager(this.authors.length, page);

        // get current page of items
        this.pagedAuthorItems = this.authors.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
}