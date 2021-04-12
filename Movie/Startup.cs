using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movie.DataAccess;
using Movie.MovieBL;

namespace Movie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adding Json Options to register a DateTime converter for 'Duration' field formatting as HH:mm:ss will
            // interfere with read/write of all DateTime fields, so applying a DateTimeConverter via DataModel attribute annotation
            services.AddControllers();
            // Register the two new interfaces with DI
            services.Add(new ServiceDescriptor(typeof(IMovieDataReader), typeof(MovieDataReader), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IMovieDataWriter), typeof(MovieDataWriter), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IMovieDataBL), typeof(MovieDataBL), ServiceLifetime.Transient));
        }
            
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
