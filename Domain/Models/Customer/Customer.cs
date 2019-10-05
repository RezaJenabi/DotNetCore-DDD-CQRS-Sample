using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Domain.Models.Order;

namespace Domain.Models.Customer
{
    public class Customer
    {
        private readonly List<Cart> _purchases = new List<Cart>();


        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public ReadOnlyCollection<Cart> Purchases => this._purchases.AsReadOnly();

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
    }
}