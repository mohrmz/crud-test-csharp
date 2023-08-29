using Framework.Core.Domain.Entities;
using Mc2.CrudTest.Core.Domain.Customers.Events;
using Mc2.CrudTest.Core.Domain.Customers.ValuesObjects;

namespace Mc2.CrudTest.Core.Domain.Customers.Entities
{
    public class Customer : AggregateRoot<int>
    {
        #region Properties
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public DateOfBirth DateOfBirth { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Email Email { get; set; }
        public BankAccountNumber BankAccountNumber { get; set; }
        #endregion

        #region Constructors
        private Customer()
        {

        }

        public Customer(string firstName,
                string lastName,
                string dateOfBirth,
                string phoneNumber,
                string email,
                string bankAccountNumber)
        {
            FirstName = new FirstName(firstName);
            LastName = new LastName(lastName);
            DateOfBirth = new DateOfBirth(dateOfBirth);
            PhoneNumber = new PhoneNumber(phoneNumber);
            Email = new Email(email);
            BankAccountNumber = new BankAccountNumber(bankAccountNumber);

            AddEvent(new CustomerCreated(BusinessId.Value,
                                       firstName,
                                       lastName,
                                       DateOfBirth.Value,
                                       phoneNumber,
                                       email,
                                       bankAccountNumber));
        }

        public Customer(FirstName firstName,
                        LastName lastName,
                        DateOfBirth dateOfBirth,
                        PhoneNumber phoneNumber,
                        Email email,
                        BankAccountNumber bankAccountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;

            AddEvent(new CustomerCreated(BusinessId.Value,
                                        firstName.Value,
                                        lastName.Value,
                                        dateOfBirth.Value,
                                        phoneNumber.Value,
                                        email.Value,
                                        bankAccountNumber.Value));
        }
        #endregion


        #region Commands
        public static Customer Create(FirstName firstName,
                        LastName lastName,
                        DateOfBirth dateOfBirth,
                        PhoneNumber phoneNumber,
                        Email email,
                        BankAccountNumber bankAccountNumber) => new(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);

        public void Update(FirstName firstName,
                        LastName lastName,
                        DateOfBirth dateOfBirth,
                        PhoneNumber phoneNumber,
                        Email email,
                        BankAccountNumber bankAccountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;

            AddEvent(new CustomerUpdated(BusinessId.Value,
                                        firstName.Value,
                                        lastName.Value,
                                        DateOfBirth.Value,
                                        phoneNumber.Value,
                                        email.Value,
                                        bankAccountNumber.Value));
        }
        public void Delete()
        {
            AddEvent(new CustomerDeleted(BusinessId.Value));
        }

        #endregion
    }
}
