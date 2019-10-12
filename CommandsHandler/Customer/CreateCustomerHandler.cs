using Commands;
using Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Commands.Customer;

namespace CommandsHandler.Customer
{
   public class CreateCustomerHandler : MessageHandler<CreateCustomer, CreateCustomerResult>, ICreateCustomerHandler
    {
        public override async Task<CreateCustomerResult> Handler(CreateCustomer message)
        {
           //Add customer
            return null;
        }
    }

   public interface ICreateCustomerHandler
   {
       Task<CreateCustomerResult> Handler(CreateCustomer message);
   }

}
