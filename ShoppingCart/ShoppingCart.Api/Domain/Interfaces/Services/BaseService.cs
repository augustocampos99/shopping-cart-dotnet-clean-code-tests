using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Services
{
    public interface BaseService<T>
    {
        Task<BaseResult<List<T>>> GetAllLimit(int limit, int skip);
        Task<BaseResult<T>> GetById(int id);
        Task<BaseResult<T>> GetByGuid(Guid guid);
        Task<BaseResult<T>> Create(T entity);
        Task<BaseResult<T>> Update(T entity);
        Task<BaseResult<int>> Delete(T entity);
    }
}
