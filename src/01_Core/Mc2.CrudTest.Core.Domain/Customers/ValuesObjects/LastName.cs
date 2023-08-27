using Framework.Core.Domain.Exceptions;
using Framework.Core.Domain.ValueObjects;

namespace Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;

public class LastName : BaseValueObject<LastName>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static LastName FromString(string value) => new LastName(value);

    public LastName(string value)
    {
        Value = value;

        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(LastName));
        }      
    }
    private LastName()
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
    public static explicit operator string(LastName LastName) => LastName.Value;
    public static implicit operator LastName(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion
}

