using MassTransit;
using ProductSales.Messages.Events;

namespace Notifications.Consumers
{
    public class OrderCreatedHandler : IConsumer<OrderCreated>
    {
        public Task Consume(ConsumeContext<OrderCreated> context)
        {
            //send email notification to user

            return Task.CompletedTask;
        }
    }
}
