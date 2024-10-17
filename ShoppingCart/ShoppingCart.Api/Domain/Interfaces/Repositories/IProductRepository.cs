using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllLimit(int limit, int skip);
        Task<Product?> GetByGuid(Guid guid);
        Task<Product> Create(Product post);
        Task<Product> Update(Product post);
        Task<int> Delete(Product post);
    }
}
