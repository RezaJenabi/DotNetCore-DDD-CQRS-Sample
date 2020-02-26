using MediatR;

namespace Domain.Models.CustomerAggregate.Events.DomainEvents
{
    public class CustomerCreateEvent : INotification
    {
        public Customer Customer { get; set; }

        public CustomerCreateEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}
