using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Dtos;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int limit = 10;
            int skip = 0;

            if (!String.IsNullOrEmpty(Request.Query["limit"]) && !String.IsNullOrEmpty(Request.Query["skip"]))
            {
                try
                {
                    limit = Int32.Parse(Request.Query["limit"]);
                    skip = Int32.Parse(Request.Query["skip"]);

                }
                catch (Exception ex)
                {
                    return BadRequest(new BaseResponse { Success = false, Message = "Invalid parameter!" });
                }
            }

            var result = await _productService.GetAllLimit(limit, skip);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequest productRequest)
        {
            if(ModelState.IsValid)
            {
                var product = new Product
                {
                    Title = productRequest.Title,
                    Description = productRequest.Description,
                    Price = productRequest.Price
                };

                var result = await _productService.Create(product);

                return Ok(result);
            }

            return BadRequest("Erros de validação");
        }

    }
}
