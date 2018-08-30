namespace server.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        public string ApiKey { get; set; }
        /// <summary>
        /// Gets or sets the get trending movies URL.
        /// </summary>
        /// <value>
        /// The get trending movies URL.
        /// </value>
        public string GetTrendingMoviesUrl { get; set; }
        /// <summary>
        /// Gets or sets the get upcoming movies URL.
        /// </summary>
        /// <value>
        /// The get upcoming movies URL.
        /// </value>
        public string GetUpcomingMoviesUrl { get; set; }
        /// <summary>
        /// Gets or sets the get movies URL.
        /// </summary>
        /// <value>
        /// The get movies URL.
        /// </value>
        public string GetMoviesUrl { get; set; }
        /// <summary>
        /// Gets or sets the get recommended movies URL.
        /// </summary>
        /// <value>
        /// The get recommended movies URL.
        /// </value>
        public string GetRecommendedMoviesUrl { get; set; }
    }
}
