using System;
using System.Threading.Tasks;
using Commands.Customers;
using Core.Commands;
using Core.Common;
using Core.Domain.IRepository;
using Domain.Models.CustomerAggregate.Customers;
using Domain.Models.Customers.Customers;
using Mapster;

namespace CommandsHandler.Customers
{
    public class CreateCustomerHandler : MessageHandler<CreateCustomer, Result>, ICreateCustomerHandler
    {
        private readonly IRepository<Customer> _customerRepository;
        public CreateCustomerHandler(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public override async Task<Result> Handler(CreateCustomer message)
        {
            try
            {
                var customerCreated = message.Adapt<CustomerCreated>();
                var customer = CustomerCreated.Create(customerCreated);
                _customerRepository.Add(customer);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return new Result { Text = "OK" };
        }
    }

    public interface ICreateCustomerHandler
    {
        Task<Result> Handler(CreateCustomer message);
    }

}
