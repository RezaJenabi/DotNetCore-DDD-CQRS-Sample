using Domain.Models.Products;

namespace Domain.Models.Orders
{
    public class OrderDetail
    {
        public Order Order { get;protected set; }
        public Product Product { get; protected set; }
        public int Some { get; protected set; }
        public double Amount { get; protected set; }

    }
}