using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using server.AppBuilderExtensions;
using server.Model;
using Swashbuckle.AspNetCore.Swagger;

namespace server
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<Settings>(Configuration.GetSection("Settings"));
            services.AddCors();
            services.AddDbContext<MoviesContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.ConfigureDependencies();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "SBA Assessment",
                    Contact = new Contact() { Name = "SBA Assessment", Email = "devendran.m@cognizant.com" }
                });


                c.IncludeXmlComments(GetXmlCommentsPath());
                c.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigration();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureRoutes();
            //app.UseCorsMiddleware();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle("SBA Assessment");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });
            app.UseCors("CorsPolicy");
            // app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

        }
        /// <summary>
        /// Gets the XML comments path.
        /// </summary>
        /// <returns></returns>
        private string GetXmlCommentsPath()
        {
            var app = PlatformServices.Default.Application;
            return System.IO.Path.Combine(app.ApplicationBasePath, "server.xml");
        }

    }
}
