using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Customers.ValueConversions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Customers.Configs;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {

        builder.Property(c => c.FirstName).HasColumnType("VARCHAR(100)");
        builder.Property(c => c.LastName).HasColumnType("VARCHAR(100)");
        builder.Property(c => c.PhoneNumber).HasColumnType("VARCHAR(25)");
        builder.Property(c => c.BankAccountNumber).HasColumnType("VARCHAR(34)");
        builder.Property(c => c.Email).HasColumnType("NVARCHAR(320)");
        builder.Property(c => c.DateOfBirth).HasColumnType("datetime2");

        builder.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique();
        builder.HasIndex(c => c.Email).IsUnique();

        builder.Property(c => c.FirstName).HasConversion<FirstNameConversion>();
        builder.Property(c => c.LastName).HasConversion<LastNameConversion>();
        builder.Property(c => c.DateOfBirth).HasConversion<DateOfBirthConversion>();
        builder.Property(c => c.PhoneNumber).HasConversion<PhoneNumberConversion>();
        builder.Property(c => c.Email).HasConversion<EmailConversion>();
        builder.Property(c => c.BankAccountNumber).HasConversion<BankAccountNumberConversion>();
    }

}