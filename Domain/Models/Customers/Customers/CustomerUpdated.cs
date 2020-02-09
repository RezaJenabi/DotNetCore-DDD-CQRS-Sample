using System;
using Core.Domain.BaseEntities;

namespace Domain.Models.Customers.Customers
{

    public class CustomerUpdated : ITrackable
    {
        //private readonly List<Address> _addresses = new List<Address>();
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        //public ReadOnlyCollection<Address> Addresses => this._addresses.AsReadOnly();
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public static CustomerUpdated Update(Guid id, string firstname, string lastname, string email)
        {
            if (string.IsNullOrEmpty(firstname))
                throw new ArgumentNullException(nameof(firstname));

            if (string.IsNullOrEmpty(lastname))
                throw new ArgumentNullException(nameof(lastname));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            var customer = new CustomerUpdated()
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email
            };

            return customer;
        }
    }
}