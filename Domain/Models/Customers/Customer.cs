using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Domain.BaseEntities;
using Domain.Models.Carts;
using Domain.Models.Purchases;

namespace Domain.Models.Customers
{
    public class Customer : BaseEntity , ITrackable, ISoftDelete, IAggregateRoot
    {
        private readonly List<Purchase> _purchases = new List<Purchase>();
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public ReadOnlyCollection<Purchase> Orders => this._purchases.AsReadOnly();
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }

        public Purchase Checkout(Cart cart)
        {
            var purchase = Purchase.Create(this, cart);
            this._purchases.Add(purchase);
            return purchase;
        }

        public static Customer Create(string firstname, string lastname, string email)
        {
            return Create(Guid.NewGuid(), firstname, lastname, email);
        }

        public static Customer Create(Guid id, string firstname, string lastname, string email)
        {
            if (string.IsNullOrEmpty(firstname))
                throw new ArgumentNullException(nameof(firstname));

            if (string.IsNullOrEmpty(lastname))
                throw new ArgumentNullException(nameof(lastname));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            var customer = new Customer()
            {
                Id = id,
                FirstName = firstname,
                LastName = lastname,
                Email = email
            };

            return customer;
        }
    }
}