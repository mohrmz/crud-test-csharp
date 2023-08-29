using Bogus;

namespace Mc2.CrudTest.Core.Domain.Customers.Data.Test;

public class FakeCustomer
{
    public FakeCustomer()
    {
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = "+441174960123";
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }

    public FakeCustomer Generate()
    {
        var customerFaker = new Faker<FakeCustomer>()
               .RuleFor(o => o.FirstName, f => f.Person.FirstName).
                RuleFor(o => o.LastName, f => f.Person.LastName).
                RuleFor(o => o.DateOfBirth, f => f.Person.DateOfBirth.ToString()).
                RuleFor(o => o.Email, f => f.Internet.Email()).
                RuleFor(o => o.BankAccountNumber, f => f.Finance.Iban());
        return customerFaker.Generate();
    }
}
