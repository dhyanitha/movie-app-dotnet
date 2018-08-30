using server.Model;
using System;
using System.Linq;

namespace server
{
    /// <summary>
    /// Db Initializer
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void Initialize(MoviesContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            var movies = new Movie[]
            {
            new Movie{ Id=299536, Title="Avengers: Infinity War", Overview="As the Avengers and their allies have continued to protect the world from threats too large for any one hero to handle, a new danger has emerged from the cosmic shadows: Thanos. A despot of intergalactic infamy, his goal is to collect all six Infinity Stones, artifacts of unimaginable power, and use them to inflict his twisted will on all of reality. Everything the Avengers have fought for has led up to this moment - the fate of Earth and existence itself has never been more uncertain.",PosterPath=string.Empty, IsRecommended=false }

            };
            foreach (Movie s in movies)
            {
                context.Movies.Add(s);
            }
            context.SaveChanges();


        }
    }
}
