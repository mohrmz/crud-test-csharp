using Framework.Infrastructures.Data.Commands;
using Mc2.CrudTest.Core.Contracts.Customers.Commands;
using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Common;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Customers;

public class CustomerCommandRepository :
        BaseCommandRepository<Customer, CustomerCommandDbContext, int>,
        ICustomerCommandRepository
{
    public CustomerCommandRepository(CustomerCommandDbContext dbContext) : base(dbContext)
    {
    }

}