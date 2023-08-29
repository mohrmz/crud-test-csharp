using Framework.Infrastructures.Data.Commands;
using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Customers.Configs;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Common;

public class CustomerCommandDbContext : BaseOutboxCommandDbContext
{
    public DbSet<Customer> Customers { get; set; }
    public CustomerCommandDbContext(DbContextOptions<CustomerCommandDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CustomerConfig());
        base.OnModelCreating(builder);
    }
}
