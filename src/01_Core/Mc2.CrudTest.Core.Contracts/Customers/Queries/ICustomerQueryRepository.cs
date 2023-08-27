using Framework.Core.Contracts.Data.Queries;
using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetByName;

namespace Mc2.CrudTest.Core.Contracts.Customers.Queries;

public interface ICustomerQueryRepository : IQueryRepository<Customer, int>
{
    public Task<CustomerDTO?> ExecuteAsync(GetCustomerByNameQuery query);
}
