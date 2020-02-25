using System.Collections.Generic;
using System.Collections.ObjectModel;
using Domain.Models.CustomerAggregate.Customers;
using Mapster;

namespace Domain.Models.Customers.Customers
{

    public class CustomerCreated 
    {
        private readonly List<Address> _addresses = new List<Address>();
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public ReadOnlyCollection<Address> Addresses => this._addresses.AsReadOnly();

        public static Customer Create(CustomerCreated message)
        {
            var customer = message.Adapt<Customer>();



            return customer;
        }

        //public virtual void Add(AddressCreated address)
        //{
        //    this._addresses.Add(AddressCreated.Create(address));
        //}
    }
}