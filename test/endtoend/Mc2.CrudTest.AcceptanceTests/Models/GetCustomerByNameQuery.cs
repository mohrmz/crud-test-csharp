namespace Mc2.CrudTest.AcceptanceTests.Models;

public class GetCustomerByNameQuery
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Path => "api/Customer/GetByName";
}
