using Framework.Core.Domain.Exceptions;
using Framework.Core.Domain.ValueObjects;

namespace Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;

public class DateOfBirth : BaseValueObject<DateOfBirth>
{
    #region Properties
    public DateTime Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static DateOfBirth FromString(string value) => new DateOfBirth(value);
    public static DateOfBirth FromDatetime(DateTime value) => new() { Value = value };

    public DateOfBirth(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(DateOfBirth));
        }

        if (DateTime.TryParse(value, out DateTime tempValue))
        {
            Value = tempValue;
        }
        else
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
    public static explicit operator string(DateOfBirth title) => title.Value.ToString();
    public static implicit operator DateOfBirth(string value) => new(value);


    public static explicit operator DateTime(DateOfBirth title) => title.Value;
    public static implicit operator DateOfBirth(DateTime value) => new() { Value = value };
    #endregion

    #region Methods
    public override string ToString() => Value.ToString();

    #endregion
}
