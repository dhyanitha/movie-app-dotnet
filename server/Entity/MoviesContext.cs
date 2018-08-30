using Microsoft.EntityFrameworkCore;
using server.Model;

namespace server
{
    /// <summary>
    /// Movies Db Context
    /// </summary>
    /// <seealso cref="DbContext" />
    public class MoviesContext : DbContext, IMoviesContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesContext"/> class.
        /// </summary>
        public MoviesContext()
        {

        }
        /// <summary>
        /// Gets or sets the movies.
        /// </summary>
        /// <value>
        /// The movies.
        /// </value>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Movie>().HasKey(t => new { t.Id });

            base.OnModelCreating(builder);
        }
    }
}