using Commands.Customers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class ConfigureValidators
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateCustomer>, CreateCustomerValidator>();
        }
    }
}
