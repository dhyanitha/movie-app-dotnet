import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';

import { AppComponent } from './app.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RecommendationsComponent } from './recommendations/recommendations.component';
import { RouterModule } from '@angular/router';
import { MovieComponent } from './shared/components/movie/movie.component';
import { HttpClientModule } from '@angular/common/http';
import { MovieService } from './shared/service/movie.service';
import {ReactiveFormsModule, FormControl, FormsModule} from '@angular/forms';
import { AppErrorHandler } from './shared/error/apperrorhandler';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    DashboardComponent,
    RecommendationsComponent,
    MovieComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'dashboard', component: DashboardComponent },
      { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
      { path: 'recommendations', component: RecommendationsComponent },
      { path: '**', redirectTo: '/dashboard' }
  ])
  ],
  providers: [MovieService,
    {provide: ErrorHandler, useClass: AppErrorHandler}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
