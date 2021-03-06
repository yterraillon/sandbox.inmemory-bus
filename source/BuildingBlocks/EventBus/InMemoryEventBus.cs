using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.Infrastructure.EventBus;

namespace BuildingBlocks.EventBus
{
    public sealed class InMemoryEventBus
    {
        private readonly IDictionary<string, List<IIntegrationEventHandler>> _handlersDictionary;

        public static InMemoryEventBus Instance { get; } = new ();

        static InMemoryEventBus()
        {
        }

        private InMemoryEventBus() => _handlersDictionary = new Dictionary<string, List<IIntegrationEventHandler>>();

        public void Subscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent
        {
            var eventType = typeof(T).FullName;

            if (eventType is null) return;

            if (_handlersDictionary.ContainsKey(eventType))
            {
                var handlers = _handlersDictionary[eventType];
                handlers.Add(handler);
            }
            else
            {
                _handlersDictionary.Add(eventType, new List<IIntegrationEventHandler>{ handler });
            }
        }

        public async Task Publish<T>(T @event)
            where T : IntegrationEvent
        {
            var eventType = @event.GetType().FullName;

            if(eventType is null) return;

            var integrationEventHandlers = _handlersDictionary[eventType];
            foreach (var integrationEventHandler in integrationEventHandlers)
            {
                if (integrationEventHandler is IIntegrationEventHandler<T> handler)
                {
                    await handler.Handle(@event);
                }
            }
        }
    }
}