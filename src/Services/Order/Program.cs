using MassTransit;
using Order.Features.CreateOrder;

var configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: false)
      .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(massTransitConfig =>
        {
            massTransitConfig.AddConsumer<CreateOrderCommandHandler>();

            massTransitConfig.UsingRabbitMq((context, rabbitConfig) =>
            {
                rabbitConfig.Host(configuration["MassTransit:RabbitMqUri"], hostConfig =>
                {
                    hostConfig.Username(configuration["MassTransit:RabbitMqUsername"]);
                    hostConfig.Username(configuration["MassTransit:RabbitMqPassword"]);
                });

                rabbitConfig.ReceiveEndpoint("orders", endpointConfig =>
                {
                    endpointConfig.PrefetchCount = 16;

                    endpointConfig.ConfigureConsumer<CreateOrderCommandHandler>(context);
                });
            });
        });
    })
    .Build();


await host.RunAsync();
