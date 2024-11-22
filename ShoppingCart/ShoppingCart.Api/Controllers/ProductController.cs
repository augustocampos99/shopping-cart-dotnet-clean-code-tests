using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Dtos;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using ShoppingCart.Api.Domain.Services;
using AutoMapper;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
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
                    return BadRequest(new BaseResponse<List<Object>> { Success = false, Message = "Invalid parameter!" });
                }
            }

            var result = await _productService.GetAllLimit(limit, skip);

            var response = _mapper.Map<List<ProductResponse>>(result.Result);
            return Ok(new BaseResponse<List<ProductResponse>> { Success = true, Message = "", Response = response });
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            var result = await _productService.GetByGuid(guid);
            if(result.Success == false)
            {
                return NotFound();
            }

            var response = _mapper.Map<ProductResponse>(result.Result);
            return Ok(new BaseResponse<ProductResponse> { Success = true, Message = "", Response = response });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Title = productRequest.Title,
                    Description = productRequest.Description,
                    Price = productRequest.Price
                };

                var result = await _productService.Create(product);

                var response = _mapper.Map<ProductResponse>(result.Result);
                return Ok(new BaseResponse<ProductResponse> { Success = true, Message = "", Response = response });
            }


            return BadRequest();
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> Update([FromBody] ProductRequest productRequest, Guid guid)
        {
            if (ModelState.IsValid)
            {
                var resultProduct = await _productService.GetByGuid(guid);
                if (resultProduct.Success == false)
                {
                    return NotFound();
                }

                var product = new Product
                {
                    Guid = guid,
                    Title = productRequest.Title,
                    Description = productRequest.Description,
                    Price = productRequest.Price
                };

                var result = await _productService.Update(product);

                var response = _mapper.Map<ProductResponse>(result.Result);
                return Ok(new BaseResponse<ProductResponse> { Success = true, Message = "", Response = response });
            }


            return BadRequest();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Detele(Guid guid)
        {
            var result = await _productService.Delete(guid);
            if (result.Success == false)
            {
                return NotFound();
            }

            return Ok(new BaseResponse<int> { Success = true, Message = "", Response = result.Result });
        }

    }
}


