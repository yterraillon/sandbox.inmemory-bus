using BuildingBlocks.EventBus;
using BuildingBlocks.Infrastructure.EventBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PublisherModule;
using SubscriberModule;

namespace Webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Webapi", Version = "v1" });
            });

            services.AddSingleton<IEventsBus, InMemoryEventBusClient>();
            services.AddPublisher();
            services.AddSubscriber();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var sp = app.ApplicationServices;
            var eventsBus = sp.GetService<IEventsBus>();

            SubscriberCompositionRoot.Initialize(eventsBus);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Webapi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
