using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Domain.BaseEntities;
using Domain.Models.Customers.Addresses;
using Mapster;

namespace Domain.Models.Customers.Customer
{

    public class CreateCustomer : ITrackable
    {
        //private readonly List<Address> _addresses = new List<Address>();
        public Guid Id { get; set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        //public ReadOnlyCollection<Address> Addresses => this._addresses.AsReadOnly();
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public static Customer Create(string firstname, string lastname, string email)
        {
            if (string.IsNullOrEmpty(firstname))
                throw new ArgumentNullException(nameof(firstname));

            if (string.IsNullOrEmpty(lastname))
                throw new ArgumentNullException(nameof(lastname));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            var createCustomer = new CreateCustomer()
            {
                Id=Guid.NewGuid(),
                FirstName = firstname,
                LastName = lastname,
                Email = email
            };
            var customer = createCustomer.Adapt<Customer>();
            return customer;
        }
    }
}