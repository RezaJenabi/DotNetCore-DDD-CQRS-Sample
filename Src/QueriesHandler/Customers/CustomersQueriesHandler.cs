using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Queries;
using Queries.Customers;

namespace QueriesHandler.Customers
{
    public class CustomersQueriesHandler : ListMessageHandler<CustomersQueries, CustomersQueriesResult>, ICustomersQueriesHandler
    {
        public override async Task<IList<CustomersQueriesResult>> Handler(CustomersQueries message)
        {
            var data= new CustomersQueriesResult();
            //get customers
            return null;
        }
    }

    public interface ICustomersQueriesHandler
    {
       Task<IList<CustomersQueriesResult>> Handler(CustomersQueries message);
   }

}
