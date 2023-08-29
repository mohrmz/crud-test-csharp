using Framework.Infrastructures.Data.Queries;
using Mc2.CrudTest.Core.Contracts.Customers.Queries;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetById;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetByName;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.Shared;
using Mc2.CrudTest.Infrastructure.Data.SqlServer.Queries.Common;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Queries.Customers;

public class CustomerQueryRepository : BaseQueryRepository<CustomerQueryDbContext>, ICustomerQueryRepository
{
    public CustomerQueryRepository(CustomerQueryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<CustomerDTO?> ExecuteAsync(GetCustomerByNameQuery query)
        => await _dbContext.Customers.Select(c => new CustomerDTO()
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            DateOfBirth = c.DateOfBirth,
            PhoneNumber = c.PhoneNumber,
            Email = c.Email,
            BankAccountNumber = c.BankAccountNumber
        }).FirstOrDefaultAsync(c => c.FirstName.Equals(query.FirstName) || c.LastName.Equals(query.LastName));

    public async Task<CustomerDTO?> ExecuteAsync(GetCustomerByIdQuery query)
        => await _dbContext.Customers.Select(c => new CustomerDTO()
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            DateOfBirth = c.DateOfBirth,
            PhoneNumber = c.PhoneNumber,
            Email = c.Email,
            BankAccountNumber = c.BankAccountNumber
        }).FirstOrDefaultAsync(c => c.Id.Equals(query.Id));
}