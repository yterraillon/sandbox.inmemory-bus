using BuildingBlocks.Infrastructure.EventBus;
using PublisherModule.IntegrationEvents;

namespace SubscriberModule.EventsBus
{
    public class EventsBusStartup
    {
        internal static void Initialize(IEventsBus eventsBus)
        {
            SubscribeToIntegrationEvents(eventsBus);
        }

        private static void SubscribeToIntegrationEvents(IEventsBus eventsBus)
        {
            SubscribeToIntegrationEvent<AwesomeIntegrationEvent>(eventsBus);
        }

        private static void SubscribeToIntegrationEvent<T>(IEventsBus eventsBus)
            where T : IntegrationEvent
        {
            eventsBus.Subscribe(new IntegrationEventGenericHandler<T>());
        }
    }
}