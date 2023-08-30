using Framework.Infrastructures.Data.Queries;
using Mc2.CrudTest.Infrastructure.Data.SqlServer.Queries.Customers;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Queries.Common;


public partial class CustomerQueryDbContext : BaseQueryDbContext
{
    public CustomerQueryDbContext(DbContextOptions<CustomerQueryDbContext> options)
    : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; } = null!;
    public virtual DbSet<OutBoxEventItem> OutBoxEventItems { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server =sql-server; Database = Mc2; User Id =sa; Password= 1qaz!QAZ; MultipleActiveResultSets=true ;TrustServerCertificate=true");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CreatedByUserId).HasMaxLength(50);

            entity.Property(e => e.ModifiedByUserId).HasMaxLength(50);
        });

        modelBuilder.Entity<OutBoxEventItem>(entity =>
        {
            entity.Property(e => e.AccuredByUserId).HasMaxLength(255);

            entity.Property(e => e.AggregateName).HasMaxLength(255);

            entity.Property(e => e.AggregateTypeName).HasMaxLength(500);

            entity.Property(e => e.EventName).HasMaxLength(255);

            entity.Property(e => e.EventTypeName).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
