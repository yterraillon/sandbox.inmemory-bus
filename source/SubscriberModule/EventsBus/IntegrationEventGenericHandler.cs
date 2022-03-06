using System.Diagnostics;
using System.Threading.Tasks;
using BuildingBlocks.Infrastructure.EventBus;
using PublisherModule.IntegrationEvents;

namespace SubscriberModule.EventsBus
{
    public class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T>
        where T : IntegrationEvent
    {
        public Task Handle(T @event)
        {
            var fullName = @event.GetType().FullName;

            Debug.WriteLine($"Received an awesome Event : {fullName}");


            if (@event.GetType() == typeof(AwesomeIntegrationEvent))
            {
                var awesomeEvent = @event as AwesomeIntegrationEvent;
                Debug.WriteLine($"Awesome : {awesomeEvent?.Name}");
            }

            return Task.CompletedTask;
        }
    }
}