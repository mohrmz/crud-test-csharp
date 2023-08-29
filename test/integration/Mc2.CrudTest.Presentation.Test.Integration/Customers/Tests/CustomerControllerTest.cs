using FluentAssertions;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Create;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Delete;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Update;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.Shared;
using Mc2.CrudTest.Presentation.Server;
using Mc2.CrudTest.Presentation.Test.Integration.Customers.ClassFixtures;
using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using System.Security.Policy;
using Xunit.Priority;

namespace Mc2.CrudTest.Presentation.Test.Integration.Customers.Tests;


[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class CustomerControllerTest : IClassFixture<CustomerFixture>
{
    private readonly RESTFulApiFactoryClient _client;
    private readonly CustomerFixture _customerFixture;
    public CustomerControllerTest(CustomerFixture customerFixture)
    {
        var factory = new WebApplicationFactory<Program>();
        var httpClient = factory.CreateClient();
        _client = new RESTFulApiFactoryClient(httpClient);
        _customerFixture = customerFixture;
    }

    [Fact, Priority(1)]
    public async Task Should_CreateNewCustomer()
    {
        //Arrange


        //Act
        var result = await _client.PostContentAsync<CreateCustomerCommand, Guid>(_customerFixture.CreateCustomer.Path, _customerFixture.CreateCustomer);

        //Assert
        result.Should().NotBeEmpty();
    }

    [Fact, Priority(2)]
    public async Task Should_GetCustomers()
    {
        //Arrange
        var url = $"{_customerFixture.GetCustomerByNameQuery.Path}?FirstName={_customerFixture.CreateCustomer.FirstName}&LastName={_customerFixture.CreateCustomer.LastName}";

        //Act
        var result = await _client.GetContentAsync<CustomerDTO>(url);
        _customerFixture.UpdateCustomer.SetUpdateCustomerId(result.Id);

        //Assert
        result.Should().NotBeNull();
    }


    [Fact, Priority(3)]
    public async Task Should_UpdateCustomer()
    {
        //Arrange
        var url = $"{_customerFixture.GetCustomerByIdQuery.Path}?Id={_customerFixture.UpdateCustomer.Id}";

        //Act
        await _client.PutContentAsync<UpdateCustomerCommand>(_customerFixture.UpdateCustomer.Path, _customerFixture.UpdateCustomer);
        var result = await _client.GetContentAsync<CustomerDTO>(url);

        //Assert
        result.Id.Should().Be(_customerFixture.UpdateCustomer.Id);
        result.FirstName.Should().Be(_customerFixture.UpdateCustomer.FirstName);
        result.LastName.Should().Be(_customerFixture.UpdateCustomer.LastName);
        result.DateOfBirth.ToString().Should().Be(_customerFixture.UpdateCustomer.DateOfBirth);
        result.PhoneNumber.Should().Be(_customerFixture.UpdateCustomer.PhoneNumber);
        result.Email.Should().Be(_customerFixture.UpdateCustomer.Email);
        result.BankAccountNumber.Should().Be(_customerFixture.UpdateCustomer.BankAccountNumber);
    }

    [Fact, Priority(4)]
    public async Task Should_DeleteCustomer()
    {
        //Arrange
        var command = new DeleteCustomerCommand
        {
            Id = _customerFixture.UpdateCustomer.Id
        };
        var urlDelete = $"{command.Path}/{command.Id}";
        var urlGetById = $"{_customerFixture.GetCustomerByIdQuery.Path}?Id={_customerFixture.UpdateCustomer.Id}";

        //Act   
        await _client.DeleteContentAsync<DeleteCustomerCommand>(urlDelete);
        var result = await _client.GetContentAsync<CustomerDTO>(urlGetById);

        ////Assert
        result.Should().BeNull();
    }
}