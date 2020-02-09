using System;
using Mapster;

namespace Domain.Models.Customers.Addresses
{
    public class AddressCreated
    {
        public string City { get; set; }
        public string Country { get; set; }
        public static Address Create(AddressCreated message)
        {
            if (string.IsNullOrEmpty(message.City))
                throw new ArgumentNullException(nameof(message.City));

            if (string.IsNullOrEmpty(message.Country))
                throw new ArgumentNullException(nameof(message.Country));

            var createCustomer = new AddressCreated()
            {
                //Id = Guid.NewGuid(),
                City = message.City,
                Country = message.Country
            };
            var address = createCustomer.Adapt<Address>();
            return address;
        }
    }
}
