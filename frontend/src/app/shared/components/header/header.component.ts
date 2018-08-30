import { Component, OnInit } from '@angular/core';


/**
 * Header Component
 */
@Component({
  selector: 'movie-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  
  /**
   * Determines whether click on
   * @param e 
   */
  onClick(e:HTMLElement){
    $(this).toggleClass('open');
    $('#navigation').slideToggle(400);
}
}
