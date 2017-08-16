import { Component, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { HttpService } from './http.service';
import { Author } from './author';
    
@Component({
    selector: 'my-app',
    template: `<div> 
                    <ul>
                      <li *ngFor="let author of authors">
                         <input type="hidden" value="{{author?.id}}" />
                         <p>Автор: {{author?.firstName}}  {{author?.serName}}</p>
                      </li>
                    </ul>
                <div>{{error}}</div>
               </div>`,
    providers: [ HttpService ]
                
})
export class AppComponent implements OnInit {

    authors: Author[]=[];
    error: any;
    constructor(private httpService: HttpService) { }

    ngOnInit() {

        this.httpService.getAuthors()
            .subscribe(
                data => this.authors = data,
                error => { this.error = error; console.log(error); }
            );
    }

}