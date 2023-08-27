using Framework.Core.Domain.Events;

namespace Mc2.CrudTest.Core.Domain.Customers.Events;

public record CustomerDeleted(Guid BusinessId) : IDomainEvent;

