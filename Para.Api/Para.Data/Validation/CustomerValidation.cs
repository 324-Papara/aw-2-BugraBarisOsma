using FluentValidation;
using Para.Data.Domain;

namespace Para.Data.Validation;

public class CustomerValidation : AbstractValidator<Customer>
{
    public CustomerValidation()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Enter Customer's first name")
            .MinimumLength(5)
            .WithMessage("Customer's firstname must be at least 5 characters")
            .MaximumLength(25)
            .WithMessage("Customer's firstname must be at most 25 characters");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Enter Customer's last name")
            .MinimumLength(5)
            .WithMessage("Customer's last name must be at least 5 characters")
            .MaximumLength(25)
            .WithMessage("Customer's last name must be at most 25 characters");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Enter Customer's email")
            .EmailAddress()
            .WithMessage("Customer's email must be a valid email address");

        RuleFor(x => x.CustomerNumber)
            .NotEmpty()
            .WithMessage("Enter Customer's number")
            .GreaterThan(0)
            .WithMessage("Customer's number must be greater than 0");
        
        RuleFor(x => x.IdentityNumber)
            .NotEmpty()
            .WithMessage("Enter Customer's identity number")
            .MinimumLength(11)
            .WithMessage("Customer's identity number must be at least 11 characters")
            .MaximumLength(11)
            .WithMessage("Customer's identity number must be at most 11 characters");
        
        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .WithMessage("Enter Customer's date of birth")
            .LessThan(DateTime.Now)
            .WithMessage("Customer's date of birth must be less than today");
    }
}