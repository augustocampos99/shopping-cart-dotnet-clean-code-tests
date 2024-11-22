using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Dtos;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using ShoppingCart.Api.Domain.Services;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
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
                    return BadRequest(new BaseResponse<Object> { Success = false, Message = "Invalid parameter!" });
                }
            }

            var result = await _orderService.GetAllLimit(limit, skip);
            return Ok(result.Result);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            var result = await _orderService.GetByGuid(guid);
            if(result.Success == false)
            {
                return NotFound();
            }

            return Ok(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderRequest orderRequest)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    CustomerId = orderRequest.CustomerId,
                    TotalPrice = orderRequest.TotalPrice,
                    Status = orderRequest.Status
                };

                var result = await _orderService.Create(order);

                if(result.Success == false)
                {
                    return BadRequest(result.Message);
                }

                return Ok(result.Result);
            }


            return BadRequest();
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> Update([FromBody] OrderRequest orderRequest, Guid guid)
        {
            if (ModelState.IsValid)
            {
                var resultOrder = await _orderService.GetByGuid(guid);
                if (resultOrder.Success == false)
                {
                    return NotFound();
                }

                var order = new Order
                {
                    Guid = guid,
                    CustomerId = orderRequest.CustomerId,
                    TotalPrice = orderRequest.TotalPrice,
                    Status = orderRequest.Status
                };

                var result = await _orderService.Update(order);

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
            var result = await _orderService.Delete(guid);
            if (result.Success == false)
            {
                return NotFound();
            }

            return Ok(result.Result);
        }

    }
}


