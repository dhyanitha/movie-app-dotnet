import { Component, OnInit, ViewChildren, QueryList } from '@angular/core';
import { Movie } from '../shared/Model/movie';
import { MovieService } from '../shared/service/movie.service';
import { Observable, Subject } from 'rxjs';
import { MovieComponent } from '../shared/components/movie/movie.component';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

/**
 * Recommendations Component
 */
@Component({
  selector: 'app-search',
  templateUrl: './recommendations.component.html',
  styleUrls: ['./recomendations.component.css']
})
export class RecommendationsComponent implements OnInit {

  movies$: Observable<Movie[]>;
  searchBy = 'Movie';
  private searchTerms = new Subject<string>();

  @ViewChildren(MovieComponent) child: QueryList<MovieComponent>;

  constructor(private movieService: MovieService) { }

  
  /**
   * Searchs the movies
   * @param term 
   * @returns search 
   */
  search(term: string): void {
    if (term === undefined || term.length < 2) return;
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
      this.movies$ = this.searchTerms.pipe(
      debounceTime(400),
      distinctUntilChanged(),
      switchMap((term: string) => this.movieService.searchMovies(term, this.searchBy))
    );
  }

  
  /**
   * Determines whether notify toggle recommend on
   * @param movie 
   */
  onNotifyToggleRecommend(movie: Movie): void {
    this.updateOthers('search', movie);
    this.child.find(c => c.section === 'recommended').ngOnInit();
  }

  
  /**
   * Updates others
   * @param section 
   * @param movie 
   */
  updateOthers(section: String, movie: Movie) {
    const index = this.child.find(c => c.section === section).movies.findIndex(m => m.id === movie.id);
    if (index !== -1) {
      this.child.find(c => c.section === section).movies[index] = movie;
    }
  }

}
