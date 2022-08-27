using MassTransit;
using ProductSales.Messages.Commands;
using ProductSales.Messages.Events;

namespace Order.Features.CreateOrder
{
    public class CreateOrderCommandHandler : IConsumer<CreateOrderCommand>
    {
        public async Task Consume(ConsumeContext<CreateOrderCommand> context)
        {
            //store order in db

            //publish event
            await context.Publish<OrderCreated>(new
            {
                context.Message.Orders,  //get ProductName, Price, TotalPrice and Currency from db
                context.Message.Email
            });

        }
    }
}
