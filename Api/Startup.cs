using Api.Extensions;
using Commands.Customers;
using CommandsHandler.Customers;
using Core.Domain.IRepository;
using Core.Repository;
using Core.Utilities.ActionFilter;
using Core.Utilities.ResponseWrapper;
using Domain.DbContext;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
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
            services.AddSqlContext(Configuration);
            services.AddCommandsQueries();
            services.AddRepositories();
            services.AddMvc(options =>
                {
                    options.Filters.Add(typeof(ValidatorActionFilter));
                }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<CreateCustomer>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAPIResponseWrapperMiddleware();
            app.UseMvc();
        }
    }
}
