using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Repositories;
using ShoppingCart.Api.Domain.Interfaces.Services;
using ShoppingCart.Api.Dtos;

namespace ShoppingCart.Api.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<BaseResult<List<Product>>> GetAllLimit(int limit, int skip)
        {
            try
            {
                var result = await _productRepository.GetAllLimit(limit, skip);
                return new BaseResult<List<Product>> { Success = true, Result = result.ToList(), Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<Product>> GetByGuid(Guid guid)
        {
            try
            {
                var result = await _productRepository.GetByGuid(guid);
                return new BaseResult<Product> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<Product>> Create(Product product)
        {
            try
            {
                product.Guid = Guid.NewGuid();
                product.CreatedAt = DateTime.Now;
                product.UpdatedAt = DateTime.Now;

                var result = await _productRepository.Create(product);
                return new BaseResult<Product> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<Product>> Update(Product product)
        {
            try
            {
                var productResult = await _productRepository.GetByGuid(product.Guid);

                productResult.Title = product.Title;
                productResult.Description = product.Description;
                productResult.Price = product.Price;
                productResult.UpdatedAt = DateTime.Now;

                var result = await _productRepository.Update(productResult);

                return new BaseResult<Product> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResult<int>> Delete(Product product)
        {
            try
            {
                var result = await _productRepository.Delete(product);
                return new BaseResult<int> { Success = true, Result = result, Message = "" };
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
