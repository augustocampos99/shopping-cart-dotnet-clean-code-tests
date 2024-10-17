using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Repositories;
using ShoppingCart.Api.Domain.Interfaces.Services;

namespace ShoppingCart.Api.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllLimit(int limit, int skip)
        {
            try
            {
                var result = await _productRepository.GetAllLimit(limit, skip);
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetByGuid(Guid guid)
        {
            try
            {
                var result = await _productRepository.GetByGuid(guid);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> Update(Product product)
        {
            try
            {
                var productResult = await _productRepository.GetByGuid(product.Guid);

                productResult.Title = product.Title;
                productResult.Description = product.Description;
                productResult.Price = product.Price;

                var result = await _productRepository.Update(productResult);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> Create(Product product)
        {
            try
            {
                product.Guid = Guid.NewGuid();

                var result = await _productRepository.Create(product);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Delete(Product product)
        {
            try
            {
                var result = await _productRepository.Delete(product);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
