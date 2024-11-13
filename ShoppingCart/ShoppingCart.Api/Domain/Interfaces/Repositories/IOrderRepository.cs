using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllLimit(int limit, int skip);
        Task<Order> GetById(int id);
        Task<Order> GetByGuid(Guid guid);
    }
}
