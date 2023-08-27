using FluentValidation;

namespace Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetByName;

public class GetCustomerByNameQueryValidator : AbstractValidator<GetCustomerByNameQuery>
{
    public GetCustomerByNameQueryValidator()
    {
        RuleFor(query => query.FirstName)
            .NotEmpty()
            .WithMessage("FirstName is required");

        RuleFor(query => query.LastName)
            .NotEmpty()
            .WithMessage("LastName is required");
    }
}
