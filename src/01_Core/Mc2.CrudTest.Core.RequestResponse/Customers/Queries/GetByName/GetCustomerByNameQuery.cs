using Framework.Core.RequestResponse.Endpoints;
using Framework.Core.RequestResponse.Queries;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.Shared;

namespace Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetByName;

public class GetCustomerByNameQuery : IQuery<CustomerDTO?>, IWebRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Path => "/api/Customer/GetByName";
}
