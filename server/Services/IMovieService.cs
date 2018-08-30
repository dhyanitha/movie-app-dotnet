using server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    /// <summary>
    /// Movie Service Interface
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        /// Searches the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Returns List of Movies</returns>
        IEnumerable<Movie> Search(string query);

        /// <summary>
        /// Searches the by director.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Returns List of Movies</returns>
        IEnumerable<Movie> SearchByDirector(string query);
        /// <summary>
        /// Adds the recommendation.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns></returns>
        int AddRecommendation(Movie movie);
        /// <summary>
        /// Deletes the recommendation.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        void DeleteRecommendation(int movieId);
        /// <summary>
        /// Gets the recommended movie.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        Movie GetRecommendedMovie(int movieId);
        /// <summary>
        /// Gets the recommended all movies.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Movie> GetRecommendedAllMovies();

        /// <summary>
        /// Gets the recommended movies.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Movie> GetRecommendedMovies();
        /// <summary>
        /// Gets the trending movies.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Movie> GetTrendingMovies();
        /// <summary>
        /// Gets the upcoming movies.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Movie> GetUpcomingMovies();
        /// <summary>
        /// Updates the recommendation.
        /// </summary>
        /// <param name="Movie">The movie.</param>
        /// <returns></returns>
        Movie UpdateRecommendation(Movie Movie);
    }
}
