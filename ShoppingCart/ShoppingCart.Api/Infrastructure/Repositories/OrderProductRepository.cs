using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Repositories;
using ShoppingCart.Api.Infrastructure.Context;

namespace ShoppingCart.Api.Infrastructure.Repositories
{
    public class OrderProductRepository : BaseRepository<OrderProduct>, IOrderProductRepository
    {
        private readonly MySQLContext _DBContext;

        public OrderProductRepository(MySQLContext context) : base(context)
        {
            _DBContext = context;
        } 

        public async Task<IEnumerable<OrderProduct>> GetAllLimit(int limit, int skip)
        {
            return await _DBContext.OrderProducts
                .OrderByDescending(e => e.Id)
                .Skip(skip)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<OrderProduct?> GetByGuid(Guid guid)
        {
            return await _DBContext.OrderProducts
                .Where(e => e.Guid == guid)
                .FirstOrDefaultAsync();
        }

        public async Task<OrderProduct?> GetById(int id)
        {
            return await _DBContext.OrderProducts
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }


    }

}
