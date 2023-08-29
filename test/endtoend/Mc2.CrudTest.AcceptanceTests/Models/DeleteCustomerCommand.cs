namespace Mc2.CrudTest.AcceptanceTests.Models;

public class DeleteCustomerCommand
{
    public int Id { get; set; }

    public string Path => "api/Customer/Delete";
}
