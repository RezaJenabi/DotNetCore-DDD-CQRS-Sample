using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.BaseEntities;
using Domain.Models.Orders;

namespace Domain.Models.Customers
{
    public class Customer : BaseEntity , ITrackable, ISoftDelete, IAggregateRoot
    {
        private readonly List<Order> _orders = new List<Order>();
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public ReadOnlyCollection<Order> Orders => this._orders.AsReadOnly();

        //public Purchase Checkout(Cart cart)
        //{
        //    Purchase purchase = Purchase.Create(this, cart.Products);
        //    this.purchases.Add(purchase);
        //    DomainEvents.Raise(new CustomerCheckedOut() { Purchase = purchase });
        //    return purchase;
        //}

        public static Customer Create(string firstName, string lastName, string email)
        {
            var customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
            return customer;
        }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
}