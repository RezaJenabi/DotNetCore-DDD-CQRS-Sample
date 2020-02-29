using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Domain.Models.CustomerAggregate
{
    [Owned]
    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public bool IsActive { get; private set; }
        private Address() { }
    }
}
