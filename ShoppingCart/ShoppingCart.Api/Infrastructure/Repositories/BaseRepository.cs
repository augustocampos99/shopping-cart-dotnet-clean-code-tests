using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Domain.Interfaces.Repositories;
using ShoppingCart.Api.Infrastructure.Context;

namespace ShoppingCart.Api.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MySQLContext _DBContext;
        private readonly DbSet<T> _DbSet;

        public BaseRepository(MySQLContext context)
        {
            _DbSet = context.Set<T>();
        }

        public async Task<T> Create(T product)
        {
            _DbSet.Add(product);
            await _DBContext.SaveChangesAsync();
            return product;
        }

        public async Task<T> Update(T product)
        {
            _DbSet.Update(product);
            await _DBContext.SaveChangesAsync();
            return product;
        }

        public async Task<int> Delete(T product)
        {
            _DbSet.Remove(product);
            return await _DBContext.SaveChangesAsync();
        }
    }
}
