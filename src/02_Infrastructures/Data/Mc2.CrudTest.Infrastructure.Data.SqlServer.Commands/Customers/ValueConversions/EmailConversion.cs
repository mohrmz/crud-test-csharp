using Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Customers.ValueConversions;


public class EmailConversion : ValueConverter<Email, string>
{
    public EmailConversion() : base(c => c.Value, c => Email.FromString(c))
    {

    }
}