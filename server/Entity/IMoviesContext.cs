

using Microsoft.EntityFrameworkCore;
using server.Model;

namespace server
{
    /// <summary>
    /// Movies Context
    /// </summary>
    public interface IMoviesContext
    {
        /// <summary>
        /// Gets or sets the movies.
        /// </summary>
        /// <value>
        /// The movies.
        /// </value>
        DbSet<Movie> Movies { get; set; }
        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
