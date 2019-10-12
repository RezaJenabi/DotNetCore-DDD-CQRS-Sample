﻿using Core.Common;
using FluentValidation;

namespace Commands.Customer
{
    public class CreateCustomer : Request<CreateCustomerResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    public class CreateCustomerResult : Result
    {
        public int Id { get; set; }
    }
    public class CreateCustomerValidator : AbstractValidator<CreateCustomer>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage(Resource.Validaton.FirstNameRequired);
            RuleFor(x => x.LastName).NotNull().WithMessage(Resource.Validaton.LastNameRequired);
            RuleFor(x => x.Email).Matches(@"\A(?:[a-z0-9!#$%&'*=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z").WithMessage(Resource.Validaton.EmailFormat);

        }
    }
}
