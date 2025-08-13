using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duka.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Duka.Infrastructure.Database.Mapping
{
    public class ProductCartConfiguration : IEntityTypeConfiguration<ProductCart>
    {
        public void Configure(EntityTypeBuilder<ProductCart> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.Id)
                .ValueGeneratedOnAdd();

            builder.Property(pc => pc.UserId)
                .IsRequired();

            builder.HasMany(pc => pc.CartItems)
                .WithOne(pci => pci.ProductCart)
                .HasForeignKey(pci => pci.ProductCartId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}