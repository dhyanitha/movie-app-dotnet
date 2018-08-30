using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace server
{
    /// <summary>
    /// 
    /// </summary>
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorsMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    /// <summary>
    /// Cors Middleware Extensions
    /// </summary>
    public static class CorsMiddlewareExtensions
    {
        /// <summary>
        /// Uses the cors middleware.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorsMiddleware>();
        }
    }
}
