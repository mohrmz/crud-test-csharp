using System;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class CustomerManagerStepDefinitions
    {
        [Given(@"The Valid Customer Has Following Information")]
        public void GivenTheValidCustomerHasFollowingInformation(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"I Want To Register A New Valid Customer In CMS")]
        public void WhenIWantToRegisterANewValidCustomerInCMS()
        {
            throw new PendingStepException();
        }

        [Then(@"The Customer With Correct Information Should Be Added In DB")]
        public void ThenTheCustomerWithCorrectInformationShouldBeAddedInDB()
        {
            throw new PendingStepException();
        }

        [Given(@"The Invalid Customer Has Following Information")]
        public void GivenTheInvalidCustomerHasFollowingInformation(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"I Want To Register A New Customer With Invalid Phone Number In CMS")]
        public void WhenIWantToRegisterANewCustomerWithInvalidPhoneNumberInCMS()
        {
            throw new PendingStepException();
        }

        [Then(@"The Customer Should Not Be Added In DB And Raise Error")]
        public void ThenTheCustomerShouldNotBeAddedInDBAndRaiseError()
        {
            throw new PendingStepException();
        }

        [When(@"I Want To Register A New Customer With Invalid Email In CMS")]
        public void WhenIWantToRegisterANewCustomerWithInvalidEmailInCMS()
        {
            throw new PendingStepException();
        }

        [When(@"I Want To Register A New Customer With Invalid Bank Account Number In CMS")]
        public void WhenIWantToRegisterANewCustomerWithInvalidBankAccountNumberInCMS()
        {
            throw new PendingStepException();
        }

        [When(@"I Want To Register Duplicated Customers In CMS")]
        public void WhenIWantToRegisterDuplicatedCustomersInCMS()
        {
            throw new PendingStepException();
        }

        [Then(@"The New Customer Should Not Be Added In DB And Raise Error")]
        public void ThenTheNewCustomerShouldNotBeAddedInDBAndRaiseError()
        {
            throw new PendingStepException();
        }

        [When(@"I Want To Register Duplicated Customer With Unique Email In CMS")]
        public void WhenIWantToRegisterDuplicatedCustomerWithUniqueEmailInCMS()
        {
            throw new PendingStepException();
        }

        [When(@"I Want To Manage Customers")]
        public void WhenIWantToManageCustomers()
        {
            throw new PendingStepException();
        }

        [Then(@"The Customers Should Be Loaded From DB")]
        public void ThenTheCustomersShouldBeLoadedFromDB()
        {
            throw new PendingStepException();
        }

        [Given(@"The Customer Information Update To the Following Information")]
        public void GivenTheCustomerInformationUpdateToTheFollowingInformation(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"I Want To update Customer Information In CMS")]
        public void WhenIWantToUpdateCustomerInformationInCMS()
        {
            throw new PendingStepException();
        }

        [Then(@"The Customer Information Should Be Updated In DB")]
        public void ThenTheCustomerInformationShouldBeUpdatedInDB()
        {
            throw new PendingStepException();
        }

        [When(@"I Want To Delete Customer Information In CMS")]
        public void WhenIWantToDeleteCustomerInformationInCMS()
        {
            throw new PendingStepException();
        }

        [Then(@"The Customer Information Should Be Deleted From DB And Load Empty")]
        public void ThenTheCustomerInformationShouldBeDeletedFromDBAndLoadEmpty()
        {
            throw new PendingStepException();
        }
    }
}
