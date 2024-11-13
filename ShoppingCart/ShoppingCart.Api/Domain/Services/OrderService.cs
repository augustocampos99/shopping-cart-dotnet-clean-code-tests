using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Repositories;
using ShoppingCart.Api.Domain.Interfaces.Services;
using ShoppingCart.Api.Dtos;

namespace ShoppingCart.Api.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<BaseResult<List<Order>>> GetAllLimit(int limit, int skip)
        {
            try
            {
                var result = await _orderRepository.GetAllLimit(limit, skip);
                return new BaseResult<List<Order>> { Success = true, Result = result.ToList(), Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<Order>> GetByGuid(Guid guid)
        {
            try
            {
                var result = await _orderRepository.GetByGuid(guid);
                if (result == null)
                {
                    return new BaseResult<Order> { Success = false, Result = null, Message = "Not found" };
                }

                return new BaseResult<Order> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<Order>> Create(Order order)
        {
            try
            {
                order.Guid = Guid.NewGuid();
                order.CreatedAt = DateTime.Now;
                order.UpdatedAt = DateTime.Now;

                var result = await _orderRepository.Create(order);
                return new BaseResult<Order> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<Order>> Update(Order order)
        {
            try
            {
                var orderResult = await _orderRepository.GetByGuid(order.Guid);

                if (orderResult == null)
                {
                    return new BaseResult<Order> { Success = false, Result = null, Message = "Not found" };
                }

                orderResult.CustomerId = order.CustomerId;
                orderResult.TotalPrice = order.TotalPrice;
                orderResult.Status = order.Status;
                orderResult.UpdatedAt = DateTime.Now;

                var result = await _orderRepository.Update(orderResult);

                return new BaseResult<Order> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<int>> Delete(Guid guid)
        {
            try
            {
                var order = await _orderRepository.GetByGuid(guid);
                if(order == null)
                {
                    return new BaseResult<int> { Success = false, Result = 0, Message = "Not found" };
                }

                var result = await _orderRepository.Delete(order);
                return new BaseResult<int> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
