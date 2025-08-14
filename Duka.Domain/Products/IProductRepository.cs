using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duka.Domain.Products
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
    
        Task AddAsync(Product product);
    
        Task UpdateAsync(Product product);
    
        Task DeleteAsync(int id);
    
    }
}