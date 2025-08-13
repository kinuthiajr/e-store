using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duka.Domain.Products;
using Duka.Domain.Users;
using Duka.Infrastructure.Database.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Duka.Infrastructure.Database
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options)

    {

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set; }
        public DbSet<ProductCartItem> ProductCartItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(DatabaseConsts.Schema);
        
            modelBuilder.UseIdentityByDefaultColumns();

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCartConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCartItemConfiguration());
        }

    }
    
}