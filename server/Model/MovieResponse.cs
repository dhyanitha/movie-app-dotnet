using Newtonsoft.Json;

namespace server.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class MovieResponse
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        [JsonProperty("page")]
        public long Page { get; set; }

        /// <summary>
        /// Gets or sets the total results.
        /// </summary>
        /// <value>
        /// The total results.
        /// </value>
        [JsonProperty("total_results")]
        public long TotalResults { get; set; }

        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        /// <value>
        /// The total pages.
        /// </value>
        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the movies.
        /// </summary>
        /// <value>
        /// The movies.
        /// </value>
        [JsonProperty("results")]
        public Movie[] Movies { get; set; }
    }
}
