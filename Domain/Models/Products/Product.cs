using System;
using Core.Domain.BaseEntities;

namespace Domain.Models.Products
{
    public class Product: BaseEntity , ITrackable, ISoftDelete, IAggregateRoot
    {
        public string Name { get; protected set; }
        public int Quantity { get; protected set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
}
