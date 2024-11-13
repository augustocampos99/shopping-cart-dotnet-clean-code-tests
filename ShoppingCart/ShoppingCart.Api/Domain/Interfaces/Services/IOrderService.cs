using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<BaseResult<List<Order>>> GetAllLimit(int limit, int skip);
        Task<BaseResult<Order?>> GetByGuid(Guid guid);
    }
}
