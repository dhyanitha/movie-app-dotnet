import { browser, by, element, $ } from 'protractor';

export class MovieAppPage {
  navigateTo() {
    return browser.get('/');
  }

  getParagraphText() {

    return element(by.css('app-root header div a')).getText();
  }

  getTrendingSectionText() {
    return element(by.css('#trending .header-title')).getText();
  }

  getForthcomingSectionText() {
    return element(by.css('#forthcoming .header-title')).getText();
  }

  getRecommendationsSectionText() {
    return element(by.css('#recommendations .header-title')).getText();
  }

  getTrendingSectionMovies() {
    return element.all(by.css('#trending .card')).count();
  }

  getForthcomingSectionMovies() {
    return element.all(by.css('#forthcoming .card')).count();
  }

  getRecommendationsSectionMovies() {
    return $('#recommendations .card');
  }

  getRecommendationsSectionNoMoviesMessage() {
    return $('#recommendations p#no-movies');
  }

  getFirstRecommendOrUnrecommendButton() {
    // First toggle button
    browser.sleep(6000);
    // more than one btn will be there, taking first element
    return element(by.css('.card .btn'))
  }

  getFirstRecommendOrUnrecommendButtonState() {
    // First toggle buttons state
    // more than one btn>i will be there, taking first element
    return element(by.css('.card .btn i'))
  }

  getPageFooter() {
    return element.all(by.tagName('footer')).count();
  }
  getPageHeaderLogo() {
    return element.all(by.css('.logo'));
  }

  getSectionPrevButton() {
    return element.all(by.css('.prev')).count();
  }
}