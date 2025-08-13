using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duka.Domain.Products
{
    public interface IProductRepository
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task UpdateProductAsync(Product product);
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}