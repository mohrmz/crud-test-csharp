using Framework.Core.Contracts.Data.Queries;
using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetById;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetByName;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.Shared;

namespace Mc2.CrudTest.Core.Contracts.Customers.Queries;

public interface ICustomerQueryRepository : IQueryRepository
{
    public Task<CustomerDTO?> ExecuteAsync(GetCustomerByIdQuery query);
    public Task<CustomerDTO?> ExecuteAsync(GetCustomerByNameQuery query);
}
