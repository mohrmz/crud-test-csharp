using Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Customers.ValueConversions;

public class DateOfBirthConversion : ValueConverter<DateOfBirth, DateTime>
{
    public DateOfBirthConversion() : base(c => c.Value, c => DateOfBirth.FromDatetime(c))
    {

    }
}
