using Moq;
using server;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.Options;
using server.Model;
using System.Net.Http;
using RichardSzalay.MockHttp;
using Newtonsoft.Json;
using server.Services;

namespace servertest
{
   public class MovieServiceTest
    {
        private readonly Mock<IMoviesRepository> mockRepo;
        private readonly Settings mockSettings;

        public MovieServiceTest()
        {
            mockRepo = new Mock<IMoviesRepository>();
            mockSettings = new Settings
            {
                GetTrendingMoviesUrl = "https://api.themoviedb.org/3/movie/popular?api_key=6545279e0de20ff3691b0fdc6e99c188&language=en-US&page=1",
                GetUpcomingMoviesUrl = "https://api.themoviedb.org/3/movie/upcoming?api_key=6545279e0de20ff3691b0fdc6e99c188&language=en-US&page=1",
                GetMoviesUrl = "https://api.themoviedb.org/3/search/movie?api_key=6545279e0de20ff3691b0fdc6e99c188&language=en-US&page=1&include_adult=false&sort_by=popularity.desc&query=",
                GetRecommendedMoviesUrl = "https://api.themoviedb.org/3/movie/{id}/similar?api_key=6545279e0de20ff3691b0fdc6e99c188&language=en-US&page=1&include_adult=false&sort_by=popularity.desc"
            };
        }
        

        [Fact]
        public void Get_ShouldReturnUpcomingmoviesAsExpected()
        {
           

            //Arrange
            var mockDependency = new Mock<HttpClient>();
            var mockHttp = new MockHttpMessageHandler();
            var jsonResult = "{ 'adult': false,'backdrop_path': '/3P52oz9HPQWxcwHOwxtyrVV1LKi.jpg','belongs_to_collection': {},'budget': 110000000,'genres': [], 'homepage': 'https://www.foxmovies.com/movies/deadpool-2', 'id': 383498,'imdb_id': 'tt5463162', 'original_language': 'en', 'original_title': 'Deadpool 2','overview': 'Wisecracking mercenary Deadpool battles the evil and powerful Cable and other bad guys to save a boys life.','popularity': 490.010595, 'poster_path': '/to0spRl1CMDvyUbOnbb4fTk3VAd.jpg', 'production_companies': [], 'production_countries': [],  'release_date': '2018-05-15',  'revenue': 499445548, 'runtime': 119, 'spoken_languages': [], 'status': 'Released', 'tagline': 'Prepare for the Second Coming.', 'title': 'Deadpool 2', 'video': false, 'vote_average': 7.9, 'vote_count': 1443}";

            // Act

            mockHttp.When(mockSettings.GetUpcomingMoviesUrl)
                   .Respond("application/json", jsonResult); // Respond with JSON
            var client = mockHttp.ToHttpClient();
            var response = client.GetStringAsync(mockSettings.GetUpcomingMoviesUrl).Result;
            var movieResponse = JsonConvert.DeserializeObject<MovieResponse>(response);
            this.mockRepo.Setup(x => x.GetRecommendedMovies()).Returns(this.GetTestMovies);
            var mock = new Mock<IOptions<Settings>>();
            // We need to set the Value of IOptions to be the SampleOptions Class
            mock.Setup(ap => ap.Value).Returns(mockSettings);
            var service = new MovieService(mock.Object, mockRepo.Object);
            var result = service.GetUpcomingMovies();
            // Assert

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_ShouldReturnTrendingmoviesAsExpected()
        {


            //Arrange
            var mockDependency = new Mock<HttpClient>();
            var mockHttp = new MockHttpMessageHandler();
            var jsonResult = "{ 'adult': false,'backdrop_path': '/3P52oz9HPQWxcwHOwxtyrVV1LKi.jpg','belongs_to_collection': {},'budget': 110000000,'genres': [], 'homepage': 'https://www.foxmovies.com/movies/deadpool-2', 'id': 383498,'imdb_id': 'tt5463162', 'original_language': 'en', 'original_title': 'Deadpool 2','overview': 'Wisecracking mercenary Deadpool battles the evil and powerful Cable and other bad guys to save a boys life.','popularity': 490.010595, 'poster_path': '/to0spRl1CMDvyUbOnbb4fTk3VAd.jpg', 'production_companies': [], 'production_countries': [],  'release_date': '2018-05-15',  'revenue': 499445548, 'runtime': 119, 'spoken_languages': [], 'status': 'Released', 'tagline': 'Prepare for the Second Coming.', 'title': 'Deadpool 2', 'video': false, 'vote_average': 7.9, 'vote_count': 1443}";

            // Act

            mockHttp.When(mockSettings.GetTrendingMoviesUrl)
                   .Respond("application/json", jsonResult); // Respond with JSON
            var client = mockHttp.ToHttpClient();
            var response = client.GetStringAsync(mockSettings.GetTrendingMoviesUrl).Result;
            var movieResponse = JsonConvert.DeserializeObject<MovieResponse>(response);
            this.mockRepo.Setup(x => x.GetRecommendedMovies()).Returns(this.GetTestMovies);
            var mock = new Mock<IOptions<Settings>>();
            // We need to set the Value of IOptions to be the SampleOptions Class
            mock.Setup(ap => ap.Value).Returns(mockSettings);
            var service = new MovieService(mock.Object, mockRepo.Object);
            var result = service.GetUpcomingMovies();
            // Assert

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_ShouldReturnRecommendedMoviesAsExpected()
        {


            //Arrange
            var mockDependency = new Mock<HttpClient>();
            var mockHttp = new MockHttpMessageHandler();
            var jsonResult = "{ 'adult': false,'backdrop_path': '/3P52oz9HPQWxcwHOwxtyrVV1LKi.jpg','belongs_to_collection': {},'budget': 110000000,'genres': [], 'homepage': 'https://www.foxmovies.com/movies/deadpool-2', 'id': 383498,'imdb_id': 'tt5463162', 'original_language': 'en', 'original_title': 'Deadpool 2','overview': 'Wisecracking mercenary Deadpool battles the evil and powerful Cable and other bad guys to save a boys life.','popularity': 490.010595, 'poster_path': '/to0spRl1CMDvyUbOnbb4fTk3VAd.jpg', 'production_companies': [], 'production_countries': [],  'release_date': '2018-05-15',  'revenue': 499445548, 'runtime': 119, 'spoken_languages': [], 'status': 'Released', 'tagline': 'Prepare for the Second Coming.', 'title': 'Deadpool 2', 'video': false, 'vote_average': 7.9, 'vote_count': 1443}";

            // Act

            mockHttp.When(mockSettings.GetRecommendedMoviesUrl)
                   .Respond("application/json", jsonResult); // Respond with JSON
            var client = mockHttp.ToHttpClient();
            var response = client.GetStringAsync(mockSettings.GetRecommendedMoviesUrl).Result;
            var movieResponse = JsonConvert.DeserializeObject<MovieResponse>(response);
            this.mockRepo.Setup(x => x.GetRecommendedMovies()).Returns(this.GetTestMovies);
            var mock = new Mock<IOptions<Settings>>();
            // We need to set the Value of IOptions to be the SampleOptions Class
            mock.Setup(ap => ap.Value).Returns(mockSettings);
            var service = new MovieService(mock.Object, mockRepo.Object);
            var result = service.GetUpcomingMovies();
            // Assert

            Assert.NotNull(result);
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
