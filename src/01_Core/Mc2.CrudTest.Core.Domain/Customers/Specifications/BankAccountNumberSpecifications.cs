using Framework.Core.Utilities.Specifications;
using Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Core.Domain.Customers.Specifications
{
    public class NotValidBankAccountNumberSpecification : ISpecification<BankAccountNumber>
    {
        public bool IsSatisfiedBy(BankAccountNumber enitity)
        {
           return !string.IsNullOrWhiteSpace(enitity.Value) ? !Regex.IsMatch(enitity.Value, BankAccountNumberConstants.BankAccountNumberValidRegex) : true;
        }
    }

    public class ValidBankAccountNumberSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string enitity)
        {
            var result = Regex.IsMatch(enitity, BankAccountNumberConstants.BankAccountNumberValidRegex);
            return result;
        }
    }

    public class NullBankAccountNumberSpecification : ISpecification<BankAccountNumber>
    {
        public bool IsSatisfiedBy(BankAccountNumber enitity)
        {
            return string.IsNullOrEmpty(enitity.Value);
        }
    }

    public class BankAccountNumberConstants
    {
        public const string BankAccountNumberValidRegex = "^[A-Z]{2}[0-9]{2}[A-Z0-9]{1,30}$";
    }
}
