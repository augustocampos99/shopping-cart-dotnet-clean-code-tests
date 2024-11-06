using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain.Entities;

namespace ShoppingCart.Api.Infrastructure.Mapping
{
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("order_products");
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Guid).HasColumnName("guid");
            builder.Property(e => e.OrderId).HasColumnName("order_id");
            builder.Property(e => e.ProductId).HasColumnName("product_id");
            builder.Property(e => e.Quantity).HasColumnName("quantity");
            builder.Property(e => e.Price).HasColumnName("price");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
