import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { MovieService } from '../shared/services/movie.service';
import { DialogComponent } from '../shared/component/dialog/dialog.component';
import { Movie } from '../models/Movie';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {

  title = 'movies';

  searchField: FormControl;
  movies : Movie[];
  nextPage = 1;
  loading = false;


  private _querySearch = null;

  public get querySearch() {
    return this._querySearch;
  }

  public set querySearch(value) {

    if (value.trim().length > 3) {
      this.loading = true;
      this._querySearch = value.trim();
      this._subscribe();
    }

  }

  constructor(public service: MovieService, public dialog: MatDialog) { }



  ngOnInit(): void {
   
  }

  private _subscribe(): void {
    this.service.searchMovies(this._querySearch, this.nextPage).subscribe(({ Search, NextPage }) => {
      this.loading = false;
      this.movies = Search;
      this.nextPage = NextPage;
    });
  }

  loadNext() {
    this._subscribe();
  }

  laodMovie(movie) {
    this.dialog.open(DialogComponent, {
      data: {
        id: movie.ImdbID
      }
    })
  }
}
