using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ProductSales.Messages.Commands;
using ProductSales.WebApi.Dtos;
using System.Net;

namespace TicketService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IBus _bus;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDto request)
        {
            if (request == null)
                return BadRequest();

            //store order to Db

            //Send command
            _bus.Send<CreateOrderCommand>(new
            {
                request.Orders,
                request.Address,
                request.Email
            });

            return Accepted();
        }
    }
}