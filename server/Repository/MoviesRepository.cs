using server.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace server
{
    /// <summary>
    /// Movies Repository
    /// </summary>
    /// <seealso cref="server.IMoviesRepository" />
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IMoviesContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesRepository"/> class.
        /// </summary>
        /// <param name="dbcontext">The dbcontext.</param>
        public MoviesRepository(IMoviesContext dbcontext)
        {
            _context = dbcontext;            
        }
        /// <summary>
        /// Adds the recommendation.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns>Returns the added movie id</returns>
        public int AddRecommendation(Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return movie.Id;
            }
            catch
            {
                throw new Exception("Unable to add movies!!");
            }
        }

        /// <summary>
        /// Deletes the recommendation.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        public void DeleteRecommendation(int movieId)
        {
            try
            {
                var movie = _context.Movies
                   .SingleOrDefault(s => s.Id == movieId);

                if (movie != null)
                {
                    _context.Movies
                        .Remove(movie);

                    _context.SaveChanges();
                }
            }

            catch
            {
                throw new Exception("Unable to remove movies!!");
            }
        }

        /// <summary>
        /// Gets the recommended movie.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        public Movie GetRecommendedMovie(int movieId)
        {
            try { 
            return _context.Movies
                .Where(s => s.Id == movieId)
                .SingleOrDefault();
            }
            catch
            {
                throw new Exception("No movies found!!");
            }
        }

        /// <summary>
        /// Gets the recommended movies.
        /// </summary>
        /// <returns>Returns the list of recommended movies</returns>
        public IEnumerable<Movie> GetRecommendedMovies()
        {
            try
            {
                return _context.Movies.OrderByDescending(m => m.CreatedUpdatedDateTime).ToList();
            }
            catch
            {
                throw new Exception("No movies found!!");
            }
        }

        /// <summary>
        /// Updates the recommendation.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns></returns>
        public Movie UpdateRecommendation(Movie movie)
        {
            try
            {
                _context.Movies.Update(movie);

                _context.SaveChanges();
                return movie;
            }
            catch
            {
                throw new Exception("No movies found!!");
            }
        }
    }
}
