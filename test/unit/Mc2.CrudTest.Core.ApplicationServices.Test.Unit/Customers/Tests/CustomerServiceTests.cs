using FluentAssertions;
using Framework.Core.Common;
using Framework.Core.Domain.Exceptions;
using Mc2.CrudTest.Core.ApplicationServices.Customers.Commands.Create;
using Mc2.CrudTest.Core.ApplicationServices.Customers.Commands.Delete;
using Mc2.CrudTest.Core.ApplicationServices.Customers.Commands.Update;
using Mc2.CrudTest.Core.ApplicationServices.Customers.Queries.GetByName;
using Mc2.CrudTest.Core.ApplicationServices.Test.Unit.Customers.ClassFixtures;
using Mc2.CrudTest.Core.Contracts.Customers.Commands;
using Mc2.CrudTest.Core.Contracts.Customers.Queries;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Delete;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetByName;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Mc2.CrudTest.Core.ApplicationServices.Test.Unit.Customers.Tests;

public class CustomerServiceTests : IClassFixture<CustomerFixture>
{
    private readonly CreateCustomerCommandHandler _createCustomerHandler;
    private readonly GetCustomerByNameQueryHandler _getCustomerByNameQueryHandler;
    private readonly UpdateCustomerCommandHandler _updateCustomerHandler;
    private readonly DeleteCustomerCommandHandler _deleteCustomerHandler;
    private readonly ICustomerCommandRepository _customerCommandRepository;
    private readonly ICustomerQueryRepository _customerQueryRepository;

    private readonly CustomerFixture _customerFixture;

    public CustomerServiceTests(CustomerFixture customerFixture)
    {
        _customerCommandRepository = Substitute.For<ICustomerCommandRepository>();
        _customerQueryRepository = Substitute.For<ICustomerQueryRepository>();
        _createCustomerHandler = new CreateCustomerCommandHandler(_customerCommandRepository);
        _getCustomerByNameQueryHandler = new GetCustomerByNameQueryHandler(_customerQueryRepository);
        _updateCustomerHandler = new UpdateCustomerCommandHandler(_customerCommandRepository, _customerQueryRepository);
        _deleteCustomerHandler = new DeleteCustomerCommandHandler(_customerCommandRepository, _customerQueryRepository);
        _customerFixture = customerFixture;
    }

    [Fact]
    public async void Should_ReturnOk_WhenNewCustomerCreate()
    {
        //Arrange


        //Act
        var result = await _createCustomerHandler.Handle(_customerFixture.CreateCustomer);

        //Assert
        result.Status.Should().Be(ApplicationServiceStatus.Ok);
    }

    [Fact]
    public async void Should_CallInsert_WhenNewCustomerCreate()
    {
        //Arrange


        //Act
        var result = await _createCustomerHandler.Handle(_customerFixture.CreateCustomer);

        //Assert
        await _customerCommandRepository.ReceivedWithAnyArgs().InsertAsync(default);
    }

    [Fact]
    public async void Should_CallExecuteAsync_WhenGetCustomer()
    {
        //arrange
        var query = new GetCustomerByNameQuery()
        {
            FirstName = _customerFixture.CreateCustomer.FirstName,
            LastName = _customerFixture.CreateCustomer.LastName
        };

        //act
        var result = await _getCustomerByNameQueryHandler.Handle(query);

        //assert
        await _customerQueryRepository.Received().ExecuteAsync(query);
    }

    [Fact]
    public void Should_ReturnThrowExcpetion_WhenCustomerNotFound()
    {
        //Arrange


        //Act
        Action ctor = () => _updateCustomerHandler.Handle(_customerFixture.UpdateCustomer).RunSynchronously();

        //Assert
        ctor.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void Should_ThrowInvalidOperationException_WhenInvalidCustomerDelete()
    {
        //Arrange
        var deleteCustomer = new DeleteCustomerCommand()
        {
            Id = _customerFixture.UpdateCustomer.Id
        };

        //Act
        Action ctor = () => _deleteCustomerHandler.Handle(deleteCustomer).RunSynchronously();

        //Assert
        ctor.Should().ThrowExactly<InvalidOperationException>();
    }

}