using Framework.Core.Domain.Exceptions;
using Framework.Core.Domain.ValueObjects;

namespace Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;

public class DateOfBirth : BaseValueObject<DateOfBirth>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static DateOfBirth FromString(string value) => new DateOfBirth(value);

    public DateOfBirth(string value)
    {
        Value = value;
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(DateOfBirth));
        }
    }
    private DateOfBirth()
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
    public static explicit operator string(DateOfBirth DateOfBirth) => DateOfBirth.Value;
    public static implicit operator DateOfBirth(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion
}
