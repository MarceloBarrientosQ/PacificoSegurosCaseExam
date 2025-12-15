using Cortex.Mediator.Notifications;
using eb7461u20221e646.API.Shared.Domain.Model.Events;

namespace eb7461u20221e646.API.Shared.Application.Internal.EventHandlers;

public interface IEventHadler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}