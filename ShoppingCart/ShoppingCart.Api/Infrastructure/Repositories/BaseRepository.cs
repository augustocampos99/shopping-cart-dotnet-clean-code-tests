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
            _DBContext = context;
        }

        public async Task<T> Create(T entity)
        {
            _DbSet.Add(entity);
            await _DBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _DbSet.Update(entity);
            await _DBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(T entity)
        {
            _DbSet.Remove(entity);
            return await _DBContext.SaveChangesAsync();
        }
    }
}
