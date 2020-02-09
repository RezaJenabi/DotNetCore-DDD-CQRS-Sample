using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Domain.BaseEntities;
using Domain.Models.Customers.Addresses;

namespace Domain.Models.Customers.Customers
{

    public class Customer : BaseEntity , ITrackable, ISoftDelete, IAggregateRoot
    {
        private readonly List<Address> _addresses = new List<Address>();
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public ReadOnlyCollection<Address> Addresses => this._addresses.AsReadOnly();
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
}