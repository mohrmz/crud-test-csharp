using Framework.Core.Domain.Exceptions;
using Framework.Core.Domain.ValueObjects;

namespace Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;

public class FirstName : BaseValueObject<FirstName>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static FirstName FromString(string value) => new FirstName(value);

    public FirstName(string value)
    {
        Value = value;

        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(FirstName));
        }      
    }
    private FirstName()
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
    public static explicit operator string(FirstName firstName) => firstName.Value;
    public static implicit operator FirstName(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion
}
