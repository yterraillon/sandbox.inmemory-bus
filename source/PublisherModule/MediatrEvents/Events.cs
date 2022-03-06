using MediatR;

namespace PublisherModule.MediatrEvents
{
    public static class Events
    {
        public record Created(string Name) : INotification;

        public record Updated(string Token) : INotification;
    }
}