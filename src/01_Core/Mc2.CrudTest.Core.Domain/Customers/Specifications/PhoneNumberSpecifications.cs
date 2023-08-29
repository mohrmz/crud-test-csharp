using Framework.Core.Utilities.Specifications;
using Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;

namespace Mc2.CrudTest.Core.Domain.Customers.Specifications;

public class NotValidLibphoneNumberSpecifications : ISpecification<PhoneNumber>
{

    public bool IsSatisfiedBy(PhoneNumber enitity)
    {
        var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
        return !phoneNumberUtil.IsValidNumber(phoneNumberUtil.Parse(enitity.Value, "ZZ"));
    }
}

public class ValidLibphoneNumberSpecifications : ISpecification<string>
{

    public bool IsSatisfiedBy(string enitity)
    {
        var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
        var phone = phoneNumberUtil.Parse(enitity, "ZZ");
        var result = phoneNumberUtil.IsValidNumber(phone);
        return result;
    }
}