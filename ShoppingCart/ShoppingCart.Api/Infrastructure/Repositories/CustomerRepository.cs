using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Repositories;
using ShoppingCart.Api.Infrastructure.Context;

namespace ShoppingCart.Api.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly MySQLContext _DBContext;

        public CustomerRepository(MySQLContext context) : base(context)
        {
            _DBContext = context;
        } 

        public async Task<IEnumerable<Customer>> GetAllLimit(int limit, int skip)
        {
            return await _DBContext.Customers
                .OrderByDescending(e => e.Id)
                .Skip(skip)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Customer?> GetByGuid(Guid guid)
        {
            return await _DBContext.Customers
                .Where(e => e.Guid == guid)
                .FirstOrDefaultAsync();
        }

        public async Task<Customer?> GetById(int id)
        {
            return await _DBContext.Customers
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }


    }

}
