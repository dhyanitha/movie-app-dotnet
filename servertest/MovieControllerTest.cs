using Microsoft.AspNetCore.Mvc;
using Moq;
using server.Controllers;
using server.Model;
using server.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Movies.Test
{
    public class MovieControllerTest
    {
        private readonly Mock<IMovieService> mockService;
        public MovieControllerTest()
        {
            mockService = new Mock<IMovieService>();
        }
        [Fact]
        public void Search_ShouldReturnmMoviesAsExpected()
        {
            // Arrange
            var movieName = "Ironman";
            this.mockService.Setup(x => x.Search(It.IsAny<string>())).Returns(this.GetTestMovies);
            var controller = new MovieController(mockService.Object);
            // Act
            var result = controller.Search(movieName);
            var actualResult = result as OkObjectResult;
            //Assert
            Assert.NotNull(actualResult.Value);
        }
        [Fact]
        public void SearchByDirector_ShouldReturnmMoviesAsExpected()
        {
            // Arrange
            var director = "Spielberg";
            this.mockService.Setup(x => x.SearchByDirector(It.IsAny<string>())).Returns(this.GetTestMovies);
            var controller = new MovieController(mockService.Object);
            // Act
            var result = controller.SearchbyDirector(director);
            var actualResult = result as OkObjectResult;
            //Assert
            Assert.NotNull(actualResult.Value);
        }
        [Fact]
        public void Get_ShouldReturnAllTrendingmoviesAsExpected()
        {
            // Arrange
            this.mockService.Setup(x => x.GetTrendingMovies()).Returns(this.GetTestMovies);
            var controller = new MovieController(mockService.Object);
            // Act
            var result = controller.GetTrendingMovies();
            var actualResult = result as OkObjectResult;
            //Assert
            Assert.NotNull(actualResult.Value);
        }
        [Fact]
        public void Get_ShouldReturnAllUpcomingmoviesAsExpected()
        {
            // Arrange
            this.mockService.Setup(x => x.GetUpcomingMovies()).Returns(this.GetTestMovies);
            var controller = new MovieController(mockService.Object);
            // Act
            var result = controller.GetUpcomingMovies();
            var actualResult = result as OkObjectResult;
            //Assert
            Assert.NotNull(actualResult.Value);
        }
        [Fact]
        public void Get_ShouldReturnAllRecommendationmoviesAsExpected()
        {
            // Arrange
            this.mockService.Setup(x => x.GetRecommendedMovies()).Returns(this.GetTestMovies);
            var controller = new MovieController(mockService.Object);
            // Act
            var result = controller.Get();
            var actualResult = result as OkObjectResult;
            //Assert
            Assert.NotNull(actualResult.Value);
        }
        /// <summary>
        /// Posts the should recommend movie as expected.
        /// </summary>
        [Fact]
        public void Post_ShouldRecommendMovieAsExpected()
        {
            // Arrange 
            var movie = new Movie()
            {
                Id = 1,
                Title = "God Father",
                Overview = "God Father"
            };
          
            mockService.Setup(x => x.AddRecommendation(It.IsAny<Movie>())).Returns(200);
            var controller = new MovieController(mockService.Object);
            // Act
            var result = controller.Post(movie) as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        /// <summary>
        /// Posts the should un recommend movie as expected.
        /// </summary>
        [Fact]
        public void Post_ShouldUnRecommendMovieAsExpected()
        {
            // Arrange 
            var movieId = 901;

            this.mockService.Setup(x => x.DeleteRecommendation(It.IsAny<int>())).Verifiable();
            var controller = new MovieController(mockService.Object);
            // Act
            var result = controller.Delete(movieId) as StatusCodeResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        /// <summary>
        /// Searches the should not returnm movies for invalid.
        /// </summary>
        [Fact]
        public void Search_ShouldNotReturnmMoviesForInvalid()
        {
            // Arrange
            var movieName = "NotFoundMovie";
            var controller = new MovieController(mockService.Object);
            // Act
            var badResponse = controller.Search(movieName);
            //Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        /// <summary>
        /// Searches the by director should not returnm movies for invalid.
        /// </summary>
        [Fact]
        public void SearchByDirector_ShouldNotReturnmMoviesForInvalid()
        {
            // Arrange
            var director = "NotFoundDirector";
            var controller = new MovieController(mockService.Object);
            // Act
            var badResponse = controller.SearchbyDirector(director);
            //Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        /// <summary>
        /// Gets the should not return all trendingmovies for invalid.
        /// </summary>
        [Fact]
        public void Get_ShouldNotReturnAllTrendingmoviesForInvalid()
        {
            // Arrange
            var controller = new MovieController(mockService.Object);
            // Act
            var badResponse = controller.GetTrendingMovies();
            //Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        /// <summary>
        /// Gets the should not return all upcomingmovies for invalid.
        /// </summary>
        [Fact]
        public void Get_ShouldNotReturnAllUpcomingmoviesForInvalid()
        {
            // Arrange
            var controller = new MovieController(mockService.Object);
            // Act
            var badResponse = controller.GetUpcomingMovies();
            //Assert
            Assert.IsType<NotFoundResult>(badResponse);

        }
        /// <summary>
        /// Gets the should not return all recommendationmovies for invalid.
        /// </summary>
        [Fact]
        public void Get_ShouldNotReturnAllRecommendationmoviesForInvalid()
        {
            // Arrange
            var controller = new MovieController(mockService.Object);
            // Act
            var badResponse = controller.Get();
            //Assert
            Assert.IsType<NotFoundResult>(badResponse);

        }
        /// <summary>
        /// Gets the test movie.
        /// </summary>
        /// <returns></returns>
        private Movie GetTestMovie()
        {
            var movie = new Movie()
            {
                CreatedUpdatedDateTime = DateTime.Now,
                Id = 1,
                Title = "Test One"
            };


            return movie;
        }

        /// <summary>
        /// Gets the test movies.
        /// </summary>
        /// <returns></returns>
        private Movie[] GetTestMovies()
        {
            var movies = new List<Movie>
            {
                new Movie() {CreatedUpdatedDateTime = DateTime.Now,Id = 1,Title = "Test One"},
                 new Movie() {CreatedUpdatedDateTime = DateTime.Now,Id = 2,Title = "Test Two"}
            };
            return movies.ToArray();

        }
    }
}
