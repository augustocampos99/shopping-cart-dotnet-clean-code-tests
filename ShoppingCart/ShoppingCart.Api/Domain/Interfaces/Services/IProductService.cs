using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllLimit(int limit, int skip);
        Task<Product?> GetByGuid(Guid guid);
        Task<Product> Create(Product post);
        Task<Product> Update(Product post);
        Task<int> Delete(Product post);
    }
}
