using System;
using Core.BaseEntities;

namespace Domain.Models.Payments
{
    public class Payment: BaseEntity, IAggregateRoot
    {
        public double Amount { get; set; }
    }
}
