using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.BaseEntities;
using Domain.Models.Orders;
using Domain.Models.Payments;

namespace Domain.Models.Customers
{
    public class Customer : BaseEntity , ITrackable, ISoftDelete, IAggregateRoot
    {
        private readonly List<Order> _orders = new List<Order>();
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public ReadOnlyCollection<Order> Orders => this._orders.AsReadOnly();
        public void Checkout(Order order, Payment payment)
        {
            var orderItem = new Order(this, payment);
            _orders.Add(orderItem);
        }

        //public Purchase Checkout(Order order) 
        //{
        //    Purchase purchase = Purchase.Create(this, cart.Products);
        //    this.purchases.Add(purchase);
        //    DomainEvents.Raise(new CustomerCheckedOut() { Purchase = purchase });
        //    return purchase;
        //}

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }

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