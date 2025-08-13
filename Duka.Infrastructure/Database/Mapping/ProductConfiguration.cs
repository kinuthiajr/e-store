using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duka.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Duka.Infrastructure.Database.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(250);
                
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);
            
            builder.Property(p => p.Price)
            .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}