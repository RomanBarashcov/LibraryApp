import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { PagerService } from './Services/pagination.service';

import { AppComponent } from './Components/app.component';
import { HomeComponent } from './Components/home.component';
import { AuthorComponent } from './Components/author.component';
import { BookComponent } from './Components/book.component';
import { ConnectionStringComponent } from './Components/connectionString.component';
import { NotFoundComponent } from './Components/not-found.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'authors', component: AuthorComponent },
    { path: 'books', component: BookComponent },
    { path: 'booksByAuthor/:id', component: BookComponent },
    { path: 'connectionString', component: ConnectionStringComponent },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, HomeComponent, AuthorComponent, BookComponent, ConnectionStringComponent, NotFoundComponent],
    providers: [PagerService],
    bootstrap: [AppComponent]
})
export class AppModule { }