using MassTransit;
using ProductSales.Messages.Events;

namespace Notifications.Consumers
{
    public class ProductCreatedHandler : IConsumer<ProductCreated>
    {
        public Task Consume(ConsumeContext<ProductCreated> context)
        {
            var message = $"New product created: {context.Message.Name} - {context.Message.Price} {context.Message.Currency}";

            return Task.CompletedTask;
        }
    }
}
