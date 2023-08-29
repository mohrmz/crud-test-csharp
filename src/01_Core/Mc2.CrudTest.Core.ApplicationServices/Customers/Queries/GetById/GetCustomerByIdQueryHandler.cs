using Framework.Core.ApplicationServices.Queries;
using Framework.Core.RequestResponse.Queries;
using Mc2.CrudTest.Core.Contracts.Customers.Queries;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetById;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.Shared;

namespace Mc2.CrudTest.Core.ApplicationServices.Customers.Queries.GetById;


public class GetCustomerByIdQueryHandler : QueryHandler<GetCustomerByIdQuery, CustomerDTO?>
{
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public GetCustomerByIdQueryHandler(ICustomerQueryRepository customerQueryRepository) : base()
    {
        _customerQueryRepository = customerQueryRepository;
    }

    public override async Task<QueryResult<CustomerDTO?>> Handle(GetCustomerByIdQuery query)
    {
        var customer = await _customerQueryRepository.ExecuteAsync(query);

        return Result(customer);
    }

}
