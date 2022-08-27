using MassTransit;
using Notifications.Consumers;

var configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: false)
      .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(massTransitConfig =>
        {
            massTransitConfig.AddConsumer<ProductCreatedHandler>();
            massTransitConfig.AddConsumer<OrderCreatedHandler>();

            massTransitConfig.UsingRabbitMq((context, rabbitConfig) =>
            {
                rabbitConfig.Host(configuration["MassTransit:RabbitMqUri"], hostConfig =>
                {
                    hostConfig.Username(configuration["MassTransit:RabbitMqUsername"]);
                    hostConfig.Username(configuration["MassTransit:RabbitMqPassword"]);
                });

                rabbitConfig.ReceiveEndpoint("product.notification", endpointConfig =>
                {
                    endpointConfig.PrefetchCount = 16;
                    endpointConfig.ConfigureConsumer<ProductCreatedHandler>(context);
                });

                rabbitConfig.ReceiveEndpoint("order.notification", endpointConfig =>
                {
                    endpointConfig.PrefetchCount = 16;
                    endpointConfig.ConfigureConsumer<OrderCreatedHandler>(context);
                });
            });
    });
    })
    .Build();


await host.RunAsync();
