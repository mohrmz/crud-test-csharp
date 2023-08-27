using Mc2.CrudTest.Core.Domain.Customers.Data.Test;

namespace Mc2.CrudTest.Core.Domain.Test.Unit.Customers.ClassFixtures
{
    public class FakeCustomerFixture : IDisposable
    {
        public FakeCustomer FakeCustomer { get; init; }

        public FakeCustomerFixture()
        {
            var faker = new FakeCustomer();
            FakeCustomer = faker.Generate();
        }

        public void Dispose()
        {

        }
    }
}
