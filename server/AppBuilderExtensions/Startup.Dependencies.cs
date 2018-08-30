

namespace server.AppBuilderExtensions
{
    using Microsoft.Extensions.DependencyInjection;
    using server.Services;

    /// <summary>
    /// Dependency Registration
    /// </summary>
    public static class DependenciesExtensions
    {
        /// <summary>
        /// Configures the dependencies.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMoviesContext, MoviesContext>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IMovieService, MovieService>();

            return services;
        }
    }
}