using Core.Common;

namespace Queries.Customers
{
    public class CustomersQueries : Request<CustomersQueriesResult>
    {
        public string FirstName { get; set; }
    }
    public class CustomersQueriesResult : Result
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
