using System.Reflection;
using BuildingBlocks.MediatrEventBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PublisherModule
{
    public static class PublisherCompositionRoot
    {
        public static IServiceCollection AddPublisher(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMediatrEventBus, MediatrEventBus>();

            return services;
        }
    }
}