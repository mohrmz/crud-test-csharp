using Framework.Core.Domain.Entities;
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
        }
        #endregion
    }
}
