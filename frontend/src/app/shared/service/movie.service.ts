import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { Movie } from '../Model/movie';


/**
 * Movie Service
 */
@Injectable()
export class MovieService {
  getbyid(arg0: any): any {
    throw new Error("Method not implemented.");
  }

  constructor(private http: HttpClient) { }

  readonly httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' }) };
  
  /**
   * Searchs movies
   * @param term 
   * @param searchBy 
   * @returns movies 
   */
  searchMovies(term: string, searchBy: string): Observable<Movie[]> {
    if (!term.trim()) {
      return of([]);
    }
    if (searchBy === 'Movie') {
      return this.http.get<Movie[]>(`${environment.serviceUrls.searchByMovie}${term}`, this.httpOptions).pipe(
        catchError(this.handleError<Movie[]>('searchMovies', []))
      );
    } else if (searchBy === 'Director') {
      return this.http.get<Movie[]>(`${environment.serviceUrls.searchByDirector}${term}`, this.httpOptions).pipe(
        catchError(this.handleError<Movie[]>('searchMoviesByDirector', []))
      );
    }
  }


  
  /**
   * Gets movies
   * @param type 
   * @returns movies 
   */
  getMovies(type: string): Observable<Movie[]> {
    let serviceUrl: string;
    let sectionMessage: string;
    let errorMessage: string;
    switch (type) {
      case 'trending':
        serviceUrl = environment.serviceUrls.trending;
        sectionMessage = 'retrived trending movies';
        errorMessage = 'getTrendingMovies';
        break;
      case 'upcoming':
        serviceUrl = environment.serviceUrls.upcoming;
        sectionMessage = 'retrived upcoming movies';
        errorMessage = 'getUpcomingMovies';
        break;
      case 'recommended':
        serviceUrl = environment.serviceUrls.recommended;
        sectionMessage = 'retrived recommended movies';
        errorMessage = 'getRecommendedMovies';
        break;
      case 'recommendations':
        serviceUrl = environment.serviceUrls.recommendations;
        sectionMessage = 'retrived recommendations movies';
        errorMessage = 'getRecommendationsMovies';
        break;
      default:
      serviceUrl = environment.serviceUrls.trending;
      sectionMessage = 'retrived trending movies';
      errorMessage = 'getTrendingMovies';
        break;
    }
    return this.http.get<Movie[]>(serviceUrl, this.httpOptions).pipe(
      catchError(this.handleError<Movie[]>(errorMessage, []))
    );
  }

  
  /**
   * Toggles recommend
   * @param movie 
   * @returns recommend 
   */
  toggleRecommend(movie: Movie): Observable<any> {
    if (!movie.recommended) {
      movie.recommended = true;
      return this.http.post(environment.serviceUrls.recommend, movie, { responseType: 'text' }).pipe(
        catchError(this.handleError<Movie>('toggleRecommend post'))
      );
    } else {
      movie.recommended = false;
      return this.http.delete(`${environment.serviceUrls.unrecommend}/${movie.id}`, { responseType: 'text' }).pipe(
        catchError(this.handleError<Movie>('toggleRecommend del'))
      );
    }
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      console.error(`${operation} failed: ${error.message}`);

      return Observable.throw(new Error(error.message));
    };
  }
}
