using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using server.Model;

namespace server.Services
{
    /// <summary>
    /// Movie Service
    /// </summary>
    public class MovieService : IMovieService
    {
        private readonly Settings _settings;
        private readonly IMoviesRepository _moviesRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieService"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="moviesRepository">The movies repository.</param>
        public MovieService(IOptions<Settings> settings, IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
            _settings = settings.Value;
        }
        /// <summary>
        /// Searches the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// Returns List of Movies
        /// </returns>
        public IEnumerable<Movie> Search(string query)
        {
            var client = new HttpClient();
            var search = _settings.GetMoviesUrl + query;
            var request = client.GetStringAsync(search);
            var response = JsonConvert.DeserializeObject<MovieResponse>(request.Result);
            var recommendedMovies = _moviesRepository.GetRecommendedMovies();
            return response.Movies.GroupJoin(recommendedMovies,
               (rm => rm.Id), (rc => rc.Id),
               (rm, rc) => new Movie
               {
                   Id = rm.Id,
                   CreatedUpdatedDateTime = rm.CreatedUpdatedDateTime,
                   Overview = rm.Overview,
                   PosterPath = rm.PosterPath,
                   Title = rm.Title,
                   IsRecommended = rc?.Any(m => m.Id == rm.Id) ?? false
               });
        }
        /// <summary>
        /// Searches the by director.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// Returns List of Movies
        /// </returns>
        public IEnumerable<Movie> SearchByDirector(string query)
        {
            var client = new HttpClient();
            var search = _settings.GetMoviesUrl + query;
            var request = client.GetStringAsync(search);
            var response = JsonConvert.DeserializeObject<MovieResponse>(request.Result);
            var recommendedMovies = _moviesRepository.GetRecommendedMovies();
            return response.Movies.GroupJoin(recommendedMovies,
                (rm => rm.Id), (rc => rc.Id),
                (rm, rc) => new Movie
                {
                    Id = rm.Id,
                    CreatedUpdatedDateTime = rm.CreatedUpdatedDateTime,
                    Overview = rm.Overview,
                    PosterPath = rm.PosterPath,
                    Title = rm.Title,
                    IsRecommended = rc?.Any(m => m.Id == rm.Id) ?? false
                });
        }

        /// <summary>
        /// Updates the recommendation.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns></returns>
        public Movie UpdateRecommendation(Movie movie)
        {
            return _moviesRepository.UpdateRecommendation(movie);
        }
        /// <summary>
        /// Adds the recommendation.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns></returns>
        public int AddRecommendation(Movie movie)
        {
            return _moviesRepository.AddRecommendation(movie);
        }

        /// <summary>
        /// Deletes the recommendation.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        public void DeleteRecommendation(int movieId)
        {
            _moviesRepository.DeleteRecommendation(movieId);
        }

        /// <summary>
        /// Gets the recommended movie.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        public Movie GetRecommendedMovie(int movieId)
        {
            return _moviesRepository.GetRecommendedMovie(movieId);
        }

        /// <summary>
        /// Gets the recommended all movies.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Movie> GetRecommendedAllMovies()
        {
            var client = new HttpClient();
            var recommendedMovies = _moviesRepository.GetRecommendedMovies();
            var latestMovieId = recommendedMovies.OrderByDescending(m => m.CreatedUpdatedDateTime).FirstOrDefault()?.Id;
            if (latestMovieId > 0)
            {
                var request = client.GetStringAsync(_settings.GetRecommendedMoviesUrl.Replace("{id}", latestMovieId.ToString()));
                var response = JsonConvert.DeserializeObject<MovieResponse>(request.Result);
                return response.Movies.GroupJoin(recommendedMovies,
             (rm => rm.Id), (rc => rc.Id),
             (rm, rc) => new Movie
             {
                 Id = rm.Id,
                 CreatedUpdatedDateTime = rm.CreatedUpdatedDateTime,
                 Overview = rm.Overview,
                 PosterPath = rm.PosterPath,
                 Title = rm.Title,
                 IsRecommended = rc?.Any(m => m.Id == rm.Id) ?? false
             });
            }
            return null;
        }

        /// <summary>
        /// Gets the trending movies.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Movie> GetTrendingMovies()
        {
            var client = new HttpClient();
            var request = client.GetStringAsync(_settings.GetTrendingMoviesUrl);
            var response = JsonConvert.DeserializeObject<MovieResponse>(request.Result);
            var recommendedMovies = _moviesRepository.GetRecommendedMovies();
            return response.Movies.GroupJoin(recommendedMovies,
               (rm => rm.Id), (rc => rc.Id),
               (rm, rc) => new Movie
               {
                   Id = rm.Id,
                   CreatedUpdatedDateTime = rm.CreatedUpdatedDateTime,
                   Overview = rm.Overview,
                   PosterPath = rm.PosterPath,
                   Title = rm.Title,
                   IsRecommended = rc?.Any(m => m.Id == rm.Id) ?? false
               });
        }

        /// <summary>
        /// Gets the upcoming movies.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Movie> GetUpcomingMovies()
        {
            var client = new HttpClient();
            var request = client.GetStringAsync(_settings.GetUpcomingMoviesUrl);
            var recommendedMovies = _moviesRepository.GetRecommendedMovies();
            var response = JsonConvert.DeserializeObject<MovieResponse>(request.Result);

            return response.Movies.GroupJoin(recommendedMovies,
             (rm => rm.Id), (rc => rc.Id),
             (rm, rc) => new Movie
             {
                 Id = rm.Id,
                 CreatedUpdatedDateTime = rm.CreatedUpdatedDateTime,
                 Overview = rm.Overview,
                 PosterPath = rm.PosterPath,
                 Title = rm.Title,
                 IsRecommended = rc?.Any(m => m.Id == rm.Id) ?? false
             });
        }

        /// <summary>
        /// Gets the recommended movies.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Movie> GetRecommendedMovies()
        {
            return _moviesRepository.GetRecommendedMovies()
                    .Select(m => new Movie
                    {
                        Id = m.Id,
                        IsRecommended = true,
                        CreatedUpdatedDateTime = m.CreatedUpdatedDateTime,
                        Overview = m.Overview,
                        PosterPath = m.PosterPath,
                        Title = m.Title

                    }).ToList();
        }
    }
}
