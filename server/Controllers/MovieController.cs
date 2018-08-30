using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using server.Model;
using server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace server.Controllers
{
    /// <summary>
    /// Movie Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/Movies")]
    [EnableCors("CorsPolicy")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieController"/> class.
        /// </summary>
        /// <param name="movieService">The movies service.</param>
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Searches the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Returns the movie list</returns>
        // GET api/movies/search
        [Route("search")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Movie>), (int)HttpStatusCode.OK)]
        public IActionResult Search(string query)
        {
            try
            {
                var movies = _movieService.Search(query);
                if (movies == null || !movies.Any())
                {
                    return NotFound();
                }

                return Ok(movies);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest, "Movie Service may down. Please try after sometime.");
            }
        }

        // GET api/movies/search
        /// <summary>
        /// Search the movies by director.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Returns the status and the movies list</returns>
        [Route("search/director")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Movie>), (int)HttpStatusCode.OK)]
        public IActionResult SearchbyDirector(string query)
        {
            try
            {
                var movies = _movieService.SearchByDirector(query);
                if (movies == null || !movies.Any())
                {
                    return NotFound();
                }

                return Ok(movies);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest, "Movie Service may down. Please try after sometime.");
            }
        }
        // GET api/movies/recommended
        /// <summary>
        /// Gets recommended movies.
        /// </summary>
        /// <returns>returns the status</returns>
        [Route("recommended")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Movie>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            try
            {
                var movies = _movieService.GetRecommendedMovies();               
                if (movies == null || !movies.Any())
                {
                    return NotFound();
                }
                return Ok(movies);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Movie Service may down. Please try after sometime.");
            }
        }

        /// <summary>
        /// Add the recommended movie.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns>return the status</returns>
        // POST api/movies/recommend
        [Route("recommend")]
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody]Movie movie)
        {
            try
            {
                return Ok(_movieService.AddRecommendation(movie));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Unable to add your movie recommendation. Please try after sometime.");
            }
        }

        // DELETE api/movies/unrecommend/7
        /// <summary>
        /// Remove the recommeded movie by Id.
        /// </summary>
        /// <param name="id">movie id</param>
        /// <returns>Returns the statement</returns>
        [Route("unrecommend/{id}")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                _movieService.DeleteRecommendation(id);
                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Unable to unrecommend the movie. Please check your movie id");
            }
        }

        // GET api/movies/trending
        /// <summary>
        /// Gets the trending movies.
        /// </summary>
        /// <returns>Returns the list of trending movies</returns>
        [Route("trending")]
        [ProducesResponseType(typeof(Movie[]), (int)HttpStatusCode.OK)]
        public IActionResult GetTrendingMovies()
        {
            try
            {

                var movies = _movieService.GetTrendingMovies();
                if (movies == null || !movies.Any())
                {
                    return NotFound();
                }
                return Ok(movies);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Movie Service may down. Please try after sometime.");
            }

        }

        // GET api/movies/upcoming
        /// <summary>
        /// Gets the upcoming movies.
        /// </summary>
        /// <returns>Returs the list of upcoming movies</returns>
        [Route("upcoming")]
        [ProducesResponseType(typeof(Movie[]), (int)HttpStatusCode.OK)]
        public IActionResult GetUpcomingMovies()
        {
            try
            {
                var movies = _movieService.GetUpcomingMovies();
                if (movies == null || !movies.Any())
                {
                    return NotFound();
                }
                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Movie Service may down. Please try after sometime.");
            }

        }
        // GET api/movies/recommendations
        /// <summary>
        /// Gets the recommended movies.
        /// </summary>
        /// <returns>Returns the list of recommended movies</returns>
        [Route("recommendations")]
        [ProducesResponseType(typeof(Movie[]), (int)HttpStatusCode.OK)]
        public IActionResult GetRecommendedMovies()
        {
            try
            {
                var movies = _movieService.GetRecommendedAllMovies();
                if (movies == null || !movies.Any())
                {
                    return NotFound();
                }
                return Ok(movies);                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Movie Service may down. Please try after sometime.");
            }
        }
    }
}
