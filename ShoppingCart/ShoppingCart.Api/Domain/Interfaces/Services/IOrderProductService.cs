using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Services
{
    public interface IOrderProductService : IBaseService<OrderProduct>
    {
        Task<BaseResult<List<OrderProduct>>> GetAllLimit(int limit, int skip);
        Task<BaseResult<OrderProduct?>> GetByGuid(Guid guid);
    }
}
