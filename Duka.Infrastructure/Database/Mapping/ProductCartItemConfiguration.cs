using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duka.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Duka.Infrastructure.Database.Mapping
{
    public class ProductCartItemConfiguration : IEntityTypeConfiguration<ProductCartItem>
    {
        public void Configure(EntityTypeBuilder<ProductCartItem> builder)
        {
            builder.HasKey(pci => pci.Id);

            builder.Property(pci => pci.Id)
                .ValueGeneratedOnAdd();

            builder.Property(pci => pci.Quantity)
                .IsRequired();

            builder.HasOne(pci => pci.ProductCart)
                .WithMany(pc => pc.CartItems)
                .HasForeignKey(pci => pci.ProductCartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pci => pci.Product)
                .WithMany()
                .HasForeignKey(pci => pci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}