import { Component, OnInit, Inject } from '@angular/core';
import { MovieService } from '../../services/movie.service';
import { Movie } from '../../../models/Movie';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MovieFullIformation } from '../../../models/MovieFullIformation';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.less']
})
export class DialogComponent implements OnInit {

  movie: MovieFullIformation = null
  loading = true;

  properties: string[] = ['Actors', 'Awards', 'Genre', 'Director', 'Language', 'Released', 'Plot'] // in model  2 much 


  constructor(private service: MovieService, @Inject(MAT_DIALOG_DATA) public data) { }

  ngOnInit() {

    this.service.getMovie(this.data.id).subscribe((movie: MovieFullIformation) => {
      //   this.properties = Object.getOwnPropertyNames(movie);  //  :(  2 much 
      this.movie = movie;
      this.loading = false;
    })
  }

}
