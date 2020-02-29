using Core.Domain.IRepository;
using Core.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class ConfigureRepository
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
