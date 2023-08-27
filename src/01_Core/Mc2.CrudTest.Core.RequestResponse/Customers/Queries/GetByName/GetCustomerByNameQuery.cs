using Framework.Core.RequestResponse.Endpoints;
using Framework.Core.RequestResponse.Queries;

namespace Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetByName;

public class GetCustomerByNameQuery : IQuery<CustomerDTO?>, IWebRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Path => "/api/Custmer/GetByName";
}
