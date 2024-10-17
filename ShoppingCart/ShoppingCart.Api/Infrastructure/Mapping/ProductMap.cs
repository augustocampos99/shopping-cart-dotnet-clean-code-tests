using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Infrastructure.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Guid).HasColumnName("guid");
            builder.Property(e => e.Title).HasColumnName("title");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.Price).HasColumnName("price");

        }
    }
}
