using Core.Async.Message;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace Core.Async.Masstransit.Services
{
    public class ExampleService : BackgroundService
    {
        private readonly IPublishEndpoint _endpoint;

        public ExampleService(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            IMessage message = new Message.ExampleMessage { Mail = "selam" };
            await _endpoint.Publish(message, stoppingToken);
        }
    }
}
