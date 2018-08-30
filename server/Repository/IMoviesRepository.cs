using server.Model;
using System.Collections.Generic;

namespace server
{
    /// <summary>
    /// Movie Repository Interface
    /// </summary>
    public interface IMoviesRepository
    {
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
        /// Gets the recommended movies.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Movie> GetRecommendedMovies();
        /// <summary>
        /// Updates the recommendation.
        /// </summary>
        /// <param name="Movie">The movie.</param>
        /// <returns></returns>
        Movie UpdateRecommendation(Movie Movie);

    }
}
