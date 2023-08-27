using Framework.Core.Utilities.Specifications;
using Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Core.Domain.Customers.Specifications;

public class NotValidEmailSpecification : ISpecification<Email>
{
    public bool IsSatisfiedBy(Email enitity)
    {
        var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

        var regex = new Regex(pattern);
        return !regex.IsMatch(enitity.Value);
    }
}
