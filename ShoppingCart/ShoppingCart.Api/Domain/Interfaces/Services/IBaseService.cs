using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Services
{
    public interface IBaseService<T>
    {
        Task<BaseResult<T>> Create(T entity);
        Task<BaseResult<T>> Update(T entity);
        Task<BaseResult<int>> Delete(T entity);
    }
}
