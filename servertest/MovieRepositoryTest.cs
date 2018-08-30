
using Microsoft.EntityFrameworkCore;
using server;
using server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace servertest
{

    public class MovieRepositoryTest : IClassFixture<DbContextFixture>
    {
        private readonly MoviesRepository _movierepo;
        public DbContextFixture _dbfixture;
        public MovieRepositoryTest(DbContextFixture dbFixture)
        {
            _dbfixture = dbFixture;
            _movierepo = new MoviesRepository(_dbfixture.dbContext);
        }
        [Fact]
        public void GetAllMoviesList()
        {
            //Act
            var actual = _movierepo.GetRecommendedMovies();
            //Assert
            Assert.IsAssignableFrom<List<Movie>>(actual);
            Assert.NotNull(actual);
            Assert.True(actual.Count() > 0);
        }
        [Fact]
        public void GetMoviesbyId()
        {
            //Act
            Movie moviebyId = _movierepo.GetRecommendedMovie(200001);
            //Assert
            Assert.IsAssignableFrom<Movie>(moviebyId);
            Assert.NotNull(moviebyId);
            Assert.True(moviebyId.Id == 200001);
        }
        
        [Fact]
        public void Save_ShouldSaveMovieAsExpected()
        {
            // Arrange 
            var expected = 100;
            var movie = new Movie { Id = 100, Title = "Sarkar", PosterPath = "Dunkirk.jpg", Overview = "Test Data" };
            // Act
            var actual = _movierepo.AddRecommendation(movie);
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Save_ShouldNotSaveForAlreadyAddedMovieAsExpected()
        {
            // Arrange 
            var expected = 100;
            var movie = new Movie { Id = 101, Title = "Sarkar", PosterPath = "Dunkirk.jpg", Overview = "Test Data" };
            // Act
            var actual = _movierepo.AddRecommendation(movie); 
            // Assert
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void GetAll_ShouldReturnListOfMoviesAsExpected()
        {
            // Act
            var actual = _movierepo.GetRecommendedMovies().Count();
            // Assert
            var expected = _dbfixture.dbContext.Movies.Count();
            Assert.Equal(expected, actual);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class DbContextFixture : IDisposable
    {
        public IMoviesContext dbContext;
        public DbContextFixture()
        {
            var options = new DbContextOptionsBuilder<MoviesContext>().
                          UseInMemoryDatabase(databaseName: "MovieDB").Options;

            dbContext = new MoviesContext(options);
            dbContext.Movies.Add(new Movie { Id = 200001, Title = "City of Gold", PosterPath = "CityOfGold.jpg", Overview = "Test data" });
            dbContext.Movies.Add(new Movie { Id = 200002, Title = "SpiderMan", PosterPath = "Spiderman.jpg", Overview = "Test data" });
            dbContext.SaveChanges();
        }
        #region IDisposable Support
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            dbContext = null;
        }
        #endregion
    }
}
