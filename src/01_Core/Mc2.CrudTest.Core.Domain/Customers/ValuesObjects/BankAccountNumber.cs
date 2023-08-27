using Framework.Core.Domain.Exceptions;
using Framework.Core.Domain.ValueObjects;
using Framework.Core.Utilities.Specifications;
using Mc2.CrudTest.Core.Domain.Customers.Specifications;

namespace Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;

public class BankAccountNumber : BaseValueObject<BankAccountNumber>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static BankAccountNumber FromString(string value) => new BankAccountNumber(value);
    public BankAccountNumber(string value)
    {
        Value = value;

        var validator = new NotValidBankAccountNumberSpecification().And(new NullBankAccountNumberSpecification());
        if (validator.IsSatisfiedBy(this))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(BankAccountNumber));
        }
    }
    private BankAccountNumber()
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
    public static explicit operator string(BankAccountNumber bankAccountNumber) => bankAccountNumber.Value;
    public static implicit operator BankAccountNumber(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion
}
