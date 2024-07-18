using System.Data;
using FluentValidation;
using Para.Data.Migrations;
using Para.Data.Domain;
using CustomerDetail = Para.Data.Domain.CustomerDetail;

// Burada para.data.domain kisminda entityyi gormedi sebebini anlayamadim 
// bundan dolayi CustomerDetail entitysini bu sekilde kullandim

namespace Para.Data.Validation;

public class CustomerDetailValidation : AbstractValidator<CustomerDetail>
{
    public CustomerDetailValidation()
    {
      RuleFor(x=>x.CustomerId)
          .NotEmpty()
          .WithMessage("Enter Customer Id")
          .GreaterThan(0)
          .WithMessage("Customer Id must be greater than 0");

      RuleFor(x => x.Customer)
          .NotEmpty()
          .WithMessage("Enter Customer");

      RuleFor(x=>x.FatherName)
          .NotEmpty()
          .WithMessage("Enter Customer's father name")
          .MinimumLength(5)
          .WithMessage("Customer's father name must be at least 5 characters")
          .MaximumLength(50)
          .WithMessage("Customer's father name must be at most 50 characters");
      
      RuleFor(x=>x.MotherName)
          .NotEmpty()
          .WithMessage("Enter Customer's mother name")
          .MinimumLength(5)
          .WithMessage("Customer's mother name must be at least 5 characters")
          .MaximumLength(50)
          .WithMessage("Customer's mother name must be at most 50 characters");

      RuleFor(x => x.EducationStatus)
          .NotEmpty()
          .WithMessage("Enter Customer's education status")
          .MinimumLength(5)
          .WithMessage("Customer's education status must be at least 5 characters")
          .MaximumLength(100)
          .WithMessage("Customer's education status must be at most 100 characters"); 

      RuleFor(x => x.MontlyIncome)
          .NotEmpty()
          .WithMessage("Enter Customer's monthly income")
          .MinimumLength(5)
          .WithMessage("Customer's monthly income must be at least 5 characters")
          .MaximumLength(100)
          .WithMessage("Customer's monthly income must be at most 100 characters"); 
                 
      RuleFor(x=>x.Occupation)
          .NotEmpty()
          .WithMessage("Enter Customer's occupation")
          .MinimumLength(3)
          .WithMessage("Customer's occupation must be at least 5 characters")
          .MaximumLength(80)
          .WithMessage("Customer's occupation must be at most 80 characters");
    }
    
}