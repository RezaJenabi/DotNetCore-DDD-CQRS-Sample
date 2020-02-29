using CommandsHandler.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class ConfigureCommandsQueries
    {
        public static void AddCommandsQueries(this IServiceCollection services)
        {
            services.AddScoped<ICreateCustomerHandler, CreateCustomerHandler>();
        }
    }
}
