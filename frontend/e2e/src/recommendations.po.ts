import { browser, by, element, ExpectedConditions as EC, $ } from 'protractor';

export class RecmmendationsPage {
  navigateTo() {
    return browser.get('/recommendations');
  }

  getSearchTextField() {
    return element(by.id('search-text-field'));
  }

  getSearchResultsSectionText() {
    return element(by.css('#search-results .header-title')).getText();
  }

  getSearchResultsSectionMovies() {
    return $('#search-results .card');
  }

  getSearchResultsSectionNoMoviesMessage() {
    return $('#search-results p#no-movies');
  }

  getRecommendationsSectionText() {
    return element(by.css('#recommendations .header-title')).getText();
  }

  getRecommendationsSectionMovies() {
    return $('#recommendations .card');
  }

  getRecommendationsSectionNoMoviesMessage() {
    return $('#recommendations p#no-movies');
  }
}