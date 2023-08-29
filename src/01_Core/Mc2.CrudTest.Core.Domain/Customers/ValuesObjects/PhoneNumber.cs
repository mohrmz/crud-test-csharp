using Framework.Core.Domain.Exceptions;
using Framework.Core.Domain.ValueObjects;
using Mc2.CrudTest.Core.Domain.Customers.Specifications;

namespace Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;

public class PhoneNumber : BaseValueObject<PhoneNumber>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static PhoneNumber FromString(string value) => new PhoneNumber(value);

    public PhoneNumber(string value)
    {
        Value = value;

        var validator = new NotValidLibphoneNumberSpecifications();
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(PhoneNumber));
        }

        if (validator.IsSatisfiedBy(this))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(PhoneNumber));
        }
    }
    private PhoneNumber()
    {

    }
    #endregion


    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;
    public static implicit operator PhoneNumber(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion
}

