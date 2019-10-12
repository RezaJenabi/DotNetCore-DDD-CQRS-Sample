using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commands.Customer;
using CommandsHandler.Customer;
using Core.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        // POST api/values
        [HttpPost]
        public Task<CreateCustomerResult> Post(CreateCustomer createCustomer)
            => _createCustomerHandler.Handler(createCustomer);
    }
}
