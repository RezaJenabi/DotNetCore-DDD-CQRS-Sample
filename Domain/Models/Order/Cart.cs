using System;
using Core.BaseEntities;

namespace Domain.Models.Order
{
    public class Cart : BaseEntity, ITrackable
    {
        public Customer.Customer Customer { get; protected set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}