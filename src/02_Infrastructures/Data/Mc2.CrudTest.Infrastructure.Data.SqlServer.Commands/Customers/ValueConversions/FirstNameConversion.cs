using Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Customers.ValueConversions;

public class FirstNameConversion : ValueConverter<FirstName, string>
{
    public FirstNameConversion() : base(c => c.Value, c => FirstName.FromString(c))
    {

    }
}
