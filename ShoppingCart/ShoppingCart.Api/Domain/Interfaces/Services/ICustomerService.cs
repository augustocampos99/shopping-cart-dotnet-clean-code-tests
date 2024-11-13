using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Services
{
    public interface ICustomerService : IBaseService<Customer>
    {
        Task<BaseResult<List<Customer>>> GetAllLimit(int limit, int skip);
        Task<BaseResult<Customer?>> GetByGuid(Guid guid);
    }
}
