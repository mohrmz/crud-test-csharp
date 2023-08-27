using Framework.Core.Contracts.Data.Commands;
using Mc2.CrudTest.Core.Domain.Customers.Entities;

namespace Mc2.CrudTest.Core.Contracts.Customers.Commands;

public interface ICustomerCommandRepository : ICommandRepository<Customer, int>
{
}
