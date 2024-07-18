using FluentValidation;
using Para.Data.Domain;

namespace Para.Data.Validation;

public class CustomerAddressValidation : AbstractValidator<CustomerAddress>
{

    public CustomerAddressValidation()
    {
        RuleFor(x=>x.AddressLine)
            .NotEmpty()
            .WithMessage("Enter Customer's address")
            .MinimumLength(5)
            .WithMessage("Customer's address must be at least 5 characters")
            .MaximumLength(250)
            .WithMessage("Customer's address must be at most 250 characters");

        RuleFor(x=>x.ZipCode)
            .NotEmpty()
            .WithMessage("Enter Customer's zipcode")
            .MinimumLength(5)
            .WithMessage("Customer's zipcode must be at least 5 characters")
            .MaximumLength(5)
            .WithMessage("Customer's zipcode must be at most 5 characters");
        
        RuleFor(x=>x.City)
            .NotEmpty()
            .WithMessage("Enter a City")
            .MinimumLength(3)
            .WithMessage("City must be at least 3 characters")
            .MaximumLength(50)
            .WithMessage("City must be at most 50 characters");

        RuleFor(x=>x.Country)
            .NotEmpty()
            .WithMessage("Enter a Country")
            .MinimumLength(3)
            .WithMessage("Country must be at least 3 characters")
            .MaximumLength(50)
            .WithMessage("Country must be at most 50 characters");
         
         RuleFor(x=>x.CustomerId)
            .NotEmpty()
            .WithMessage("Enter Customer Id")
            .GreaterThan(0)
            .WithMessage("Customer Id must be greater than 0");
         
         
         RuleFor(x=>x.Customer)
             .NotEmpty()
             .WithMessage("Address must be linked to a customer");
         
         RuleFor(x=>x.IsDefault)
             .NotEmpty()
             .WithMessage("Valid if this is default phone");
    }
}