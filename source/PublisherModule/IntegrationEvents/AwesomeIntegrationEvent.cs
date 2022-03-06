using System;
using BuildingBlocks.Infrastructure.EventBus;

namespace PublisherModule.IntegrationEvents
{
    public class AwesomeIntegrationEvent : IntegrationEvent
    {
        public string Name { get; set; }

        public AwesomeIntegrationEvent(Guid id, DateTime occuredOn, string name) : base(id, occuredOn)
        {
            Name = name;
        }
    }
}