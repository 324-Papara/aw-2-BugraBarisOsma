using FluentValidation;
using Para.Data.Domain;

namespace Para.Data.Validation;

public class CustomerPhoneValidation : AbstractValidator<CustomerPhone>
{
    public CustomerPhoneValidation()
    {
        RuleFor(x=>x.CustomerId)
            .NotEmpty()
            .WithMessage("Enter Customer Id")
            .GreaterThan(0)
            .WithMessage("Customer Id must be greater than 0");
         
         
        RuleFor(x=>x.Customer)
            .NotEmpty()
            .WithMessage("Address must be linked to a customer");
        

        RuleFor(x=>x.CountyCode)
            .NotEmpty()
            .WithMessage("Enter County Code")
            .MaximumLength(3)
            .WithMessage("County Code maximum length is 3");
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Enter Phone")
            .MinimumLength(10)
            .WithMessage("Phone must be at least 10 characters");
        RuleFor(x=>x.IsDefault)
            .NotEmpty()
            .WithMessage("Valid if this is default phone");
    }
}