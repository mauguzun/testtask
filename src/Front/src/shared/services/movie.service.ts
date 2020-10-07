import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { QuerySearch } from '../../models/QuerySearch';
import { MovieFullIformation } from '../../models/MovieFullIformation';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private _api = 'http://localhost:5000/';


  constructor(private _http: HttpClient) { }

  searchMovies(query, pageNumber = 1): Observable<any> {

    this.lastQueries = this._http.get<QuerySearch>(`${this._api}queries`);
    return this._http.get(`${this._api}search/${query}/${pageNumber}`);
  }

  getMovie(name: string): Observable<MovieFullIformation> {
    return this._http.get<MovieFullIformation>(`${this._api}${name}`);
  }


  lastQueries: Observable<QuerySearch> = this._http.get<QuerySearch>(`${this._api}queries`);



}
