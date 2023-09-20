using MediatR;
using MediatR_Pattern.Command;
using MediatR_Pattern.Notification;
using MediatR_Pattern.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatR_Pattern.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productResult = await _mediator.Send(new AddProductCommand(product));

            // Publish a notification when a product is added
            await _mediator.Publish(new ProductAddedNotification(productResult));

            // Use the product's ID to generate the URL for the newly created resource.
            return CreatedAtRoute("GetProductById", new { id = productResult.Id }, productResult);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product == null)
            {
                return NotFound(); // Return a 404 status code if the product is not found.
            }

            return Ok(product);
        }
    }
}
