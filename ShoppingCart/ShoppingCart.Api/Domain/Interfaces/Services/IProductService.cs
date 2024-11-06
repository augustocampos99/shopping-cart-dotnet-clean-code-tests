using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Services
{
    public interface IProductService : IBaseService<Product>
    {
        Task<BaseResult<List<Product>>> GetAllLimit(int limit, int skip);
        Task<BaseResult<Product?>> GetByGuid(Guid guid);
    }
}
