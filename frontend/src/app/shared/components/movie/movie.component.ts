import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Movie } from '../../Model/movie';
import { MovieService } from '../../service/movie.service';


/**
 * Movie Component
 */
@Component({
  selector: 'movies-panel',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {

  @Input() movies: Movie[];
  @Input() section: string;
  @Output() notifyToggleRecommend: EventEmitter<Movie> = new EventEmitter<Movie>();
  i = 0;
  error = '';


  /**
   * Creates an instance of movie component.
   * @param movieService 
   */
  constructor(private movieService: MovieService) { }

  ngOnInit() {
    if (this.section !== 'search') {
      this.movieService.getMovies(this.section).subscribe(
        movie => this.movies = movie as Movie[],
        error => { this.error = error.message }
      );
    }

  }


  /**
   * Toggles recommend
   * @param movie 
   */
  toggleRecommend(movie: Movie): void {
    if (this.section === 'recommended') {
      this.movies = this.movies.filter(m => m !== movie);
    }
    this.movieService.toggleRecommend(movie).subscribe(
      _ => this.notifyToggleRecommend.emit(movie),
      error => { this.error = error.message }
    );
  }


  /**
   * Refreshs recommend
   * @param movie 
   */
  refreshRecommend(movie: Movie): void {
    if (this.section === 'recommended') {
      if (movie.recommended) {
        this.movies.push(movie);
      } else {
        this.movies = this.movies.filter(m => m !== movie);
      }
    }
  }


  /**
   * Gets title
   * @returns title 
   */
  getTitle(): string {
    if (this.section === 'search') {
      return 'Search Results';
    } else {
      return this.section + ' Movies';
    }
  }


  /**
   * Prev movie component
   */
  prev(): void {
    if (this.i > 0) {
      this.i = this.i - 1;
    }
  }


  /**
   * Next movie component
   */
  next(): void {
    if (this.movies && this.i < this.movies.length - 6) {
      this.i = this.i + 1;
    }
  }


  /**
   * Determines whether more has
   * @returns true if more 
   */
  hasMore(): boolean {
    return this.movies && (this.i === this.movies.length - 6 || this.movies.length < 6);
  }
  
}
