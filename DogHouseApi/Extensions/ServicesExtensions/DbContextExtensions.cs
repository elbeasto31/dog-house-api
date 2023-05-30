using DogHouseApi.Constants;
using DogHouseApi.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DogHouseApi.Extensions.ServicesExtensions
{
    public static class DbContextExtensions
    {
        public static void AddPostgreContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DogHouseDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString(ConfigSections.DbConnection)));
        }
    }
}