using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllLimit(int limit, int skip);
        Task<Product> GetById(int id);
        Task<Product> GetByGuid(Guid guid);
    }
}
