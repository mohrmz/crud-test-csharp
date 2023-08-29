using Mc2.CrudTest.AcceptanceTests.Models;
using Mc2.CrudTest.AcceptanceTests.Tools;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.CommonModels;

namespace Mc2.CrudTest.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerManagerStepDefinitions
    {
        private CustomerDTO _createdDto;
        private CustomerDTO _updatedDto;

        private CreateCustomerCommand _createValidCustomer;
        private CreateCustomerCommand _createInValidPhoneNumberCustomer;
        private CreateCustomerCommand _createInValidEmailCustomer;
        private CreateCustomerCommand _createInValidBankCustomer;

        private UpdateCustomerCommand _updateCustomer;

        private DeleteCustomerCommand _deleteCustomer;

        private GetCustomerByNameQuery _getCustomerByName;
        private GetCustomerByIdQuery _getCustomerById;

        private RestClient? restClient = new RestClient(HostConstants.Endpoint);
        public CustomerManagerStepDefinitions()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

        }

        [Given(@"The Valid Customer Has Following Information")]
        public async Task GivenTheValidCustomerHasFollowingInformation(Table table)
        {
            _createValidCustomer = table.CreateInstance<CreateCustomerCommand>();
        }

        [When(@"I Want To Register A New Valid Customer In CMS")]
        public async Task WhenIWantToRegisterANewValidCustomerInCMS()
        {
            var restRequest = new RestRequest(_createValidCustomer.Path);
            restRequest.AddJsonBody(_createValidCustomer);
            await restClient.PostAsync(restRequest);
        }

        [Then(@"The Customer With Correct Information Should Be Added In DB")]
        public async Task ThenTheCustomerWithCorrectInformationShouldBeAddedInDB()
        {
            _getCustomerByName = new GetCustomerByNameQuery()
            {
                FirstName = _createValidCustomer.FirstName,
                LastName = _createValidCustomer.LastName,
            };

            var url = $"{_getCustomerByName.Path}?FirstName={_getCustomerByName.FirstName}&LastName={_getCustomerByName.LastName}";
            var restGetRequest = new RestRequest(url);
            var result = await restClient.GetAsync<CustomerDTO>(restGetRequest);

            result.FirstName.Should().Be(_createValidCustomer.FirstName);
            result.LastName.Should().Be(_createValidCustomer.LastName);
            result.DateOfBirth.Should().Be(DateTime.Parse(_createValidCustomer.DateOfBirth));
            result.PhoneNumber.Should().Be(_createValidCustomer.PhoneNumber);
            result.BankAccountNumber.Should().Be(_createValidCustomer.BankAccountNumber);
            result.Email.Should().Be(_createValidCustomer.Email);

            _deleteCustomer = new DeleteCustomerCommand()
            {
                Id = result.Id
            };

            var restDeleteRequest = new RestRequest($"{_deleteCustomer.Path}/{_deleteCustomer.Id}");
            await restClient.DeleteAsync(restDeleteRequest);
        }

        [Given(@"The Invalid Phone Number Customer Has Following Information")]
        public async Task GivenTheInvalidPhoneNumberCustomerHasFollowingInformation(Table table)
        {
            _createInValidPhoneNumberCustomer = table.CreateInstance<CreateCustomerCommand>();
        }

        [When(@"I Want To Register A New Customer With Invalid Phone Number In CMS")]
        public async Task WhenIWantToRegisterANewCustomerWithInvalidPhoneNumberInCMS()
        {
            try
            {
                var restRequest = new RestRequest(_createInValidPhoneNumberCustomer.Path);
                restRequest.AddJsonBody(_createInValidPhoneNumberCustomer);
                await restClient.PostAsync(restRequest);
            }
            catch (HttpRequestException e)
            {
                
            }
            catch(Exception e)
            {

            }
        }

        [Then(@"The Invalid Phone Number Customer Should Not Be Added In DB And Raise Error")]
        public async Task ThenTheInvalidPhoneNumberCustomerShouldNotBeAddedInDBAndRaiseError()
        {
            _getCustomerByName = new GetCustomerByNameQuery()
            {
                FirstName = _createInValidPhoneNumberCustomer.FirstName,
                LastName = _createInValidPhoneNumberCustomer.LastName,
            };

            var url = $"{_getCustomerByName.Path}?FirstName={_createInValidPhoneNumberCustomer.FirstName}&LastName={_createInValidPhoneNumberCustomer.LastName}";
            var restGetRequest = new RestRequest(url);
            var result = await restClient.GetAsync<CustomerDTO>(restGetRequest);

            result.Should().BeNull();
        }

        [Given(@"The Invalid Email Customer Has Following Information")]
        public async Task GivenTheInvalidEmailCustomerHasFollowingInformation(Table table)
        {
            _createInValidEmailCustomer = table.CreateInstance<CreateCustomerCommand>();
        }

        [When(@"I Want To Register A New Customer With Invalid Email In CMS")]
        public async Task WhenIWantToRegisterANewCustomerWithInvalidEmailInCMS()
        {
            try
            {
                var restRequest = new RestRequest(_createInValidEmailCustomer.Path);
                restRequest.AddJsonBody(_createInValidEmailCustomer);
                await restClient.PostAsync(restRequest);
            }
            catch (HttpRequestException e)
            {

            }
            catch (Exception e)
            {

            }
        }

        [Then(@"The Invalid Email Customer Customer Should Not Be Added In DB And Raise Error")]
        public async Task ThenTheInvalidEmailCustomerCustomerShouldNotBeAddedInDBAndRaiseError()
        {
            _getCustomerByName = new GetCustomerByNameQuery()
            {
                FirstName = _createInValidEmailCustomer.FirstName,
                LastName = _createInValidEmailCustomer.LastName,
            };

            var url = $"{_getCustomerByName.Path}?FirstName={_createInValidEmailCustomer.FirstName}&LastName={_createInValidEmailCustomer.LastName}";
            var restGetRequest = new RestRequest(url);
            var result = await restClient.GetAsync<CustomerDTO>(restGetRequest);

            result.Should().BeNull();
        }

        [Given(@"The Invalid Bank Account Number  Customer Has Following Information")]
        public async Task GivenTheInvalidBankAccountNumberCustomerHasFollowingInformation(Table table)
        {
            _createInValidBankCustomer = table.CreateInstance<CreateCustomerCommand>();
        }

        [When(@"I Want To Register A New Customer With Invalid Bank Account Number In CMS")]
        public async Task WhenIWantToRegisterANewCustomerWithInvalidBankAccountNumberInCMS()
        {
            try
            {
                var restRequest = new RestRequest(_createInValidBankCustomer.Path);
                restRequest.AddJsonBody(_createInValidBankCustomer);
                await restClient.PostAsync(restRequest);
            }
            catch (HttpRequestException e)
            {

            }
            catch (Exception e)
            {

            }
        }

        [Then(@"The Invalid Bank Account Number Customer Should Not Be Added In DB And Raise Error")]
        public async Task ThenTheInvalidBankAccountNumberCustomerShouldNotBeAddedInDBAndRaiseError()
        {
            _getCustomerByName = new GetCustomerByNameQuery()
            {
                FirstName = _createInValidBankCustomer.FirstName,
                LastName = _createInValidBankCustomer.LastName,
            };

            var url = $"{_getCustomerByName.Path}?FirstName={_createInValidBankCustomer.FirstName}&LastName={_createInValidBankCustomer.LastName}";
            var restGetRequest = new RestRequest(url);
            var result = await restClient.GetAsync<CustomerDTO>(restGetRequest);

            result.Should().BeNull();
        }

        [When(@"I Want To Manage Customers")]
        public async Task WhenIWantToManageCustomers()
        {
            if (_createValidCustomer == null)
            {
                _createValidCustomer = new CreateCustomerCommand()
                {
                    FirstName = "y",
                    LastName = "i",
                    Email = "tr@gmail.com",
                    DateOfBirth = "1995-02-01",
                    PhoneNumber = "+441174960123",
                    BankAccountNumber = "DE12345678901234567890"
                };
            }
            var restRequest = new RestRequest(_createValidCustomer.Path);
            restRequest.AddJsonBody(_createValidCustomer);
            await restClient.PostAsync(restRequest);
        }

        [Then(@"The Customers Should Be Loaded From DB")]
        public async Task ThenTheCustomersShouldBeLoadedFromDB()
        {
            _getCustomerByName = new GetCustomerByNameQuery()
            {
                FirstName = _createValidCustomer.FirstName,
                LastName = _createValidCustomer.LastName,
            };

            var url = $"{_getCustomerByName.Path}?FirstName={_getCustomerByName.FirstName}&LastName={_getCustomerByName.LastName}";
            var restGetRequest = new RestRequest(url);
            var result = await restClient.GetAsync<CustomerDTO>(restGetRequest);

            result.FirstName.Should().Be(_createValidCustomer.FirstName);
            result.LastName.Should().Be(_createValidCustomer.LastName);
            result.DateOfBirth.Should().Be(DateTime.Parse(_createValidCustomer.DateOfBirth));
            result.PhoneNumber.Should().Be(_createValidCustomer.PhoneNumber);
            result.BankAccountNumber.Should().Be(_createValidCustomer.BankAccountNumber);
            result.Email.Should().Be(_createValidCustomer.Email);

            _deleteCustomer = new DeleteCustomerCommand()
            {
                Id = result.Id
            };

            var restDeleteRequest = new RestRequest($"{_deleteCustomer.Path}/{_deleteCustomer.Id}");
            await restClient.DeleteAsync(restDeleteRequest);
        }

        [Given(@"The Customer Information Update To the Following Information")]
        public async Task GivenTheCustomerInformationUpdateToTheFollowingInformation(Table table)
        {
            _updateCustomer = table.CreateInstance<UpdateCustomerCommand>();
        }

        [When(@"I Want To update Customer Information In CMS")]
        public async Task WhenIWantToUpdateCustomerInformationInCMS()
        {
            if (_createValidCustomer == null)
            {
                _createValidCustomer = new CreateCustomerCommand()
                {
                    FirstName = "ya",
                    LastName = "is",
                    Email = "trt@gmail.com",
                    DateOfBirth = "1995-02-01",
                    PhoneNumber = "+441174960123",
                    BankAccountNumber = "DE12345678901234567890"
                };
            }
            var restRequest = new RestRequest(_createValidCustomer.Path);
            restRequest.AddJsonBody(_createValidCustomer);
            await restClient.PostAsync(restRequest);

            _getCustomerByName = new GetCustomerByNameQuery()
            {
                FirstName = _createValidCustomer.FirstName,
                LastName = _createValidCustomer.LastName,
            };

            var url = $"{_getCustomerByName.Path}?FirstName={_getCustomerByName.FirstName}&LastName={_getCustomerByName.LastName}";
            var restGetRequest = new RestRequest(url);
            var result = await restClient.GetAsync<CustomerDTO>(restGetRequest);

            _updateCustomer.Id = result.Id;
            var restUpdateRequest = new RestRequest(_updateCustomer.Path);
            restUpdateRequest.AddJsonBody(_updateCustomer);
            await restClient.PutAsync(restUpdateRequest);

        }

        [Then(@"The Customer Information Should Be Updated In DB")]
        public async Task ThenTheCustomerInformationShouldBeUpdatedInDB()
        {
            _getCustomerByName = new GetCustomerByNameQuery()
            {
                FirstName = _updateCustomer.FirstName,
                LastName = _updateCustomer.LastName,
            };
            var urlAfterUpdate = $"{_getCustomerByName.Path}?FirstName={_getCustomerByName.FirstName}&LastName={_getCustomerByName.LastName}";
            var restAfterUpdateRequest = new RestRequest(urlAfterUpdate);
            var resultAfterUpdate = await restClient.GetAsync<CustomerDTO>(restAfterUpdateRequest);

            resultAfterUpdate.FirstName.Should().Be(_updateCustomer.FirstName);
            resultAfterUpdate.LastName.Should().Be(_updateCustomer.LastName);
            resultAfterUpdate.DateOfBirth.Should().Be(DateTime.Parse(_updateCustomer.DateOfBirth));
            resultAfterUpdate.PhoneNumber.Should().Be(_updateCustomer.PhoneNumber);
            resultAfterUpdate.BankAccountNumber.Should().Be(_updateCustomer.BankAccountNumber);
            resultAfterUpdate.Email.Should().Be(_updateCustomer.Email);

            _deleteCustomer = new DeleteCustomerCommand()
            {
                Id = resultAfterUpdate.Id
            };

            var restDeleteRequest = new RestRequest($"{_deleteCustomer.Path}/{_deleteCustomer.Id}");
            await restClient.DeleteAsync(restDeleteRequest);
        }

        [When(@"I Want To Delete Customer Information In CMS")]
        public async Task WhenIWantToDeleteCustomerInformationInCMS()
        {
            if (_createValidCustomer == null)
            {
                _createValidCustomer = new CreateCustomerCommand()
                {
                    FirstName = "yau",
                    LastName = "isu",
                    Email = "trtu@gmail.com",
                    DateOfBirth = "1995-02-01",
                    PhoneNumber = "+441174960123",
                    BankAccountNumber = "DE12345678901234567890"
                };
            }
            var restRequest = new RestRequest(_createValidCustomer.Path);
            restRequest.AddJsonBody(_createValidCustomer);
            await restClient.PostAsync(restRequest);


            _getCustomerByName = new GetCustomerByNameQuery()
            {
                FirstName = _createValidCustomer.FirstName,
                LastName = _createValidCustomer.LastName,
            };

            var url = $"{_getCustomerByName.Path}?FirstName={_getCustomerByName.FirstName}&LastName={_getCustomerByName.LastName}";
            var restGetRequest = new RestRequest(url);
            var result = await restClient.GetAsync<CustomerDTO>(restGetRequest);

            _deleteCustomer = new DeleteCustomerCommand()
            {
                Id = result.Id
            };

            var restDeleteRequest = new RestRequest($"{_deleteCustomer.Path}/{_deleteCustomer.Id}");
            await restClient.DeleteAsync(restDeleteRequest);
        }

        [Then(@"The Customer Information Should Be Deleted From DB And Load Empty")]
        public async Task ThenTheCustomerInformationShouldBeDeletedFromDBAndLoadEmpty()
        {
            _getCustomerByName = new GetCustomerByNameQuery()
            {
                FirstName = _createValidCustomer.FirstName,
                LastName = _createValidCustomer.LastName,
            };

            var url = $"{_getCustomerByName.Path}?FirstName={_getCustomerByName.FirstName}&LastName={_getCustomerByName.LastName}";
            var restGetRequest = new RestRequest(url);
            var result = await restClient.GetAsync<CustomerDTO>(restGetRequest);

            result.Should().BeNull();
        }
    }
}
