using Framework.Core.ApplicationServices.Events;

namespace Mc2.CrudTest.Presentation.Server.Decorators;

public class EventDecorator : EventDispatcherDecorator
{
    public override int Order => 0;

    public override async Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event)
    {
        await _eventDispatcher.PublishDomainEventAsync(@event);
    }
}