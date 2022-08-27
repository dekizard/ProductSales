using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ProductSales.Messages.Events;
using PS.BackOffice.WebApi.Dtos;
using System.Net;

namespace TC.BackOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IPublishEndpoint publishEndpoint, ILogger<ProductController> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto request)
        {
            if (request == null)
                return BadRequest();

            //store product in db

            //publish event
            _publishEndpoint.Publish<ProductCreated>(new
            {
                request.Name,
                request.Price,
                request.Currency
            });

            return Accepted();
        }
    }
}