using System;
using System.Threading.Tasks;
using Core.Commands;
using Core.Common;
using Core.Domain.IRepository;
using Domain.Models.Customers.Customer;
using CreateCustomer = Commands.Customers.CreateCustomer;

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
            var customer = Domain.Models.Customers.Customer.CreateCustomer.Create(message.FirstName, message.LastName, message.Email);
            try
            {
                _customerRepository.Add(customer);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return new Result{Text = "OK"};
        }
    }

    public interface ICreateCustomerHandler
   {
       Task<Result> Handler(CreateCustomer message);
   }

}
