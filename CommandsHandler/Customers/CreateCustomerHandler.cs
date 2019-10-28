using System.Threading.Tasks;
using Commands.Customers;
using Core.Commands;
using Core.Common;
using Core.Domain.IRepository;
using Domain.Models.Customers;
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
            var customer = message.Adapt<Customer>();
            await _customerRepository.AddAsync(customer);
            return new Result{Text = "OK"};
        }
    }

    public interface ICreateCustomerHandler
   {
       Task<Result> Handler(CreateCustomer message);
   }

}
