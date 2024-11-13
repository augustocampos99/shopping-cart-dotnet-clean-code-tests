using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllLimit(int limit, int skip);
        Task<Customer> GetById(int id);
        Task<Customer> GetByGuid(Guid guid);
    }
}
