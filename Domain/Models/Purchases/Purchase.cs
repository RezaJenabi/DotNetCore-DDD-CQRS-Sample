using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Core.Domain.BaseEntities;
using Domain.Models.Carts;
using Domain.Models.Customers;
using Domain.Models.Products;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Domain.Models.Purchases
{
    public class Purchase : BaseEntity, ITrackable, ISoftDelete, IAggregateRoot
    {
        private List<Cart> _carts = new List<Cart>();

        public ReadOnlyCollection<Cart> Carts => _carts.AsReadOnly();
        public Customer Customer { get; protected set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }

        public static Purchase Create(Customer customer, Cart cart)
        {
            var purchase = new Purchase()
            {
                Id = Guid.NewGuid(),
                Customer = customer
            };
            purchase._carts.Add(cart);
            cart.Set(purchase);
            return purchase;
        }

        public virtual void Add(Cart cart)
        {
            if (cart == null)
                throw new ArgumentNullException();
            this._carts.Add(cart);
        }

       
        public virtual void Clear()
        {
            this._carts.Clear();
        }

    }
}
