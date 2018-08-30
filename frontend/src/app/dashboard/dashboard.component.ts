import { Component, OnInit, ViewChildren, QueryList } from '@angular/core';
import { Movie } from '../shared/Model/movie';
import { MovieComponent } from '../shared/components/movie/movie.component';


/**
 * Dashboard Component
 */
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})

export class DashboardComponent implements OnInit {
  @ViewChildren(MovieComponent) child: QueryList<MovieComponent>;

  constructor() { }

  ngOnInit() {
  }

  
  /**
   * Determines whether notify toggle recommend on
   * @param movie 
   */
  onNotifyToggleRecommend(movie: Movie): void {
    this.updateOthers('trending', movie);
    this.updateOthers('upcoming', movie);
    this.child.find(c => c.section === 'recommendations').ngOnInit();
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
