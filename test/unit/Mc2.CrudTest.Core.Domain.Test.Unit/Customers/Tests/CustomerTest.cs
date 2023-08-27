using FluentAssertions;
using Framework.Core.Domain.Exceptions;
using Mc2.CrudTest.Core.Domain.Test.Unit.Customers.Builders;
using Mc2.CrudTest.Core.Domain.Test.Unit.Customers.ClassFixtures;

namespace Mc2.CrudTest.Core.Domain.Test.Unit.Customers.Tests
{
    public class CustomerTest : IClassFixture<FakeCustomerFixture>
    {
        private readonly CustomerBuilder _customerBuilder;
        FakeCustomerFixture fakeCustomerFixture;

        public CustomerTest(FakeCustomerFixture fakeCustomerFixture)
        {
            _customerBuilder = new CustomerBuilder();
            this.fakeCustomerFixture = fakeCustomerFixture;
        }

        [Fact]
        public void Constrcutor_ShouldConstructCustomerInformationsProperties()
        {

            //Arrange


            //Act
            var customer = _customerBuilder
                    .WithFirstName(fakeCustomerFixture.FakeCustomer.FirstName)
                    .WithLastName(fakeCustomerFixture.FakeCustomer.LastName)
                    .WithDateOfBirth(fakeCustomerFixture.FakeCustomer.DateOfBirth)
                    .WithPhoneNumber(fakeCustomerFixture.FakeCustomer.PhoneNumber)
                    .WithEmail(fakeCustomerFixture.FakeCustomer.Email)
                    .WithBankAccountNumber(fakeCustomerFixture.FakeCustomer.BankAccountNumber)
                    .Build();

            //Assert
            customer.FirstName.Value.Should().Be(fakeCustomerFixture.FakeCustomer.FirstName);
            customer.LastName.Value.Should().Be(fakeCustomerFixture.FakeCustomer.LastName);
            customer.DateOfBirth.Value.Should().Be(fakeCustomerFixture.FakeCustomer.DateOfBirth);
            customer.PhoneNumber.Value.Should().Be(fakeCustomerFixture.FakeCustomer.PhoneNumber);
            customer.Email.Value.Should().Be(fakeCustomerFixture.FakeCustomer.Email);
            customer.BankAccountNumber.Value.Should().Be(fakeCustomerFixture.FakeCustomer.BankAccountNumber);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_ThrowException_WhenFirstNameIs(string nullOrEmpty)
        {
            //Arrange

            //Act
            Action ctor = () => _customerBuilder
                .WithFirstName(nullOrEmpty)
                .Build();

            //Assert
            ctor.Should().ThrowExactly<InvalidValueObjectStateException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_ThrowException_WhenLastNameIs(string nullOrEmpty)
        {
            //Arrange

            //Act
            Action ctor = () => _customerBuilder
                .WithLastName(nullOrEmpty)
                .Build();

            //Assert
            ctor.Should().ThrowExactly<InvalidValueObjectStateException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_ThrowException_WhenDateOfBirthIs(string nullOrEmpty)
        {
            //Arrange

            //Act
            Action ctor = () => _customerBuilder
                .WithDateOfBirth(nullOrEmpty)
                .Build();

            //Assert
            ctor.Should().ThrowExactly<InvalidValueObjectStateException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_ThrowException_WhenPhoneNumberIs(string nullOrEmpty)
        {
            //Arrange

            //Act
            Action ctor = () => _customerBuilder
                .WithPhoneNumber(nullOrEmpty)
                .Build();

            //Assert
            ctor.Should().ThrowExactly<InvalidValueObjectStateException>();
        }

        [Theory]
        [InlineData("174960123")]
        public void Should_ThrowException_WhenPhoneNumberIsAInvalid(string number)
        {
            //Arrange

            //Act
            Action ctor = () => _customerBuilder
                .WithPhoneNumber(number)
                .Build();

            //Assert
            ctor.Should().ThrowExactly<InvalidValueObjectStateException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_ThrowException_WhenEmailIs(string nullOrEmpty)
        {
            //Arrange

            //Act
            Action ctor = () => _customerBuilder
                .WithEmail(nullOrEmpty)
                .Build();

            //Assert
            ctor.Should().ThrowExactly<InvalidValueObjectStateException>();
        }

        [Theory]
        [InlineData("testinvalidemail")]
        public void Should_ThrowException_WhenEmailIsAInvalid(string email)
        {
            //Arrange

            //Act
            Action ctor = () => _customerBuilder
                .WithEmail(email)
                .Build();

            //Assert
            ctor.Should().ThrowExactly<InvalidValueObjectStateException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_ThrowException_WhenBankAccountNumberIs(string nullOrEmpty)
        {
            //Arrange

            //Act
            Action ctor = () => _customerBuilder
                .WithBankAccountNumber(nullOrEmpty)
                .Build();

            //Assert
            ctor.Should().ThrowExactly<InvalidValueObjectStateException>();
        }
    }
}
