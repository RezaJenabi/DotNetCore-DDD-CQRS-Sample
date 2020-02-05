using System;
using Core.Domain.BaseEntities;

namespace Domain.Models.Customers.Addresses
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}
