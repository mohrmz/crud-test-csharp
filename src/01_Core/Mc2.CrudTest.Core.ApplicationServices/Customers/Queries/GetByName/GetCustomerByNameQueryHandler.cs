using Framework.Core.ApplicationServices.Queries;
using Framework.Core.RequestResponse.Queries;
using Mc2.CrudTest.Core.Contracts.Customers.Queries;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetByName;

namespace Mc2.CrudTest.Core.ApplicationServices.Customers.Queries.GetByName;

public class GetCustomerByNameQueryHandler : QueryHandler<GetCustomerByNameQuery, CustomerDTO?>
{
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public GetCustomerByNameQueryHandler(ICustomerQueryRepository customerQueryRepository) : base()
    {
        _customerQueryRepository = customerQueryRepository;
    }

    public override async Task<QueryResult<CustomerDTO?>> Handle(GetCustomerByNameQuery query)
    {
        var customer = await _customerQueryRepository.ExecuteAsync(query);

        return Result(customer);
    }

}
