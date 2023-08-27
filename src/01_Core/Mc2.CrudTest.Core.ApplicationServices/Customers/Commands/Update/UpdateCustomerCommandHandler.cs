using Framework.Core.ApplicationServices.Commands;
using Framework.Core.Domain.Exceptions;
using Framework.Core.RequestResponse.Commands;
using Mc2.CrudTest.Core.Contracts.Customers.Commands;
using Mc2.CrudTest.Core.Contracts.Customers.Queries;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Update;

namespace Mc2.CrudTest.Core.ApplicationServices.Customers.Commands.Update;


public class UpdateCustomerCommandHandler : CommandHandler<UpdateCustomerCommand>
{
    private readonly ICustomerCommandRepository _customerCommandRepository;
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public UpdateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository,
                                        ICustomerQueryRepository customerQueryRepository) : base()
    {
        _customerCommandRepository = customerCommandRepository;
        _customerQueryRepository = customerQueryRepository;
    }

    public override async Task<CommandResult> Handle(UpdateCustomerCommand command)
    {
        var customer = await _customerQueryRepository.GetAsync(command.Id);

        if (customer is null)
            throw new InvalidEntityStateException("Customer not found");

        customer.Update(command.FirstName,
                        command.LastName,
                        command.DateOfBirth,
                        command.PhoneNumber,
                        command.Email,
                        command.BankAccountNumber);

        await _customerCommandRepository.CommitAsync();

        return Ok();
    }
}