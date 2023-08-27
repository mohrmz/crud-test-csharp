using Framework.Core.ApplicationServices.Commands;
using Framework.Core.Domain.Exceptions;
using Framework.Core.RequestResponse.Commands;
using Mc2.CrudTest.Core.Contracts.Customers.Commands;
using Mc2.CrudTest.Core.Contracts.Customers.Queries;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Delete;

namespace Mc2.CrudTest.Core.ApplicationServices.Customers.Commands.Delete;


public class DeleteCustomerCommandHandler : CommandHandler<DeleteCustomerCommand>
{
    private readonly ICustomerCommandRepository _customerCommandRepository;
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public DeleteCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository,
                                        ICustomerQueryRepository customerQueryRepository) : base()
    {
        _customerCommandRepository = customerCommandRepository;
        _customerQueryRepository = customerQueryRepository;
    }

    public override async Task<CommandResult> Handle(DeleteCustomerCommand command)
    {
        var customer = await _customerQueryRepository.GetAsync(command.Id);

        if (customer is null)
            throw new InvalidEntityStateException("Customer not found");

        customer.Delete();

        _customerCommandRepository.Delete(customer);

        await _customerCommandRepository.CommitAsync();

        return Ok();
    }
}

