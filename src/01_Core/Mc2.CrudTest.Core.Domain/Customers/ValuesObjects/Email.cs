using Framework.Core.Domain.Exceptions;
using Framework.Core.Domain.ValueObjects;
using Mc2.CrudTest.Core.Domain.Customers.Specifications;

namespace Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;

public class Email : BaseValueObject<Email>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static Email FromString(string value) => new Email(value);

    public Email(string value)
    {
        Value = value;

        var validator = new NotValidEmailSpecification();

        if(string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(Email));
        }

        if (validator.IsSatisfiedBy(this))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(Email));
        }
    }
    private Email()
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
    public static explicit operator string(Email email) => email.Value;
    public static implicit operator Email(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion
}
