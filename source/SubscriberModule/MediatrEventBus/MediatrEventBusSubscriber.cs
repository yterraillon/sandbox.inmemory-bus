using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PublisherModule.MediatrEvents;

namespace SubscriberModule.MediatrEventBus
{
    public class MediatrEventBusSubscriber : INotificationHandler<Events.Created>, INotificationHandler<Events.Updated>
    {
        public Task Handle(Events.Created notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Received an awesome Event : {notification.Name}");
            return Task.CompletedTask;
        }

        public Task Handle(Events.Updated notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Received an awesome Event : {notification.Token}");
            return Task.CompletedTask;
        }
    }
}