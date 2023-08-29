using FluentValidation;
using FluentValidation.Validators;
using Mc2.CrudTest.Core.Domain.Customers.Specifications;

namespace Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Create;


public class PhoneNumberValidatation<T, TProperty> : PropertyValidator<T, TProperty>
{

    public override string Name => "PhoneNumberValidator";

    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        var validator = new ValidLibphoneNumberSpecifications();
        return validator.IsSatisfiedBy(value.ToString());
    }

    protected override string GetDefaultMessageTemplate(string errorCode)
      => "'{PropertyName}' is not valid.";
}


public class BankAccountNumberValidation<T, TProperty> : PropertyValidator<T, TProperty>
{

    public override string Name => "BankAccountNumberValidator";

    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        var validator = new ValidBankAccountNumberSpecification();
        var result = validator.IsSatisfiedBy(value.ToString());
        return result;
    }

    protected override string GetDefaultMessageTemplate(string errorCode)
      => "'{PropertyName}' is not valid.";
}

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<T, TElement> PhoneNumberValidator<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new PhoneNumberValidatation<T, TElement>());
    }

    public static IRuleBuilderOptions<T, TElement> BankAccountNumberValidator<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new BankAccountNumberValidation<T, TElement>());
    }
}