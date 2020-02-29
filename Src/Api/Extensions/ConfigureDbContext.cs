using Domain.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class ConfigureDbContext
    {
        public static void AddSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>
            (options =>
                options.EnableSensitiveDataLogging()
                    .UseSqlServer(configuration.GetConnectionString("ConnectionString")));

        }
    }
}