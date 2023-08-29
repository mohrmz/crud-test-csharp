using Mc2.CrudTest.Core.Domain.Customers.Data.Test;
using Mc2.CrudTest.Core.Domain.Customers.Entities;

namespace Mc2.CrudTest.Core.Domain.Test.Unit.Customers.Builders
{
    internal class CustomerBuilder
    {
        private string _firstName;
        private string _lastName;
        private string _dateOfBirth;
        private string _phoneNumber;
        private string _email;
        private string _bankAccountNumber;

        public CustomerBuilder()
        {
            var fake = new FakeCustomer();
            var customer = fake.Generate();
            _firstName = customer.FirstName;
            _lastName = customer.LastName;
            _dateOfBirth = customer.DateOfBirth;
            _phoneNumber = customer.PhoneNumber;
            _email = customer.Email;
            _bankAccountNumber = customer.BankAccountNumber;
        }

        public CustomerBuilder(string firstName, string lastName, string dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _phoneNumber = phoneNumber;
            _email = email;
            _bankAccountNumber = bankAccountNumber;
        }

        internal CustomerBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        internal CustomerBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        internal CustomerBuilder WithDateOfBirth(string dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
            return this;
        }

        internal CustomerBuilder WithPhoneNumber(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
            return this;
        }

        internal CustomerBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        internal CustomerBuilder WithBankAccountNumber(string bankAccountNumber)
        {
            _bankAccountNumber = bankAccountNumber;
            return this;
        }


        internal Customer Build()
        {
            return new Customer(
                _firstName,
                _lastName,
                _dateOfBirth,
                _phoneNumber,
                _email,
                _bankAccountNumber
            );

        }
    }
}
