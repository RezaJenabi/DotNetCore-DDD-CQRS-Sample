using System.Collections.Generic;
using Api;
using Api.Controllers;
using Commands.Customers;
using CommandsHandler.Customers;
using Core.Domain.IRepository;
using Core.Repository;
using Domain.DbContext;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class CustomersTest
    {
        private readonly ICreateCustomerHandler _createCustomerHandler;
        private readonly CustomersController _customersController;
     

        public CustomersTest()
        {

            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
            _createCustomerHandler = webHost.Services.GetService<ICreateCustomerHandler>();
        }
        [TestMethod]
        public void createCustomerTest()
        {
            var createCustomer = new CreateCustomer()
            {
                Email = "jenabireza@gmail.com",
                FirstName = "Reza",
                LastName = "Jenabi",
            };
            _createCustomerHandler.Handler(createCustomer);
        }
    }
}
