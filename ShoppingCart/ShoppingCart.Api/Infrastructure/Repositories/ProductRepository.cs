using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Repositories;
using ShoppingCart.Api.Infrastructure.Context;

namespace ShoppingCart.Api.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly MySQLContext _DBContext;

        public ProductRepository(MySQLContext context) : base(context)
        {
            _DBContext = context;
        } 

        public async Task<IEnumerable<Product>> GetAllLimit(int limit, int skip)
        {
            return await _DBContext.Products
                .OrderByDescending(e => e.Id)
                .Skip(skip)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Product?> GetByGuid(Guid guid)
        {
            return await _DBContext.Products
                .Where(e => e.Guid == guid)
                .FirstOrDefaultAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _DBContext.Products
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }


    }

}
