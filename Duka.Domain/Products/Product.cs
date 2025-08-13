using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duka.Domain.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}