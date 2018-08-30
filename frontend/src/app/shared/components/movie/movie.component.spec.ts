
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClient, HttpHandler } from '@angular/common/http';
import {ActivatedRoute, Router } from '@angular/router';



import { MovieService } from '../../service/movie.service';
import { MovieComponent } from './movie.component';
import { Movie } from '../../Model/movie';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Observable, of } from 'rxjs';

const dummyMovie: Movie[] =[
  {
  id: 1,
  title:'Iron Man',
  overview: 'string',
  posterPath:'/bOGkgRGdhrBYJSLpXaxhXVstddV.jpg',
  recommended: true
},
{
  id: 2,
  title:'Iron Man',
  overview: 'string',
  posterPath:'/bOGkgRGdhrBYJSLpXaxhXVstddV.jpg',
  recommended: true
}
   
  
];

class MockMovie{
  section:string ='upcoming';
  public getMovies(section):Observable<Movie[]>{
  return of(dummyMovie);
  } 
}
describe('MovieComponent', () => {
  let component: MovieComponent;
  let fixture: ComponentFixture<MovieComponent>;
  let service: MovieService;

  const fakeActivatedRoute = {
    snapshot: { data: { } }
  } as ActivatedRoute;
  const fakeRouter = {
      } as Router;


  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MovieComponent ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
      providers:[ HttpClient, HttpHandler, MovieService,
         {provide: ActivatedRoute, useValue: fakeActivatedRoute},
         {provide: Router, useValue: fakeRouter},
         {provide: MovieService,  useClass: MockMovie}
        ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    service = TestBed.get(MovieService);
    spyOn(service,'getMovies').and.callThrough();
    
  });
 
  it('should set the movie detail', () => {
    component.ngOnInit();
    expect(service.getMovies('trending')).toHaveBeenCalled;
  });

});