using System.Reflection;
using BuildingBlocks.Infrastructure.EventBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SubscriberModule.EventsBus;

namespace SubscriberModule
{
    public static class SubscriberCompositionRoot
    {
        public static IServiceCollection AddSubscriber(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }

        public static void Initialize(IEventsBus eventsBus)
        {
            EventsBusStartup.Initialize(eventsBus);
        }
    }
}