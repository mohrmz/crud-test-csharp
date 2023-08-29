namespace Mc2.CrudTest.AcceptanceTests.Models;

public class GetCustomerByIdQuery
{
    public int Id { get; set; }

    public string Path => "api/Customer/GetById";
}
