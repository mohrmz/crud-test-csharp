using FluentValidation;
using Mc2.CrudTest.Core.Domain.Customers.Specifications;

namespace Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        var bankAccountValidator = new ValidBankAccountNumberSpecification();
        var phoneNumberValidator = new ValidLibphoneNumberSpecifications();

        RuleFor(c => c.FirstName)
       .NotNull()
       .WithMessage("FirstName is required");

        RuleFor(c => c.LastName)
       .NotNull()
       .WithMessage("LastName is required");

        RuleFor(c => c.DateOfBirth)
       .NotNull()
       .WithMessage("DateOfBirth is required");

        RuleFor(c => c.PhoneNumber)
       .PhoneNumberValidator()
       .NotNull()
       .WithMessage("PhoneNumber is required");

        RuleFor(c => c.Email)
        .NotNull()
        .WithMessage("Email is required")
        .EmailAddress()
        .WithMessage("Invalid email format");

        RuleFor(c => c.BankAccountNumber)
       .BankAccountNumberValidator()
       .NotNull()
       .WithMessage("BankAccountNumber is required");
    }
}
