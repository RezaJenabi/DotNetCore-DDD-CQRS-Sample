using System;
using Core.BaseEntities;

namespace Domain.Models.Products
{
    public class Product:BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
