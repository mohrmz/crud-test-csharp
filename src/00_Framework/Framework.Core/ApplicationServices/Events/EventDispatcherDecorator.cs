using Framework.Core.Contracts.ApplicationServices.Events;
using Framework.Core.Domain.Events;

namespace Framework.Core.ApplicationServices.Events;

public abstract class EventDispatcherDecorator : IEventDispatcher
{
    #region Fields
    protected IEventDispatcher _eventDispatcher;
    public abstract int Order { get; }
    #endregion

    #region Constructors
    public EventDispatcherDecorator() { }
    #endregion

    #region Abstract Send Commands
    public abstract Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent;

    public void SetEventDispatcher(IEventDispatcher eventDispatcher)
    {
        _eventDispatcher = eventDispatcher;
    }
    #endregion
}