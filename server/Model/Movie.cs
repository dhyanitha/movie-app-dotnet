namespace server.Model
{

    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Movie
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column(Order = 0)]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        /// <value>
        /// The overview.
        /// </value>
        [JsonProperty("overview")]
        public string Overview { get; set; }

        /// <summary>
        /// Gets or sets the poster path.
        /// </summary>
        /// <value>
        /// The poster path.
        /// </value>
        [JsonProperty(PropertyName = "backdrop_path")]
        public string PosterPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is recommended.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is recommended; otherwise, <c>false</c>.
        /// </value>
        [NotMapped]
        [JsonProperty("recommended")]
        public bool IsRecommended { get; set; }

        /// <summary>
        /// Gets or sets the created updated date time.
        /// </summary>
        /// <value>
        /// The created updated date time.
        /// </value>
        [JsonIgnore]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed), Column(Order = 1)]
        public DateTime? CreatedUpdatedDateTime { get; set; } = DateTime.UtcNow; 
    }
}
