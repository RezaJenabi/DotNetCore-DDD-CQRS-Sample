using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using Core.Domain.BaseEntities;
using Domain.Models.Customers;
using Domain.Models.Products;
using Domain.Models.Purchases;

namespace Domain.Models.Carts
{
    public class Cart : BaseEntity, ITrackable, ISoftDelete, IAggregateRoot
    {
        private List<Product> _products = new List<Product>();
        public Purchase Purchase { get; protected set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }

        public ReadOnlyCollection<Product> Products
            => this._products.AsReadOnly();

        public static Cart Create(List<Product> products) 
            => new Cart {_products = products };

        public void Set(Purchase purchase)
            => Purchase = purchase;


    }
}
