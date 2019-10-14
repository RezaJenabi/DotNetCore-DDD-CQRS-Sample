using System.Threading.Tasks;
using Commands.Customers;
using CommandsHandler.Customers;
using Core.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICreateCustomerHandler _createCustomerHandler;

        public CustomersController(ICreateCustomerHandler sendMessageHandler)
        {
            this._createCustomerHandler = sendMessageHandler;
        }

        [HttpPost]
        public Task<Result> Post(CreateCustomer createCustomer)
        {
            if (!ModelState.IsValid)
            {

            }
           return  _createCustomerHandler.Handler(createCustomer);
        }

    }
}
