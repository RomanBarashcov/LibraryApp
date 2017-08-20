import { TemplateRef, ViewChild } from '@angular/core';
import { Component, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Response } from '@angular/http';
import { Subscription } from 'rxjs/Subscription';
import { AuthorService } from '../Services/author.service';
import { Author } from '../Models/author';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';


@Component({
    selector: 'authors-app',
    templateUrl: 'ClientApp/Components/Views/author.component.html',
    providers: [AuthorService]
})
export class AuthorComponent implements OnDestroy {

    @ViewChild('readOnlyTemplate') readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate') editTemplate: TemplateRef<any>;

    authors: Author[] = [];
    editedAuthor: Author;
    isNewRecord: boolean;
    statusMessage: string;
    private sub: Subscription;

    constructor(private serv: AuthorService, private router: Router, private activateRoute: ActivatedRoute) {
        this.sub = activateRoute.params.subscribe();
        this.loadAuthors();
    }

    loadAuthors() {
        this.serv.getAuthors().subscribe((data) => 
            this.authors = data
        );
    }

    addAuthor() {
        this.editedAuthor = new Author(0, "", "");
        this.authors.push(this.editedAuthor);
        this.isNewRecord = true;
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
                this.statusMessage = 'Данные сохранены успешно';
                this.loadAuthors();
            });
            this.isNewRecord = false;
            this.editedAuthor = null;
        } else {
            this.serv.updateAuthor(this.editedAuthor.id, this.editedAuthor).subscribe((resp: Response) => {
                this.statusMessage = 'Данные успешно обновлены';
                this.loadAuthors();
            });
            this.editedAuthor = null;
        }
    }

    cancel() {
        this.editedAuthor = null;
    }

    deleteAuthor(author: Author) {
        this.serv.deleteUser(author.id).subscribe((resp: Response) => {
            this.statusMessage = 'Данные успешно удалены',
                this.loadAuthors();
        });
    }

    routeToBooks(author: Author) {
        this.router.navigate(['/booksByAuthor', author.id]);
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

}