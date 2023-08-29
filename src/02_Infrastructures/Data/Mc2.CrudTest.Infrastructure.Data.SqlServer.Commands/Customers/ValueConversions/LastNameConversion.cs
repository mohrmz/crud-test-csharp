using Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Customers.ValueConversions;

public class LastNameConversion : ValueConverter<LastName, string>
{
    public LastNameConversion() : base(c => c.Value, c => LastName.FromString(c))
    {

    }
}

