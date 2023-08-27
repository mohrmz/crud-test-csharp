using Framework.Core.ApplicationServices.Commands;
using Framework.Core.RequestResponse.Commands;
using Mc2.CrudTest.Core.Contracts.Customers.Commands;
using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Create;

namespace Mc2.CrudTest.Core.ApplicationServices.Customers.Commands.Create;

public class CreateCustomerCommandHandler : CommandHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerCommandRepository _customerCommandRepository;

    public CreateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository) : base()
    {
        _customerCommandRepository = customerCommandRepository;
    }

    public override async Task<CommandResult<Guid>> Handle(CreateCustomerCommand command)
    {
        Customer customer = Customer.Create(command.FirstName,
                                            command.LastName,
                                            command.DateOfBirth,
                                            command.PhoneNumber,
                                            command.Email,
                                            command.BankAccountNumber);

        await _customerCommandRepository.InsertAsync(customer);

        await _customerCommandRepository.CommitAsync();

        return Ok(customer.BusinessId.Value);
    }
}
