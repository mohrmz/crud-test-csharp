using Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Customers.ValueConversions;

public class BankAccountNumberConversion : ValueConverter<BankAccountNumber, string>
{
    public BankAccountNumberConversion() : base(c => c.Value, c => BankAccountNumber.FromString(c))
    {

    }
}
