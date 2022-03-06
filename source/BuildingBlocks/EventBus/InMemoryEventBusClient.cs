using System.Threading.Tasks;
using BuildingBlocks.Infrastructure.EventBus;
using Serilog;

namespace BuildingBlocks.EventBus
{
    public class InMemoryEventBusClient : IEventsBus
    {
        //private readonly ILogger _logger;

        public InMemoryEventBusClient()
        {

        }

        public void Dispose()
        {
        }

        public async Task Publish<T>(T @event) where T : IntegrationEvent
        {
            //_logger.Information("Publishing {Event}", @event.GetType().FullName);
            await InMemoryEventBus.Instance.Publish(@event);
        }

        public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
        {
            InMemoryEventBus.Instance.Subscribe(handler);
        }

        public void StartConsuming()
        {
        }
    }
}