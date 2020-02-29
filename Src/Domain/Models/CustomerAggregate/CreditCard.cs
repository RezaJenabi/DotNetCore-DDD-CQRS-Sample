using System;
using System.Linq;

namespace Domain.Models.CustomerAggregate
{
    public class CreditCard
    {
        public string NameOnCard { get; private set; }
        public string CardNumber { get; private set; }
        public bool Active { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Expiry { get; private set; }
        private CreditCard()
        {

        }

        public CreditCard(string name, string cardNum, DateTime expiry)
        {


            if (string.IsNullOrEmpty(name))
                throw new Exception("Name can't be empty");

            if (string.IsNullOrEmpty(cardNum) || cardNum.Length < 6)
                throw new Exception("Card number length is incorrect");

            if (DateTime.Now > expiry)
                throw new Exception("Credit card expiry can't be in the past");

            NameOnCard = name;
            CardNumber = cardNum;
            Expiry = expiry;
            Active = true;
            Created = DateTime.Today;


        }

        public override bool Equals(object obj)
        {
            CreditCard creditCardToCompare = obj as CreditCard;
            if (creditCardToCompare == null)
                throw new Exception("Can't compare two different objects to each other");

            return CardNumber == creditCardToCompare.CardNumber &&
                Expiry == creditCardToCompare.Expiry;
        }
    }
}
