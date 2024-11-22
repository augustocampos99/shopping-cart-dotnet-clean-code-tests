using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Repositories;
using ShoppingCart.Api.Domain.Interfaces.Services;
using ShoppingCart.Api.Dtos;

namespace ShoppingCart.Api.Domain.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderProductService(IOrderProductRepository orderProductRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderProductRepository = orderProductRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<BaseResult<List<OrderProduct>>> GetAllLimit(int limit, int skip)
        {
            try
            {
                var result = await _orderProductRepository.GetAllLimit(limit, skip);
                return new BaseResult<List<OrderProduct>> { Success = true, Result = result.ToList(), Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<OrderProduct>> GetByGuid(Guid guid)
        {
            try
            {
                var result = await _orderProductRepository.GetByGuid(guid);
                if (result == null)
                {
                    return new BaseResult<OrderProduct> { Success = false, Result = null, Message = "Not found" };
                }

                return new BaseResult<OrderProduct> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<OrderProduct>> Create(OrderProduct orderProduct)
        {
            try
            {
                var verify = await this.VerifyOrderProduct(orderProduct);
                if(!String.IsNullOrEmpty(verify))
                {
                    return new BaseResult<OrderProduct> { Success = false, Result = null, Message = verify };
                }

                orderProduct.Guid = Guid.NewGuid();
                orderProduct.CreatedAt = DateTime.Now;
                orderProduct.UpdatedAt = DateTime.Now;

                var result = await _orderProductRepository.Create(orderProduct);
                return new BaseResult<OrderProduct> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<OrderProduct>> Update(OrderProduct orderProduct)
        {
            try
            {
                var orderProductResult = await _orderProductRepository.GetByGuid(orderProduct.Guid);

                if (orderProductResult == null)
                {
                    return new BaseResult<OrderProduct> { Success = false, Result = null, Message = "Not found" };
                }

                var verify = await this.VerifyOrderProduct(orderProduct);
                if (!String.IsNullOrEmpty(verify))
                {
                    return new BaseResult<OrderProduct> { Success = false, Result = null, Message = verify };
                }

                orderProductResult.OrderId = orderProduct.OrderId;
                orderProductResult.ProductId = orderProduct.ProductId;
                orderProductResult.Quantity = orderProduct.Quantity;
                orderProductResult.Price = orderProduct.Price;
                orderProductResult.UpdatedAt = DateTime.Now;

                var result = await _orderProductRepository.Update(orderProductResult);

                return new BaseResult<OrderProduct> { Success = true, Result = result, Message = "" };
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
                var orderProduct = await _orderProductRepository.GetByGuid(guid);
                if(orderProduct == null)
                {
                    return new BaseResult<int> { Success = false, Result = 0, Message = "Not found" };
                }

                var result = await _orderProductRepository.Delete(orderProduct);
                return new BaseResult<int> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string?> VerifyOrderProduct(OrderProduct orderProduct)
        {
            var order = await _orderRepository.GetById(orderProduct.OrderId);
            if (order == null)
            {
                return "Order not found";
            }

            var product = await _productRepository.GetById(orderProduct.ProductId);
            if (product == null)
            {
                return "Product not found";
            }

            return null;
        }

    }
}
