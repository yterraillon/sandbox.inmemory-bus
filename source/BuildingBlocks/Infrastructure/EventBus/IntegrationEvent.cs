using System;
using MediatR;

namespace BuildingBlocks.Infrastructure.EventBus
{
    public abstract class IntegrationEvent : INotification
    {
        public Guid Id { get; }
        
        public DateTime OccurredOn { get; }
        
        protected IntegrationEvent(Guid id, DateTime occuredOn)
        {
            Id = id;
            OccurredOn = occuredOn;
        }
    }
}