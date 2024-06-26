using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Core.Entities;

namespace Order.Infrastructure.Configuration.Order
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("orders");
            builder.HasKey(o => o.Id);
            builder.ComplexProperty(
                o => o.Money, b =>
                {
                    b.Property(a => a.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                    b.Property(a => a.Currency)
                    .HasColumnName("currency")
                    .IsRequired();
                });
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.HasMany(x => x.OrderItems).WithOne();
        }
    }
}
