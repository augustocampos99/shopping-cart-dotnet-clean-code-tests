using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Repositories
{
    public interface IOrderProductRepository : IBaseRepository<OrderProduct>
    {
        Task<IEnumerable<OrderProduct>> GetAllLimit(int limit, int skip);
        Task<OrderProduct> GetById(int id);
        Task<OrderProduct> GetByGuid(Guid guid);
    }
}
