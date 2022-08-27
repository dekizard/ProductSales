# MassTransit with RabbitMQ and .NET 6 sample Product Order application

Get sample app up and running:
1) docker run -p 15672:15672 -p 5672:5672 masstransit/rabbitmq

2) Set multiple startup projects in Visual Studio:
Notifications, Order, ProductSales.WebApi and PS.BackOffice.WebApi