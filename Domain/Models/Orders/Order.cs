using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.BaseEntities;
using Domain.Models.Customers;
using Domain.Models.Payments;

namespace Domain.Models.Orders
{
    public class Order : BaseEntity, IAggregateRoot
    {
        private readonly List<OrderDetail> _orderDetails = new List<OrderDetail>();
        public Customer Customer { get; protected set; }
        public Payment Payment { get; protected set; }
        public ReadOnlyCollection<OrderDetail> OrderDetails => this._orderDetails.AsReadOnly();
    }
}