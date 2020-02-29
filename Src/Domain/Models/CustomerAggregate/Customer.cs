using Core.Domain.BaseEntities;
using Domain.Models.CustomerAggregate.Events.DomainEvents;
using eCommerce.Helpers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models.CustomerAggregate
{

    public class Customer : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }

        //public Address Address { get; private set; }

        //private readonly List<CreditCard> _creditCards;

        //public IReadOnlyCollection<CreditCard> CreditCards => _creditCards;

        private Customer()
        {

        }

        public Customer(string fistName, string lastName, string email, Address address)
        {
            FirstName = fistName;
            LastName = lastName;
            Email = email;
            //Address = address;
            this.AddDomainEvent(new CustomerCreateEvent(this));

        }

        public void AddCreditCard(string name, string cardNum, DateTime expiry)
        {
            //var existingOrderForProduct = _creditCards.Where(o => o.CardNumber == cardNum)
            //    .SingleOrDefault();

            //if (existingOrderForProduct != null)
            //{
            //    //if previous line exist modify it with higher discount  and units..

            //    //if (discount > existingOrderForProduct.GetCurrentDiscount())
            //    //{
            //    //    existingOrderForProduct.SetNewDiscount(discount);
            //    //}

            //    //existingOrderForProduct.AddUnits(units);
            //}
            //else
            //{
            //    //add validated new order item

            //    var creditCard = new CreditCard(name, cardNum, expiry);
            //    _creditCards.Add(creditCard);
            //}
        }

    }
}