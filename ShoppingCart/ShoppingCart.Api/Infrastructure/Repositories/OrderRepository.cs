using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Repositories;
using ShoppingCart.Api.Infrastructure.Context;

namespace ShoppingCart.Api.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly MySQLContext _DBContext;

        public OrderRepository(MySQLContext context) : base(context)
        {
            _DBContext = context;
        } 

        public async Task<IEnumerable<Order>> GetAllLimit(int limit, int skip)
        {
            return await _DBContext.Orders
                .OrderByDescending(e => e.Id)
                .Skip(skip)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Order?> GetByGuid(Guid guid)
        {
            return await _DBContext.Orders
                .Where(e => e.Guid == guid)
                .FirstOrDefaultAsync();
        }

        public async Task<Order?> GetById(int id)
        {
            return await _DBContext.Orders
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }


    }

}
