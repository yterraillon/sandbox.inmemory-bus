using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Infrastructure.EventBus;
using MediatR;
using PublisherModule.IntegrationEvents;

namespace PublisherModule.Application
{
    public static class AwesomeEvent
    {
        public record Request(string Name) : IRequest<Response>;

        public record Response();

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEventsBus _eventsBus;

            public Handler(IEventsBus eventsBus) => _eventsBus = eventsBus;

            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                _eventsBus.Publish(new AwesomeIntegrationEvent(Guid.NewGuid(), DateTime.Now, request.Name));

                return Task.FromResult(new Response());
            }
        }
    }
}