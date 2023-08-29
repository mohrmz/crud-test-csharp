using Framework.Core.ApplicationServices.Commands;
using Framework.Core.Domain.Exceptions;
using Framework.Core.RequestResponse.Commands;
using Mc2.CrudTest.Core.Contracts.Customers.Commands;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Delete;

namespace Mc2.CrudTest.Core.ApplicationServices.Customers.Commands.Delete;


public class DeleteCustomerCommandHandler : CommandHandler<DeleteCustomerCommand>
{
    private readonly ICustomerCommandRepository _customerCommandRepository;

    public DeleteCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository) : base()
    {
        _customerCommandRepository = customerCommandRepository;
    }

    public override async Task<CommandResult> Handle(DeleteCustomerCommand command)
    {
        var customer = await _customerCommandRepository.GetAsync(command.Id);

        if (customer is null)
            throw new InvalidEntityStateException("Customer not found");

        customer.Delete();

        _customerCommandRepository.Delete(customer);

        await _customerCommandRepository.CommitAsync();

        return Ok();
    }
}

