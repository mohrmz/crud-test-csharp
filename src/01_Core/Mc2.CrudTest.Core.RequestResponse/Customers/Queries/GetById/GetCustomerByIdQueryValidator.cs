using FluentValidation;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetByName;

namespace Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetById;

internal class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .WithMessage("Id is required");

    }
}