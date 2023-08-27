using Framework.Core.Utilities.Specifications;
using Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Core.Domain.Customers.Specifications
{
    public class NotValidBankAccountNumberSpecification : ISpecification<BankAccountNumber>
    {
        public bool IsSatisfiedBy(BankAccountNumber enitity)
        {
           return  !Regex.IsMatch(enitity.Value, "((\\d{4})-){3}\\d{4}");
        }
    }

    public class ValidBankAccountNumberSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string enitity)
        {
            return Regex.IsMatch(enitity, "((\\d{4})-){3}\\d{4}");
        }
    }

    public class NullBankAccountNumberSpecification : ISpecification<BankAccountNumber>
    {
        public bool IsSatisfiedBy(BankAccountNumber enitity)
        {
            return string.IsNullOrEmpty(enitity.Value);
        }
    }
}
