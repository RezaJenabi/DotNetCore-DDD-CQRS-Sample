using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Domain.BaseEntities;
using Domain.Models.Customers.Addresses;
using Mapster;

namespace Domain.Models.Customers.Customers
{

    public class CustomerCreated : ITrackable
    {
        private readonly List<Address> _addresses = new List<Address>();
        public Guid Id { get; set; }
        public string FirstName {
            get => "2";
            protected set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));
            }
        } 
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public ReadOnlyCollection<Address> Addresses => this._addresses.AsReadOnly();
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public static Customer Create(CustomerCreated message)
        {
            var customer = message.Adapt<Customer>();
            return customer;
        }

        public virtual void Add(AddressCreated address)
        {
            this._addresses.Add(AddressCreated.Create(address));
        }
    }
}