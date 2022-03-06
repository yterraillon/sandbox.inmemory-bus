using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.MediatrEventBus;
using MediatR;
using PublisherModule.MediatrEvents;

namespace PublisherModule.Application
{
    // Test: sending multiple Notifications to the same handler
    public static class AnotherEvent
    {
        public record Request() : IRequest<Response>;

        public record Response;

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IMediatrEventBus _mediatrEventBus;

            public Handler(IMediatrEventBus mediatrEventBus) => _mediatrEventBus = mediatrEventBus;

            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var @event = new Events.Created("created");
                _mediatrEventBus.Publish(@event);

                return Task.FromResult(new Response());
            }
        }
    }
}