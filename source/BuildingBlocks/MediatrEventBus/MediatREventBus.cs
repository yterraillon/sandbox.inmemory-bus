using System.Threading.Tasks;
using MediatR;

namespace BuildingBlocks.MediatrEventBus
{
    public interface IMediatrEventBus
    {
        Task Publish<T>(T @event) where T : INotification;
    }

    public class MediatrEventBus : IMediatrEventBus
    {
        private readonly IMediator _mediator;

        public MediatrEventBus(IMediator mediator) => _mediator = mediator;

        public Task Publish<T>(T @event) where T : INotification
        {
            _mediator.Publish(@event);
            return Task.CompletedTask;
        }
    }
}