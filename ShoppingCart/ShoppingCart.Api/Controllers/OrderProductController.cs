using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Dtos;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using ShoppingCart.Api.Domain.Services;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/order-products")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly IOrderProductService _orderOrderProductService;

        public OrderProductController(IOrderProductService orderOrderProductService)
        {
            _orderOrderProductService = orderOrderProductService;
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

            var result = await _orderOrderProductService.GetAllLimit(limit, skip);
            return Ok(result.Result);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            var result = await _orderOrderProductService.GetByGuid(guid);
            if(result.Success == false)
            {
                return NotFound();
            }

            return Ok(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderProductRequest orderOrderProductRequest)
        {
            if (ModelState.IsValid)
            {
                var orderOrderProduct = new OrderProduct
                {
                    OrderId = orderOrderProductRequest.OrderId,
                    ProductId = orderOrderProductRequest.ProductId,
                    Quantity = orderOrderProductRequest.Quantity,
                    Price = orderOrderProductRequest.Price
                };

                var result = await _orderOrderProductService.Create(orderOrderProduct);

                if (result.Success == false)
                {
                    return BadRequest(result.Message);
                }

                return Ok(result.Result);
            }


            return BadRequest();
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> Update([FromBody] OrderProductRequest orderOrderProductRequest, Guid guid)
        {
            if (ModelState.IsValid)
            {
                var resultOrderProduct = await _orderOrderProductService.GetByGuid(guid);
                if (resultOrderProduct.Success == false)
                {
                    return NotFound();
                }

                var orderOrderProduct = new OrderProduct
                {
                    Guid = guid,
                    OrderId = orderOrderProductRequest.OrderId,
                    ProductId = orderOrderProductRequest.ProductId,
                    Quantity = orderOrderProductRequest.Quantity,
                    Price = orderOrderProductRequest.Price
                };

                var result = await _orderOrderProductService.Update(orderOrderProduct);

                if (result.Success == false)
                {
                    return BadRequest(result.Message);
                }

                return Ok(result.Result);
            }


            return BadRequest();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Detele(Guid guid)
        {
            var result = await _orderOrderProductService.Delete(guid);
            if (result.Success == false)
            {
                return NotFound();
            }

            return Ok(result.Result);
        }

    }
}


