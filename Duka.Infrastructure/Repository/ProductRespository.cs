using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duka.Domain.Products;
using Duka.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Duka.Infrastructure.Repository
{
    public class ProductRespository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRespository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _context.Products.Remove(new Product { Id = id });
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                 .AsNoTracking()
                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

    }
}