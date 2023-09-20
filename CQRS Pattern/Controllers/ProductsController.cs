using CQRS_Pattern.Product.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender; //interface and the field

        public ProductsController(ISender sender) => _sender = sender;//constructor that initialize the field nd this is a one-linear line cinstructor

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var Products = await _sender.Send(new GetProductsQuery());
            return Ok(Products);
        }

    }
}

 