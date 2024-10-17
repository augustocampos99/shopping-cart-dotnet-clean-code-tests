using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain.Entities;
using ShoppingCart.Api.Infrastructure.Mapping;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ShoppingCart.Api.Infrastructure.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
        }

        public DbSet<Product> Products { get; set; }
    }
}
