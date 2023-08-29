using Mc2.CrudTest.Core.Domain.Customers.Data.Test;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Create;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Update;
using Mc2.CrudTest.Presentation.Test.Shared.Mappers;

namespace Mc2.CrudTest.Core.ApplicationServices.Test.Unit.Customers.ClassFixtures;

public class CustomerFixture : IDisposable
{
    public CreateCustomerCommand CreateCustomer { get; private set; }
    public UpdateCustomerCommand UpdateCustomer { get; private set; }
    public CustomerFixture()
    {
        var fakeCustomer = new FakeCustomer();
        var mapper = MapperConfig.InitializeAutomapper();

        CreateCustomer = mapper.Map<CreateCustomerCommand>(fakeCustomer.Generate()); ;
        UpdateCustomer = mapper.Map<UpdateCustomerCommand>(fakeCustomer.Generate());
    }
    public void Dispose()
    {

    }
}
