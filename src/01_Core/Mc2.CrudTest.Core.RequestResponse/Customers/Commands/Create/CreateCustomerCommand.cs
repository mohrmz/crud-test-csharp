using Framework.Core.RequestResponse.Commands;
using Framework.Core.RequestResponse.Endpoints;

namespace Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Create;

public class CreateCustomerCommand : ICommand<Guid>, IWebRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string BankAccountNumber { get; set; } = string.Empty;


    public string Path => "/api/Customer/Create";
}
