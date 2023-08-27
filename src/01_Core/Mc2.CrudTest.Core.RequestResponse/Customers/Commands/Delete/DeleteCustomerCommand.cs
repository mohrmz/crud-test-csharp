using Framework.Core.RequestResponse.Commands;
using Framework.Core.RequestResponse.Endpoints;

namespace Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Delete;

public class DeleteCustomerCommand : ICommand, IWebRequest
{
    public int Id { get; set; }

    public string Path => "/api/Customer/Delete";
}
