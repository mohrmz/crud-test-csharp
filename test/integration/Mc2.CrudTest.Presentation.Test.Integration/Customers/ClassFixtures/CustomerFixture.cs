using Mc2.CrudTest.Core.Domain.Customers.Data.Test;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Create;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Delete;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Update;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetById;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetByName;
using Mc2.CrudTest.Presentation.Test.Shared.Mappers;

namespace Mc2.CrudTest.Presentation.Test.Integration.Customers.ClassFixtures;

public class CustomerFixture : IDisposable
{
    public CreateCustomerCommand CreateCustomer { get; private set; }
    public UpdateCustomerCommand UpdateCustomer { get; private set; }
    public GetCustomerByNameQuery GetCustomerByNameQuery { get; private set; }
    public GetCustomerByIdQuery GetCustomerByIdQuery { get; private set; }
    public CustomerFixture()
    {
        var fakeCustomer = new FakeCustomer();
        var mapper = MapperConfig.InitializeAutomapper();

        CreateCustomer = mapper.Map<CreateCustomerCommand>(fakeCustomer.Generate());
        UpdateCustomer = mapper.Map<UpdateCustomerCommand>(fakeCustomer.Generate());
        GetCustomerByNameQuery = new GetCustomerByNameQuery();
        GetCustomerByIdQuery = new GetCustomerByIdQuery();
    }
    public void Dispose()
    {

    }
}

public static class Extensions
{
    public static void SetUpdateCustomerId(this UpdateCustomerCommand updateCustomer, int id)
    {
        updateCustomer.Id = id;
    }
}

