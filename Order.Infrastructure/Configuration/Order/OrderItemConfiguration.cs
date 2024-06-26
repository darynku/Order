using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Core.Entities;

namespace Order.Infrastructure.Configuration.Order
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_items");
            builder.HasKey(x => x.Id);
            builder.ComplexProperty(x => x.Price, p =>
            {
                p.Property(m => m.Currency)
                 .HasColumnName("currency")
                 .IsRequired();

                p.Property(m => m.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price")
                .IsRequired();
            });


        }
    }
}
