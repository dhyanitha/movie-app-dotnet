import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommendationsComponent } from './recommendations.component';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { MovieComponent } from '../shared/components/movie/movie.component';
import { MovieService } from '../shared/service/movie.service';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';


describe('RecommendationsComponent', () => {
  let component: RecommendationsComponent;
  let fixture: ComponentFixture<RecommendationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [       
        MovieComponent,
        RecommendationsComponent
      ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
      providers: [
        HttpHandler,
        HttpClient,
        MovieService
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecommendationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});