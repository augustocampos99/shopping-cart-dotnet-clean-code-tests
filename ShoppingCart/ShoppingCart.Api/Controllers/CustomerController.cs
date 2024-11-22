using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Dtos;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using ShoppingCart.Api.Domain.Services;
using AutoMapper;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
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
                    return BadRequest(new BaseResponse<Object> { Success = false, Message = "Invalid parameter!" });
                }
            }

            var result = await _customerService.GetAllLimit(limit, skip);

            var response = _mapper.Map<List<CustomerResponse>>(result.Result);
            return Ok(new BaseResponse<List<CustomerResponse>> { Success = true, Message = "", Response = response });
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            var result = await _customerService.GetByGuid(guid);
            if(result.Success == false)
            {
                return NotFound();
            }

            var response = _mapper.Map<CustomerResponse>(result.Result);
            return Ok(new BaseResponse<CustomerResponse> { Success = true, Message = "", Response = response });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequest customerRequest)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    Name = customerRequest.Name,
                    Email = customerRequest.Email,
                    Phone = customerRequest.Phone
                };

                var result = await _customerService.Create(customer);

                var response = _mapper.Map<CustomerResponse>(result.Result);
                return Ok(new BaseResponse<CustomerResponse> { Success = true, Message = "", Response = response });
            }


            return BadRequest();
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> Update([FromBody] CustomerRequest customerRequest, Guid guid)
        {
            if (ModelState.IsValid)
            {
                var resultCustomer = await _customerService.GetByGuid(guid);
                if (resultCustomer.Success == false)
                {
                    return NotFound();
                }

                var customer = new Customer
                {
                    Guid = guid,
                    Name = customerRequest.Name,
                    Email = customerRequest.Email,
                    Phone = customerRequest.Phone
                };

                var result = await _customerService.Update(customer);

                var response = _mapper.Map<CustomerResponse>(result.Result);
                return Ok(new BaseResponse<CustomerResponse> { Success = true, Message = "", Response = response });
            }


            return BadRequest();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Detele(Guid guid)
        {
            var result = await _customerService.Delete(guid);
            if (result.Success == false)
            {
                return NotFound();
            }

            return Ok(new BaseResponse<int> { Success = true, Message = "", Response = result.Result });
        }

    }
}


