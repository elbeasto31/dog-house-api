using AspNetCoreRateLimit;
using DogHouseApi.DataBase.Repositories.Abstractions;
using DogHouseApi.DataBase.Repositories.EF;
using DogHouseApi.Extensions.ServicesExtensions;
using DogHouseApi.Services.Abstractions;
using DogHouseApi.Services.Impl;
using DogHouseApi.Utils.NamingPolicies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DogHouseApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance;
                });
            
            services.AddPostgreContext(Configuration);
            services.AddMemoryCache();
            services.AddRateLimiting(Configuration);
            
            services.AddScoped<IDogsService, DogsService>();
            services.AddScoped<IDogsRepository, DogsRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseIpRateLimiting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}