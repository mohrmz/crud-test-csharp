using Framework.Core.RequestResponse.Endpoints;
using Framework.Core.RequestResponse.Queries;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.Shared;

namespace Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetById;

public class GetCustomerByIdQuery : IQuery<CustomerDTO?>, IWebRequest
{
    public int Id { get; set; }

    public string Path => "/api/Customer/GetById";
}
