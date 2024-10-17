using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Repositories;
using ShoppingCart.Api.Infrastructure.Context;

namespace ShoppingCart.Api.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _DBContext;

        public ProductRepository(MySQLContext context)
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

        public async Task<Product> Create(Product product)
        {
            _DBContext.Products.Add(product);
            await _DBContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _DBContext.Products.Update(product);
            await _DBContext.SaveChangesAsync();
            return product;
        }

        public async Task<int> Delete(Product product)
        {
            _DBContext.Products.Remove(product);
            return await _DBContext.SaveChangesAsync();
        }

    }

}
