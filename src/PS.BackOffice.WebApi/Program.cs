using MassTransit;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddMassTransit(massTransitConfig =>
{
    massTransitConfig.UsingRabbitMq((context, rabbitConfig) =>
    {
        rabbitConfig.Host(configuration["MassTransit:RabbitMqUri"], hostConfig =>
        {
            hostConfig.Username(configuration["MassTransit:RabbitMqUsername"]);
            hostConfig.Username(configuration["MassTransit:RabbitMqPassword"]);
        });
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
