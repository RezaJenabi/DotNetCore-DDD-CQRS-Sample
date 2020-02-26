using eCommerce.Helpers.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.CustomerAggregate.Events.DomainEvents
{
    public class CustomerCreateEvent : DomainEvent
    {
        public Customer Customer { get; set; }

        public override void Flatten()
        {
            this.Args.Add("FirstName", this.Customer.FirstName);
            this.Args.Add("LastName", this.Customer.LastName);
            this.Args.Add("Email", this.Customer.Email);
            this.Args.Add("IsActive", this.Customer.IsActive);
        }
    }
}
